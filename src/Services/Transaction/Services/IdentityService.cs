﻿namespace Transaction.WebApi.Services
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using Transaction.WebApi.Models;
    using Transaction.WebApi.Services.Interface;

    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IdentityModel GetIdentity()
        {
            string authorizationHeader = _context.HttpContext.Request.Headers["Authorization"];

            if (authorizationHeader != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = authorizationHeader.Split(" ")[1];
                var paresedToken = tokenHandler.ReadJwtToken(token);

                var account = paresedToken.Claims
                    .Where(c => c.Type == "accountnumber")
                    .FirstOrDefault();

                return new IdentityModel()
                {
                    AccountNumber = Convert.ToInt32(account.Value)
                };
            }

            throw new ArgumentNullException("accountnumber");
        }
    }
}
