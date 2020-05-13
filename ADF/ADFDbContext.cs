using ADF.Core.Model.Entities;
using ADF.Core.Model.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ADF
{
    /// <summary>
    /// EF Core steps
    /// 1 Create/Modify domain model
    /// 2 Create migration file
    /// 3 Apply the migration file to Database or generate sql scripts
    /// 
    /// Nuget package
    /// 1 Microsoft.EntityFrameworkCore.SqlServer
    /// 2 Microsoft.EntityFrameworkCore.Tool(For migration)
    /// 3 Execute migration commands in Package manage console
    /// (Add-Migration Drop-Database
        //Get-DbContext
        //Remove-Migration
        //Scaffold-DbContext
        //Script-DbContext
        //Script-Migration
        //Update-Database)
    ///  3.1 Add-migration ADFinitial
    ///  3.2 script-migration(sql scripts)/Update-Database -verbose
    /// </summary>
    public class ADFDbContext : DbContext
    {
        public ADFDbContext(DbContextOptions<ADFDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Fluent apis
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FamilyConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.Entity<Member>()
                .HasOne(m => m.Family).WithMany(m => m.Members).HasForeignKey(f => f.FamilyId);
            //one to one hasone.withone
            //many to many by temp table 
        } 

        public DbSet<Family> Families { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
