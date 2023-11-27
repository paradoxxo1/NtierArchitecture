﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using NtierArchitecture.Entities.Repositories;
using System.Security.Claims;

namespace NtierArchitecture.DataAccess.Authorization
{
    public sealed class RoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _role;
        private readonly IUserRoleRepository _userRoleRepository;

        public RoleAttribute(string role, IUserRoleRepository userRoleRepository)
        {
            _role = role;
            _userRoleRepository = userRoleRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim is null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var userHasRole =
                _userRoleRepository
                .GetWhere(p => p.AppUserId.ToString() == userIdClaim.Value)
                .Include(p => p.AppRole)
                .Any(p => p.AppRole.Name == _role);

            if (!userHasRole)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
                
        }
    }
}
