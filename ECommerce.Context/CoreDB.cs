using Microsoft.EntityFrameworkCore;
using System;
using ECommerce.Model;

namespace ECommerce.Context
{
    public class CoreDB: DbContext
    {
        public CoreDB(DbContextOptions<CoreDB> options): base(options)
        {

        }

        public DbSet<ProductModel> Product { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<CampaignModel> Campaign { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
