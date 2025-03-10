﻿using FreeCourse.IdentityServer.Models;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.IdentityServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName); //username ama email gönderilecek

            if (existUser == null)
            {
                var errors = new Dictionary<string, object>();  //object alıp bir dizin de dönülebilir
                errors.Add("errors", new List<string> { "Email or Password Invalid" });

                context.Result.CustomResponse = errors;

                return;
            }
            var passwordCheck = await _userManager.CheckPasswordAsync(existUser, context.Password);

            if (passwordCheck == false)
            {
                var errors = new Dictionary<string, object>();  //object alıp bir dizin de dönülebilir
                errors.Add("errors", new List<string> { "Email or Password Invalid" });

                context.Result.CustomResponse = errors;

                return;
            }

            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);

        }
    }
}
