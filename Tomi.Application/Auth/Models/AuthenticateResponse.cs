﻿namespace Tomi.Application.Auth.Models
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }
		public string UserId { get; set; }
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
