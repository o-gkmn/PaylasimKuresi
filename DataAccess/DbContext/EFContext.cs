using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.DbContext
{
    public class EFContext(DbContextOptions options) : IdentityDbContext<User, Role, Guid>(options)
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<CommunityUser> CommunityUsers { get; set; }
        public DbSet<Dm> Dms { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<ImagePost> ImagePosts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<TextPost> TextPosts { get; set; }
        public DbSet<VideoPost> VideoPosts { get; set; }
        public DbSet<VoicePost> VoicePosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne(p => p.ImagePost)
                    .WithOne()
                    .HasForeignKey<Post>(oi => oi.ImagePostID);
                entity.HasOne(p => p.VideoPost)
                    .WithOne()
                    .HasForeignKey<Post>(p => p.VideoPostID);
                entity.HasOne(p => p.TextPost)
                    .WithOne()
                    .HasForeignKey<Post>(p => p.TextPostID);
                entity.HasOne(p => p.VoicePost)
                    .WithOne()
                    .HasForeignKey<Post>(oi => oi.VoicePostID);
                entity.HasOne(p => p.User)
                    .WithMany(oi => oi.Posts)
                    .HasForeignKey(ip => ip.UserID)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Community)
                      .WithMany(oi => oi.Posts)
                      .HasForeignKey(ip => ip.CommunityID)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(p => p.Comments)
                    .WithOne(oi => oi.Post)
                    .HasForeignKey(ip => ip.PostID);
                entity.HasMany(p => p.UsersWhoLike);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(p => p.Comments);
                entity.HasMany(p => p.CommentLikes);
                entity.HasMany(p => p.MemberCommunities);
                entity.HasMany(p => p.FounderOfCommunity);
                entity.HasMany(p => p.Senders);
                entity.HasMany(p => p.Receivers);
                entity.HasMany(p => p.Followers);
                entity.HasMany(p => p.Following);
                entity.HasMany(p => p.FounderOfGroups);
                entity.HasMany(p => p.MemberGroups);
                entity.HasMany(p => p.LikedPosts);
                entity.HasMany(p => p.Posts);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasMany(p => p.CommentLikes);
                entity.HasOne(p => p.Post)
                    .WithMany(oi => oi.Comments)
                    .HasForeignKey(ip => ip.PostID)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.User)
                    .WithMany(oi => oi.Comments)
                    .HasForeignKey(ip => ip.UserID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CommentLike>(entity =>
            {
                entity.HasOne(p => p.Comment)
                    .WithMany(oi => oi.CommentLikes)
                    .HasForeignKey(ip => ip.CommentID);
                entity.HasOne(p => p.User)
                    .WithMany(oi => oi.CommentLikes)
                    .HasForeignKey(ip => ip.UserID);
                modelBuilder.Entity<CommentLike>()
                    .HasIndex(cl => new { cl.UserID, cl.CommentID })
                    .IsUnique();
            });

            modelBuilder.Entity<CommunityUser>(entity =>
            {
                entity.HasOne(p => p.Member)
                    .WithMany(oi => oi.MemberCommunities)
                    .HasForeignKey(ip => ip.UserID);
                entity.HasOne(p => p.Community)
                    .WithMany(oi => oi.CommunityUsers)
                    .HasForeignKey(ip => ip.CommunityID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Dm>(entity =>
            {
                entity.HasOne(p => p.Sender)
                    .WithMany(oi => oi.Senders)
                    .HasForeignKey(ip => ip.SenderID)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Receiver)
                    .WithMany(oi => oi.Receivers)
                    .HasForeignKey(ip => ip.ReceiverID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.HasOne(p => p.FollowingPerson)
                    .WithMany(oi => oi.Following)
                    .HasForeignKey(ip => ip.FollowingPersonID)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.FollowedPerson)
                    .WithMany(oi => oi.Followers)
                    .HasForeignKey(ip => ip.FollowedPersonID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasOne(p => p.Founder)
                    .WithMany(oi => oi.FounderOfGroups)
                    .HasForeignKey(ip => ip.FounderID);
                entity.HasMany(p => p.Members);
            });

            modelBuilder.Entity<GroupUser>(entity =>
            {
                entity.HasOne(p => p.Member)
                    .WithMany(oi => oi.MemberGroups)
                    .HasForeignKey(ip => ip.UserID);
                entity.HasOne(p => p.Group)
                    .WithMany(oi => oi.Members)
                    .HasForeignKey(ip => ip.GroupID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PostLike>(entity =>
            {
                entity.HasOne(p => p.User)
                    .WithMany(oi => oi.LikedPosts)
                    .HasForeignKey(ip => ip.UserID);
                entity.HasOne(p => p.Post)
                    .WithMany(oi => oi.UsersWhoLike)
                    .HasForeignKey(ip => ip.PostID);
                modelBuilder.Entity<PostLike>()
                    .HasIndex(pl => new { pl.UserID, pl.PostID })
                    .IsUnique();

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
