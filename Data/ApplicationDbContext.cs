using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaFinal.Models;

namespace PruebaFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Actividades> Actividades {get; set; }

        public DbSet<Tipos> Tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Actividades>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Descricion).IsRequired();
                entity.Property(e => e.DurecionLlamada)
                    .IsRequired()
                    .HasColumnName("DurecionLLamada");
                entity.Property(e => e.IdTipo).HasColumnName("Id_tipo");
                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Tipos>(entity =>
            {
                entity.ToTable("tipos");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            this.SeedUsers(modelBuilder);  
            this.SeedRoles(modelBuilder);
            this.SeedUserRoles(modelBuilder);
            this.SeedTipos(modelBuilder);
        }
        private void SeedUsers(ModelBuilder builder)  
        {  
            PasswordHasher<Users> passwordHasher = new PasswordHasher<Users>();  
            Users user = new Users()  
            {  
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",  
                UserName = "admin@gmail.com",  
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com", 
                NormalizedEmail = "ADMIN@GMAIL.COM", 
                nombre = "admin",
                apellido = "admin",
                direccion = "San Miguel",
                LockoutEnabled = false,  
                PhoneNumber = "1234567890",
                PasswordHash = passwordHasher.HashPassword(null, "Admin*123")
            };  
            builder.Entity<Users>().HasData(user);  
        } 
  
        private void SeedRoles(ModelBuilder builder)  
        {  
            builder.Entity<IdentityRole>().HasData(  
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Supervisor", ConcurrencyStamp = "9caea130-f387-4fb4-a84f-7deb74d5e21d", NormalizedName = "SUPERVISOR" },  
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Agente", ConcurrencyStamp = "673e7e92-139e-4a21-acca-37c556f5ec8d", NormalizedName = "AGENTE" }  
                );  
        }
  
        private void SeedUserRoles(ModelBuilder builder)  
        {  
            builder.Entity<IdentityUserRole<string>>().HasData(  
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }  
                );  
        }

        private void SeedTipos(ModelBuilder builder)
        {
            Tipos tipos = new Tipos{
                Id = 1,
                Tipo = "Duda"
            };
            builder.Entity<Tipos>().HasData(tipos);
            Tipos tipos2 = new Tipos{
                Id = 2,
                Tipo = "Consulta"
            };
            builder.Entity<Tipos>().HasData(tipos2);
            Tipos tipos3 = new Tipos{
                Id = 3,
                Tipo = "Reclamo"
            };
            builder.Entity<Tipos>().HasData(tipos3);
        }
    }
}
