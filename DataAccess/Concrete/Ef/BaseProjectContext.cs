using Core.Entities.Concrete;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class BaseProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DBMyCvdb;Trusted_Connection=true; TrustServerCertificate=True");
        }

       


        public DbSet<Message> Messages { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Employment> Employements { get; set; }
      
        public DbSet<Product> Products { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Certificate> Certificates { get; set; }

        public DbSet<Skill> Skills { get; set; }

       
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<AboutImage> AboutImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
      
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }





       
       
      

        

        

     



    }
}
