using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Companies_example1.Model
{
    public class CompaniesContext: DbContext
    {
        public CompaniesContext()
        {            
        }

        public CompaniesContext(DbContextOptions<CompaniesContext> options) : base(options)
        {         
        }

        public DbSet<Company> Companies => Set<Company>();
        public DbSet<CompanyBranches> CompaniesBranches => Set<CompanyBranches>();

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var company1 = new Company
            {
                Id = -1,
                Name = "Company1",
                BinarySign = false,
            };

            var company2 = new Company
            {
                Id = -2,
                Name = "Company2",
                BinarySign = false,
            };

            var company3 = new Company
            {
                Id = -3,
                Name = "Company3",
                BinarySign = true,
            };

            var company4 = new Company
            {
                Id = -4,
                Name = "Company4",
                BinarySign = true,
            };

            var company5 = new Company
            {
                Id = -5,
                Name = "Company5",
                BinarySign = true,
            };

            modelBuilder.Entity<Company>()
                .HasData(
                    company1
                );

            modelBuilder.Entity<Company>()
                .HasData(
                    company2
                );

            modelBuilder.Entity<Company>()
                .HasData(
                    company3
                );

            modelBuilder.Entity<Company>()
                .HasData(
                    company4
                );

            modelBuilder.Entity<Company>()
                .HasData(
                    company5
                );

            modelBuilder.Entity<CompanyBranches>()
                .HasData(
                    new CompanyBranches
                    {
                        Id = -1,
                        Name = "C1_B1",
                        CompanyId = company1.Id,
                    }
                );
            
            modelBuilder.Entity<CompanyBranches>()
                .HasData(
                    new CompanyBranches
                    {
                        Id = -2,
                        Name = "C1_B2",
                        CompanyId = company1.Id,
                    }
                );

            modelBuilder.Entity<CompanyBranches>()
                .HasData(
                    new CompanyBranches
                    {
                        Id = -3,
                        Name = "C2_B1",
                        CompanyId = company2.Id,
                    }
                );

            modelBuilder.Entity<CompanyBranches>()
                .HasData(
                    new CompanyBranches
                    {
                        Id = -4,
                        Name = "C3_B1",
                        CompanyId = company3.Id,
                    }
                );

            modelBuilder.Entity<CompanyBranches>()
                .HasData(
                    new CompanyBranches
                    {
                        Id = -5,
                        Name = "C3_B2",
                        CompanyId = company3.Id,
                    }
                );

            modelBuilder.Entity<CompanyBranches>()
                .HasData(
                    new CompanyBranches
                    {
                        Id = -6,
                        Name = "C3_B3",
                        CompanyId = company3.Id,
                    }
                );

            modelBuilder.Entity<CompanyBranches>()
                .HasData(
                    new CompanyBranches
                    {
                        Id = -7,
                        Name = "C3_B4",
                        CompanyId = company3.Id,
                    }
                );

            modelBuilder.Entity<CompanyBranches>()
                .HasData(
                    new CompanyBranches
                    {
                        Id = -8,
                        Name = "C5_B1",
                        CompanyId = company5.Id,
                    }
                );
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
                optionsBuilder.UseSqlite(connectionString);
            }
        }
        #endregion
    }
}
