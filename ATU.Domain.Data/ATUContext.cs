using System.Data.Entity;
using ATU.Domain.Model;

namespace ATU.Domain.Data
{
    public class ATUContext : DbContext
    {
        static ATUContext()
        {
            var _ = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public ATUContext() : base("ATU.Data") { }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}