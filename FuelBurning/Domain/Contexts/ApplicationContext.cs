using Domain.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Domain.Contexts
{
	public class ApplicationContext : DbContext
	{
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<DataJsonGasFuelModel> DataJsonGasFuelModels { get; set; }
        public DbSet<DataJsonLiquidFuelModel> DataJsonLiquidFuelModels { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminLogin = "admin";
            string adminPassword = "admin";

            // добавляем роли
            RoleModel adminRole = new RoleModel { Id = 1, Name = adminRoleName };
            RoleModel userRole = new RoleModel { Id = 2, Name = userRoleName };

            UserModel adminUser = new UserModel { Id = 1, Login = adminLogin, Password = adminPassword, RoleId = adminRole.Id };

            var gasModelDefault = DataJsonGasFuelModel.GetDefaultModel();

            modelBuilder.Entity<DataJsonGasFuelModel>().HasData(new DataJsonGasFuelModel[] { gasModelDefault });

            modelBuilder.Entity<RoleModel>().HasData(new RoleModel[] { adminRole, userRole });
            modelBuilder.Entity<UserModel>().HasData(new UserModel[] { adminUser });

            var liquidModelLiquid = DataJsonLiquidFuelModel.GetDefaultModel();

            modelBuilder.Entity<DataJsonLiquidFuelModel>().HasData(new DataJsonLiquidFuelModel[] { liquidModelLiquid });

            base.OnModelCreating(modelBuilder);
        }
        public class DataJsonGasFuelModelConfiguration : IEntityTypeConfiguration<DataJsonGasFuelModel>
        {
            public void Configure(EntityTypeBuilder<DataJsonGasFuelModel> builder)
            {
                builder.Property(e => e.GasFuelModel).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<DataGasFuelModel>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            }
        }
        public class DataJsonLiquidFuelModelConfiguration : IEntityTypeConfiguration<DataJsonLiquidFuelModel>
        {
            public void Configure(EntityTypeBuilder<DataJsonLiquidFuelModel> builder)
            {
                builder.Property(e => e.LiquidFuelModel).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<DataLiquidModel>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            }
        }
    }


}
