using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Bug.Authorization.Roles;
using Bug.Authorization.Users;
using Bug.MultiTenancy;
using Bug.Testcases;

namespace Bug.EntityFrameworkCore
{
    public class BugDbContext : AbpZeroDbContext<Tenant, Role, User, BugDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public BugDbContext(DbContextOptions<BugDbContext> options)
            : base(options)
        {
        }

        //TODO: Define an DbSet for your Entities...
        public DbSet<Testcase> Testcases { get; set; }
    }
}
