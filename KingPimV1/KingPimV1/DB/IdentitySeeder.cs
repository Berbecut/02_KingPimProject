using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.DB
{
    public class IdentitySeeder : IIdentitySeeder
    {
        private const string _admin = "florin";
        private const string _password = "buggeroff";

        private readonly KingPimDatabaseContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IdentitySeeder(KingPimDatabaseContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public bool CreateAdminAccountIFEmpty()
        {
            if (!_context.Users.Any(u => u.UserName == _admin))
            {
                var result = _userManager.CreateAsync(new IdentityUser
                {
                    UserName = _admin,
                    Email = "florin@example.com",
                    EmailConfirmed = true
                }, _password).Result;
            }
            return true;
        }
    }
}
