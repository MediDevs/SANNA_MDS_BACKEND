using MDS.Infrastructure.DbUtility;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MDS.DbContext.Entities.Identity
{
    public class ApplicationRole : IdentityRole<long>, IEntity
    {
        public ApplicationRole() { }
        public ApplicationRole(string name) { Name = name; }
    }
}
