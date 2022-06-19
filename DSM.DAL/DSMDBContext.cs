using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSM.TABLES.Guide;
using DSM.TABLES.Pepole;
using Microsoft.EntityFrameworkCore;

namespace DSM.DAL
{
    public class DSMDBContext:DbContext
    {

        public DSMDBContext(DbContextOptions<DSMDBContext> options):base(options)
        {

        }


        public DSMDBContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasMany(x => x.Createduser).WithOne(x => x.userCreated).HasForeignKey(x => x.AddedBy);
            //modelBuilder.Entity<User>().HasMany(x => x.Modifideduser).WithOne(x => x.userModifided).HasForeignKey(x => x.ModifiedBy);
            //modelBuilder.Entity<User>().HasMany(x => x.Deleteeduser).WithOne(x => x.userDeleteed).HasForeignKey(x => x.DeletedBY);

            //modelBuilder.Entity<User>().HasMany(x =>x.Createduser).WithRequired().HasForeignKey(x => x.AddedBy);
           
            //modelBuilder.Entity<User>().HasMany(x => x.BranchModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            //modelBuilder.Entity<User>().HasMany(x => x.BranchDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);
        }
        public DbSet<User> users { get; set; }
        public DbSet<Branch> branches { get; set; }
        public DbSet<ImagesScreen> screens { get; set; }
        
       



    }
}
