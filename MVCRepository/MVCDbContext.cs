using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MVCRepository
{
    class MVCDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<BranchManager> BranchManagers { get; set; }
        public DbSet<LoanOfficer> LoanOfficers { get; set; }
        public DbSet<TOfficer> TOfficers { get; set; }
        public DbSet<MDirector> MDirectors { get; set; }
        public DbSet<HROfficer> HROfficers { get; set; }
        public DbSet<Logininfo> Logininfos { get; set; }
        public DbSet<LInfo> Linfos { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CheckBook> CheckBooks { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
}
