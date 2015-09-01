using System.Data.Entity.ModelConfiguration.Conventions;
using FaceBook.Data.Migrations;
using FaceBook.Models;

namespace FaceBook.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class FaceBookDb : IdentityDbContext<User>
    {
        public FaceBookDb()
            : base("FaceBookDb.Entity")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FaceBookDb, Configuration>());
        }
        public DbSet<Wall> Walls { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                .HasRequired(u => u.Wall)
                .WithRequiredPrincipal(w => w.User)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public static FaceBookDb Create()
        {
            return new FaceBookDb();
        }
    }
    
}