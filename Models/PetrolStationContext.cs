using System;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstProject.Models
{
    public partial class PetrolStationContext : DbContext
    {
        public PetrolStationContext()
        {

        }

        public PetrolStationContext(DbContextOptions<PetrolStationContext> options)
            : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PetrolStation>(entity =>
            {
                entity.HasKey(e => e.StationId)
                    .HasName("PK_dbo.PetrolStation");

                entity.Property(e => e.StationId).HasColumnName("StationId");

                entity.Property(e => e.StationName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumberOfPumps)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.HasOne(d => d.fuelInfo)
                    .WithMany()
                    .HasForeignKey(d => d.FuelId);
            });

            modelBuilder.Entity<PetrolStation>()
                .HasData(
                    new PetrolStation
                    {
                        StationId = 1,
                        StationName = "StationOne",
                        Address = "Street, City, Postcode",
                        NumberOfPumps = 10,
                        PumpActivation = false,
                        FuelId = 1
                    },

                    new PetrolStation
                    {
                        StationId = 2,
                        StationName = "StationTwo",
                        Address = "Street, City, Postcode",
                        NumberOfPumps = 8,
                        PumpActivation = false,
                        FuelId = 2

                    },

                    new PetrolStation
                    {
                        StationId = 3,
                        StationName = "StationThree",
                        Address = "Street, City, Postcode",
                        NumberOfPumps = 10,
                        PumpActivation = false,
                        FuelId = 3
                    },

                    new PetrolStation
                    {
                        StationId = 4,
                        StationName = "StationFour",
                        Address = "Street, City, Postcode",
                        NumberOfPumps = 10,
                        PumpActivation = false,
                        FuelId = 1
                    },

                    new PetrolStation
                    {
                        StationId = 5,
                        StationName = "StationFive",
                        Address = "Street, City, Postcode",
                        NumberOfPumps = 8,
                        PumpActivation = false,
                        FuelId = 2
                    },

                    new PetrolStation
                    {
                        StationId = 6,
                        StationName = "StationSix",
                        Address = "Street, City, Postcode",
                        NumberOfPumps = 6,
                        PumpActivation = false,
                        FuelId = 3
                    }
                    );
            modelBuilder.Entity<FuelInfo>(entity =>
            {
                entity.HasKey(e => e.FuelId)
                    .HasName("PK_dbo.FuelInfo");

                entity.Property(e => e.FuelType).HasColumnName("Type");

                entity.Property(s => s.FuelPrice).HasColumnType("decimal(18, 2)");

            });
            modelBuilder.Entity<FuelInfo>()
              .HasData(
           new FuelInfo
           {
               FuelId = 1,
               FuelType = "Diesel",
               FuelPrice = 130
           },

           new FuelInfo
           {
               FuelId = 2,
               FuelType = "Petrol",
               FuelPrice = 100
           },

           new FuelInfo
           {
               FuelId = 3,
               FuelType = "Electric",
               FuelPrice = 50

           });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
