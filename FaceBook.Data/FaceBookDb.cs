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
    }
}