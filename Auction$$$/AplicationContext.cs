using Auction___.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Auction___
{
    public class ApplicationContext : DbContext
    {  
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        public DbSet<UsersModel> usersModels { get; set; }       
        public DbSet<AllLots> usersLots { get; set; }

        public DbSet<MyHistory> HisoryAll { get; set; }

      




    }

}
