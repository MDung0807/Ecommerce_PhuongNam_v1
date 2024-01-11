using AutoMapper;
using Ecommerce_PhuongNam_v1.Application.Common.Enums;
using Ecommerce_PhuongNam_v1.Application.Common.OTP.Models;
using Ecommerce_PhuongNam_v1.Application.Common.OTP.Specification;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Common.OTP.Services;

public class OtpService : IOtpService
{
    private readonly IGenericRepository<OtpCode, Guid> _repository;
    private readonly IMapper _mapper;

    public OtpService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _repository = unitOfWork.GenericRepository<OtpCode, Guid>();
    }
    public async Task<OtpResponse> CreateOtp(OtpRequest request)
    {
        OtpSpecification specification = new OtpSpecification(request.Email);
        OtpCode otp = await _repository.Get(specification, checkStatus: false);
        if (otp == null)
            otp = new OtpCode();
        otp.Email = request.Email;
        otp.PhoneNumber = request.PhoneNumber;
        string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };  
  
        otp.Code = GenerateRandomOtp(8, saAllowedCharacters);
        otp.Status = (int)EnumsApp.Active;

        otp = await _repository.CreateOrUpdate(otp);
        return _mapper.Map<OtpCode, OtpResponse>(otp);
    }

    public async Task<bool> AuthenticationOtp(OtpRequest request)
    {
        DateTime dateTimeNow = DateTime.Now;
        int expired = 1000; // expired 10 minute
        OtpSpecification specification = new OtpSpecification(request.Email, dateTime:dateTimeNow, minute:expired, false);
        OtpCode otp = await _repository.Get(specification, checkStatus: false);
        if (otp != null && otp.Code == request.Code)
            return true;
        return false;
    }
    
    private string GenerateRandomOtp(int iOTPLength,string[] saAllowedCharacters )  
    {  
        string sOtp = String.Empty;
        Random rand = new Random();  
        for (int i = 0; i < iOTPLength; i++)  
        {  
            int p = rand.Next(0, saAllowedCharacters.Length);  
            var sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];  
            sOtp += sTempChars;  
        }  
        return sOtp;  
    }  
}