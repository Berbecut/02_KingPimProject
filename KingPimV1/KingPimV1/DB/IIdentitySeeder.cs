using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.DB
{
    public interface IIdentitySeeder
    {
        bool CreateAdminAccountIFEmpty();
    }
}
