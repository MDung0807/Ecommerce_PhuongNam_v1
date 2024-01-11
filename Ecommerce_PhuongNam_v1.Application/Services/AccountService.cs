using System.Security.Claims;
using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Constants;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.Common.Exceptions;
using Ecommerce_PhuongNam_v1.Application.Common.Utils;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Application.Specifications.Account;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services
{
    public sealed class AccountService : IAccountService
    {
        #region -- Properties --
        private readonly IRoleService _roleService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Account, Guid> _repository;
        private readonly IMapper _mapper;
        private readonly IRoleAccountService _roleAccountService;
        private readonly IAuthService _authService;
        #endregion -- Properties --

        #region -- Public Method --

        public AccountService(IMapper mapper, IRoleService roleService, 
            IUnitOfWork unitOfWork, IRoleAccountService roleAccountService,
            IAuthService authService)
        {
            _mapper = mapper;
            _roleService = roleService;
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GenericRepository<Account, Guid>();
            _roleAccountService = roleAccountService;
            _authService = authService;
        }

        public async Task<bool> Create(AuthRequest request)
        {
            try
            {
                Account account = _mapper.Map<Account>(request);
                Role role = await _roleService.GetRole(request.RoleName);
                account.Password = PassEncrypt.HashPassword(request.Password);
                account.Status = (int) EnumsApp.Waiting;
                account = await _repository.Create(account);
                RoleAccount roleAccount = new RoleAccount
                {
                    Account = account,
                    Role = role,
                    Status = (int)EnumsApp.Waiting
                };

                await _roleAccountService.Create(roleAccount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return true;
        }

        public Task<bool> ChangeIsActive(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeIsLock(Guid id)
        {
            throw new NotImplementedException();
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

        public Task<object> GetAllByAdmin(object pagingRequest)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAll(object pagingRequest)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAll(object pagingRequest, Guid idMaster)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteHard(Guid id)
        {
            AccountSpecification accountSpecification = new AccountSpecification(id, checkStatus:false, isDelete:true);
            Account account = await _repository.Get(accountSpecification);
            return await _repository.DeleteHard(account);
        }

        public Task<List<AuthResponse>> GetAllByAdmin()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ResetPass(FormResetPass request)
        {

            AccountSpecification accountSpecification = new AccountSpecification(request.Username);
            Account account = await _repository.Get(accountSpecification) ?? throw new AuthException(AuthConstants.UNAUTHORIZATION);
            if (account.Customer != null)
            {
                if (account.Customer.Email != request.Email ||
                    account.Customer.PhoneNumber != request.PhoneNumber)
                    throw new AuthException(AuthConstants.UNAUTHORIZATION);
            }
            else 
            {
                if(account.Shop.Email != request.Email ||
                   account.Shop.PhoneNumber != request.PhoneNumber)
                    throw new AuthException(AuthConstants.UNAUTHORIZATION);
            }

            if (!PassEncrypt.VerifyPassword(request.PasswordOld, account.Password))
            {
                throw new AuthException(AuthConstants.UNAUTHORIZATION);
            }

            account.Password = PassEncrypt.HashPassword(request.PasswordNew);
            await _repository.Update(account);
            return true;
        }
        
        public async Task<AuthResponse> RefreshToken(RefreshTokenRequest request)
        {
            var principal = JwtUtils.GetPrincipal(request.Token);
            var username = principal.FindFirstValue("Username");
            var account = await GetAccountByUsername(username); //retrieve the refresh token from a data store
            if (!RefreshTokenIsCorrect(account, request.RefreshToken, request.IdDeceive))
                throw new AuthException(AuthConstants.REFRESH_TOKEN_FAIL);

            Auth auth = account.Auths.First(x => x.IdDeceive == request.IdDeceive);
            auth.RefreshToken = JwtUtils.GenerateRefreshToken();
            AuthResponse response = _mapper.Map<AuthResponse>(account);
            if (response.RoleName == AppConstants.SHOP)
                response.Id = account.Shop.Id;
            else
                response.Id = account.Customer.Id;
            if (!await SaveRefreshToken(account))
                throw new AuthException(AuthConstants.REFRESH_TOKEN_FAIL);
            
            
            response.Token = JwtUtils.GenerateToken(response);
            return response;
        }

        /// <summary>
        /// Change status account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        // public async Task<bool> ChangeStatus(AuthRequest request)
        // {
        //     try
        //     {
        //         AccountSpecification accountSpecification =
        //             new AccountSpecification("customer12", AppConstants.CUSTOMER);
        //         Account account = await _repository.Get(accountSpecification);
        //         await _repository.ChangeStatus(account, );
        //         return true;
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e.ToString());
        //         throw;
        //     }
        // }

        public Task<bool> Update(FormResetPass entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AuthResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            AuthResponse response = new AuthResponse();

            Account accountRequest = _mapper.Map<Account>(request);
            Account account = await GetAccountByUsername(request.Username) ?? throw new NotFoundException(AuthConstants.NOT_FOUND);

            Auth auth = account.Auths.First(x => x.IdDeceive == request.IdDeceive);
            auth.RefreshToken = JwtUtils.GenerateRefreshToken();
            if (PassEncrypt.VerifyPassword(accountRequest.Password, account.Password))
            {
                if (true)
                {
                    response.Username = account.Username;
                    response.RoleName = request.RoleName;
                    if (account.Customer != null)
                        response.Id = account.Customer.Id;
                    else
                    {
                        response.Id = account.Shop.Id;
                    }

                    if (!await SaveRefreshToken(account))
                        throw new ExceptionDetail(AuthConstants.ERROR);
                    response.Token = JwtUtils.GenerateToken(response);
                    response.RefreshToken = auth.RefreshToken;
                    return response;
                }
            }

            throw new ExceptionDetail(AuthConstants.LOGIN_FAIL);
        }
        // public async Task<AccResponse> getAccByUsername(string Username, string roleName)
        // {
        //     AccountSpecification accountSpecification = new AccountSpecification(Username, roleName);
        //     Account account = await _repository.Get(accountSpecification);
        //
        //     AccResponse response = _mapper.Map<AccResponse>(account);
        //
        //     if (roleName == "COMPANY")
        //         response.Id = account.Company.Id;
        //     else 
        //         response.Id = account.Customer.Id;
        //     return response;
        // }

        public async Task<Account> GetAccountByUsername(string username, string roleName, bool checkStatus = true)
        {
            AccountSpecification accountSpecification = new AccountSpecification(username, roleName, checkStatus);
            Account account = await _repository.Get(accountSpecification, checkStatus: false);
            return account;
        }
        
        public async Task<Account> GetAccountByUsername(string username, bool checkStatus = true)
        {
            AccountSpecification specification = new AccountSpecification(username:username);
            Account account = await _repository.Get(specification, checkStatus: false);
            return account;
        }
        #endregion -- Public Method --

        #region -- Private Method --

        private async Task<bool> SaveRefreshToken(Account account)
        {
            await _authService.Update(account);
            return true;
        }

        private bool RefreshTokenIsCorrect(Account account, string refreshToken, string idDeceive)
        {
            bool isRegis = false;
            foreach (var auth in account.Auths)
            {
                if (auth.IdDeceive == idDeceive)
                {
                    isRegis = true;
                    if (auth.RefreshToken != refreshToken)
                        return false;
                }
            }

            if (!isRegis)
                return false;
            return true;
        }

        #endregion -- Private Method --
    }
}
