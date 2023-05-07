﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Tomi.Application.ApiResponse;
using Tomi.Application.Auth.Models;
using Tomi.Domain.Entities;

namespace Tomi.Application.Auth.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterRequest, Response<string>>
    {
        private readonly UserManager<User> _userManager;

        public RegisterCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<string>> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail == null)
            {
                var user = new User
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PasswordHash = request.Password
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    return new Response<string>(user.Id, message: $"User {user.Id} Registered");
                }
                else
                {
                    return new Response<string>($"{result.Errors}");
                }
            }
            else
            {
                return new Response<string>($"Email {request.Email} is already registered.");
            }
        }
    }
}