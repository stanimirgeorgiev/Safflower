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

            modelBuilder.Entity<Group>()
                .HasRequired(a => a.Wall);

            modelBuilder.Entity<User>()
                .HasRequired(a => a.Wall);


            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("LeftFriendId");
                    m.MapRightKey("RightFriendId");
                    m.ToTable("Friends");
                });

            //modelBuilder.Entity<Wall>()
            //    .HasRequired(u => u.User)
            //    //.WithOptional(w => w.Wall);
            //    .WithMany()
            //    .HasForeignKey(u => u.AspNetUserId);

            //modelBuilder.Entity<User>()
            //    .HasRequired(u => u.Wall)
            //    .WithOptional(w => w.User)
            //    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public static FaceBookDb Create()
        {
            return new FaceBookDb();
        }
    }
    
}