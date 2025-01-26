// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace FreeCourse.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes={"catalog_fullpermission"}},
            new ApiResource("photo_stock_catalog"){Scopes={"photo_stock_fullpermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        //get propertysi bunlar aslında. => olan yapı
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(), //sub claime karşılık geliyor.
                       new IdentityResources.Profile(),
                       new IdentityResource(){ Name = "roles", DisplayName="Roles", Description = "Kullanıcı rolleri", UserClaims = new []{"role"} }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Catalog API için full erişim"),
                new ApiScope("photo_stock_fullpermission","Photo Stock API için full erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "Asp.Net Core MVC",
                    ClientId = "WebMvcClient",
                    ClientSecrets= {new Secret("secret".Sha256())},  //şifre secret ve sha256 ile şifrelenecek
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes = 
                    { 
                        "catalog_fullpermission", 
                        "photo_stock_fullpermission",
                        IdentityServerConstants.LocalApi.ScopeName
                    }  //ICollection olduğu için süslü parantez
                },
                new Client
                {
                    ClientName = "Asp.Net Core MVC",
                    ClientId = "WebMvcClientForUser",
                    AllowOfflineAccess = true,
                    ClientSecrets= {new Secret("secret".Sha256())},  //şifre secret ve sha256 ile şifrelenecek
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = //ICollection olduğu için süslü parantez
                    {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        //refresh token elimizde varsa kullanıcı login olmasa da kullanıcı adına token alabiliriz. 
                        //yani burası aslında clientte kullanıcıya login bilgilerinin geldiği kısımdır.
                        ////Mesela normal token süresi uzatılır 60 gün yapılır 60 gün sonra kullanıcı tekrar login olur. 
                        //ya da bu şekilde bir yapı ile offline iken de token alınabilir. 
                        IdentityServerConstants.LocalApi.ScopeName,
                        "roles"
                    }, 
                    AccessTokenLifetime = 1*60*60,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = (int) (DateTime.Now.AddDays(60)- DateTime.Now).TotalSeconds,
                    RefreshTokenUsage = TokenUsage.ReUse
                }
            };
    }
}