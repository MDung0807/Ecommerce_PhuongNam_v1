﻿using CloudinaryDotNet;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;

namespace Ecommerce_PhuongNam_v1.Application.Services;

public class AuthService : IAuthService
{
    public Task<object> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<object>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(object entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(object entity)
    {
        throw new NotImplementedException();
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

    public Task<bool> DeleteHard(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponse> Login(AuthRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Account> GetAccountByUsername(string username, string roleName, bool checkStatus = true)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ResetPass(FormResetPass request, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponse> RefreshToken(RefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Account> GetAccountByUsername(string username, bool checkStatus = true)
    {
        throw new NotImplementedException();
    }
}