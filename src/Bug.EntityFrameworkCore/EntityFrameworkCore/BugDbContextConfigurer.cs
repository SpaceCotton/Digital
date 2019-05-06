using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Bug.EntityFrameworkCore
{
    public static class BugDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BugDbContext> builder, string connectionString)
        {
           builder.UseSqlServer(connectionString);

        }

        public static void Configure(DbContextOptionsBuilder<BugDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }


    }
}
