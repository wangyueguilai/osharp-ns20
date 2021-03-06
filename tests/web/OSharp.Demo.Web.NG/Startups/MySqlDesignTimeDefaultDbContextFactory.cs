using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using OSharp.Entity;
using OSharp.Reflection;


namespace OSharp.Demo.Web
{
    public class MySqlDesignTimeDefaultDbContextFactory : IDesignTimeDbContextFactory<MySqlDesignTimeDefaultDbContext>
    {
        /// <summary>Creates a new instance of a derived context.</summary>
        /// <param name="args"> Arguments provided by the design-time service. </param>
        /// <returns> An instance of <typeparamref name="TContext" />. </returns>
        public MySqlDesignTimeDefaultDbContext CreateDbContext(string[] args)
        {
            string connString = "Server=127.0.0.1;port=19021;UserId=root;Password=123456;Database=osharp2;charset='utf8';Allow User Variables=True";
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<DefaultDbContext>();
            builder.UseMySql(connString);
            IEntityConfigurationTypeFinder typeFinder = new EntityConfigurationTypeFinder(new EntityConfigurationAssemblyFinder(new AppDomainAllAssemblyFinder()));
            return new MySqlDesignTimeDefaultDbContext(builder.Options, typeFinder);
        }
    }
}
