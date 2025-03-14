﻿using FirstAspApp.DTOs.Token;
using FirstAspApp.DTOs.UserDTOs;
using FirstAspApp.Models;

namespace FirstAspApp.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO request);
        Task<TokenResponseDto?> LoginAsync(UserDTO request);
        Task<TokenResponseDto> RefreshTokensAsync(RefreshTokenRequestDTO request);
    }
}
