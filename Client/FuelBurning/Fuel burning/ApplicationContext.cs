using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuel_burning.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;



public class ApplicationContext : DbContext
{

    public DbSet<UserModel> Users { get; set; }
    public DbSet<RoleModel> Roles { get; set; }
    public DbSet<DataGasFuelModel> DataGasFuelModels { get; set; }
    public DbSet<DataLiquidFuelModel> DataLiquidFuelModels { get; set; }


    public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
    {
        //Database.EnsureDeleted();
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

        var gasModelDefault = DataGasFuelModel.GetDefaultModel();

        modelBuilder.Entity<DataGasFuelModel>().HasData(new DataGasFuelModel[] { gasModelDefault });

        modelBuilder.Entity<RoleModel>().HasData(new RoleModel[] { adminRole, userRole });
        modelBuilder.Entity<UserModel>().HasData(new UserModel[] { adminUser});

        var liquidModelLiquid = DataLiquidFuelModel.GetDefaultModel();

        modelBuilder.Entity<DataLiquidFuelModel>().HasData(new DataLiquidFuelModel[] { liquidModelLiquid });

        base.OnModelCreating(modelBuilder);
    }
    public class DataGasFuelModelConfiguration : IEntityTypeConfiguration<DataGasFuelModel>
    {
            public void Configure(EntityTypeBuilder<DataGasFuelModel> builder)
        {
            builder.Property(e => e.GasFuelModel).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<GasFuelModel>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
    public class DataLiquidFuelModelConfiguration : IEntityTypeConfiguration<DataLiquidFuelModel>
    {
        public void Configure(EntityTypeBuilder<DataLiquidFuelModel> builder)
        {
            builder.Property(e => e.LiquidFuelModel).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<LiquidFuelModel>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}

