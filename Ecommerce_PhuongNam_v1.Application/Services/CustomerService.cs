using AutoMapper;
using BusBookTicket.Core.Utils;
using Ecommerce_PhuongNam_v1.Application.Common.Cloudinary;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.Common.Exceptions;
using Ecommerce_PhuongNam_v1.Application.Common.MailKet.DTO.Request;
using Ecommerce_PhuongNam_v1.Application.Common.MailKet.Service;
using Ecommerce_PhuongNam_v1.Application.Common.OTP.Models;
using Ecommerce_PhuongNam_v1.Application.Common.OTP.Services;
using Ecommerce_PhuongNam_v1.Application.Common.Responses;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Paging.Customer;
using Ecommerce_PhuongNam_v1.Application.Specifications.Customer;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services
{
    public class CustomerService : ICustomerService
    {
        #region -- Properties --
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Customer, Guid> _repository;
        private readonly IGenericRepository<Cart, Guid> _cartRepository;
        private readonly IOtpService _otpService;
        private readonly IMailService _mailService;
        private readonly CloudImageService _imageService;
        private readonly IAddressDetailService _addressDetailService;
        private readonly ICurrentUserService _currentUserService;

        #endregion --  Properties --

        #region -- Constructor --
        public CustomerService(IMapper mapper,
            IAccountService accountService,
            IUnitOfWork unitOfWork,
            IOtpService opOtpService,
            IMailService mailService,
            CloudImageService imageService,
            IAddressDetailService addressDetail,
            ICurrentUserService currentUserService, IGenericRepository<Cart, Guid> cartRepository)
        {
            _mapper = mapper;
            _accountService = accountService;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GenericRepository<Customer, Guid>();
            _otpService = opOtpService;
            _mailService = mailService;
            _imageService = imageService;
            _addressDetailService = addressDetail;
            _currentUserService = currentUserService;
            _cartRepository = cartRepository;
        }
        #endregion -- Contructor --

        #region -- Public method --

        /// <summary>
        /// Create Customer and account genera
        /// Call Auth Service to create account and get account.
        /// After create customer
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> Create(FormRegister entity)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                
                CustomerSpecification specification = new CustomerSpecification(entity.Email, checkStatus:false, isDelete:true);
                var customer = await _repository.Get(specification);
                if (customer != null)
                {
                    await _repository.DeleteHard(customer);
                    await _accountService.DeleteHard(customer.Account.Id);
                }
                customer = _mapper.Map<Customer>(entity);

                // string linkImage = await _imageService.SaveImage(entity.Avatar);
            
                // Get account
                AuthRequest authRequest = _mapper.Map<AuthRequest>(entity);
                await _accountService.Create(authRequest);
                customer.Account = await _accountService.GetAccountByUsername(entity.Username, entity.RoleName, checkStatus:false);
                
                // Insert customer
                customer.Status = (int)EnumsApp.Waiting;
                customer.Avatar = null;
                await _repository.Create(customer);

                OtpResponse response = await _otpService.CreateOtp(
                    new OtpRequest
                    {
                        Email = customer.Email,
                        PhoneNumber = customer.PhoneNumber
                    });
                
                // Send mail with OTP code
                MailRequest mailRequest = new MailRequest
                {
                    ToMail = customer.Email,
                    Content = "OTP code",
                    FullName = customer.FullName,
                    Subject = "Authentication OTP code",
                    Message = response.Code
                };
                await _mailService.SendEmailAsync(mailRequest);
                
                // Create cart
                Cart cart = new Cart
                {
                    Customer = customer
                };
                await _cartRepository.Create(cart);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
        }

        public async Task<bool> ChangeIsActive(Guid id)
        {
            CustomerSpecification customerSpecification = new CustomerSpecification(id, false, getAll:false);
            Customer customer = await _repository.Get(customerSpecification, checkStatus: false);
            return await _repository.ChangeStatus(customer, (int)EnumsApp.Active);
        }

        public async Task<bool> ChangeIsLock(Guid id)
        {
            CustomerSpecification customerSpecification = new CustomerSpecification(id, false, getAll:false);
            Customer customer = await _repository.Get(customerSpecification, checkStatus: false);
            return await _repository.ChangeStatus(customer, (int)EnumsApp.Lock);
        }

        public Task<bool> ChangeToWaiting(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeToDisable(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckToExistById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckToExistByParam(string param)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerPagingResult> GetAllByAdmin(CustomerPaging pagingRequest)
        {
            List<CustomerResponse> responses = new List<CustomerResponse>();
            CustomerSpecification specification = new CustomerSpecification(paging:pagingRequest);
            var customers = await _repository.ToList(specification);
            int count = await _repository.Count(new CustomerSpecification());
            foreach(Customer customer in customers)
            {
                responses.Add(_mapper.Map<CustomerResponse>(customer));
            }

            CustomerPagingResult result =
                AppUtils.ResultPaging<CustomerPagingResult, CustomerResponse>(pagingRequest.PageIndex,
                    pagingRequest.PageSize, count, responses);
            return result;
        }

        public Task<CustomerPagingResult> GetAll(CustomerPaging pagingRequest)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerPagingResult> GetAll(CustomerPaging pagingRequest, Guid idMaster)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteHard(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerPagingResult> GetAllCustomer(CustomerPaging paging)
        {
            CustomerSpecification specification = new CustomerSpecification(paging, false);
            List<Customer> customers = await _repository.ToList(specification);
            int count = await _repository.Count(new CustomerSpecification(checkStatus:false));
            CustomerPagingResult result = AppUtils.ResultPaging<CustomerPagingResult, CustomerResponse>(
                paging.PageIndex, paging.PageSize, count,
                await AppUtils.MapObject<Customer, CustomerResponse>(customers, _mapper));
            return result;
        }
        

        public async Task<bool> AuthOtp(OtpRequest request)
        {
            CustomerSpecification customerSpecification = new CustomerSpecification(request.Email, checkStatus:false);
            Customer customer = await _repository.Get(customerSpecification, checkStatus: false);
            if (! await _otpService.AuthenticationOtp(request))
            {
                throw new ExceptionDetail(AppConstants.OTP_NOT_AUTH);
            }
            return await ChangeIsActive(customer.Id);
        }

        public async Task<bool> AddLocation(LocationRequest request)
        {
            AddressDetail addressDetail = _mapper.Map<AddressDetail>(request);
            await _addressDetailService.Create(addressDetail);
            return true;
        }

        public async Task<List<CusLocationResponse>> GetAllLocation(Guid customerId)
        {
            var data =  (List<LocationResponse>)await _addressDetailService.GetAll(null, customerId);
            
            return await AppUtils.MapObject<LocationResponse, CusLocationResponse>(data, _mapper);
        }

        public async Task<bool> RemoveAddress(Guid addressDetailId)
        {
            return await _addressDetailService.Delete(addressDetailId);
        }

        public async Task<bool> Delete(Guid id)
        {
            CustomerSpecification customerSpecification = new CustomerSpecification(id, false, getAll:false);
            Customer customer = await _repository.Get(customerSpecification, checkStatus: false);
            return await _repository.ChangeStatus(customer, (int)EnumsApp.Delete);
        }

        public async Task<ProfileResponse> GetById(Guid id)
        {
            CustomerSpecification specification = new CustomerSpecification(id);
            Customer customer = await _repository.Get(specification);
            ProfileResponse response = _mapper.Map<ProfileResponse>(customer);
            return response;
        }

        public Task<List<ProfileResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(FormUpdate entity)
        {
            Customer customer = new Customer();
            
            customer = _mapper.Map<Customer>(entity);
            customer.Id = new Guid(_currentUserService.IdUser);
            customer.Status = (int)EnumsApp.Active;
            await _repository.Update(customer);
            return true;
        }
        #endregion -- Public method --

        #region -- Private Method --

        private Customer setStatus(Customer customer, int status)
        {
            customer.Status = customer.Status != null ? status : customer.Status;
            customer.Account.Status = customer.Account.Status != null ? status: customer.Account.Status;
            return customer;
        }
        #endregion
    }
}
