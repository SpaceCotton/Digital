using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Bug.Configuration;
using Bug.Web;

namespace Bug.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BugDbContextFactory : IDesignTimeDbContextFactory<BugDbContext>
    {
        public BugDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BugDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BugDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BugConsts.ConnectionStringName));

            return new BugDbContext(builder.Options);
        }
    }
}
