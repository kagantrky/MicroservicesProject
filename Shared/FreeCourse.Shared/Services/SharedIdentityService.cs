using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeCourse.Shared.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        //hem requeste hem response a erişebilecek interface

        private IHttpContextAccessor _httpContextAccessor;

        public SharedIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //alttakini her seferinde yazmayalım ihtiyacımız olduğunda shared üzerinden kullanalım
        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
        //Where (x => x.Type =="sub").FirstOrDefault
    }
}
