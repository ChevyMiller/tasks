using lesson3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace lesson3.Repositories
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext()
        {
        }
        public TasksDbContext(DbContextOptions<TasksDbContext> options)
          : base(options)
        {
        }
        public async Task<List<Tasks>> GetTaskByUserAsync(int userId)
        {
            return await Tasks.FromSqlRaw("EXEC GetTaskByUser @userId = {0}", userId).ToListAsync();
        }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Projects> Projects { get; set; }

        public virtual DbSet<Attachments> AttachmentsTasks { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //modelBuilder.Entity<Tasks>()
        //.HasMany(b => b.Id)
        //.WithMany(a => a.Tasks)
        //.HasForeignKey(b => b.UserId);

        //modelBuilder.Entity<Tasks>()
        //    .HasOne(b => b.Publisher)
        //    .WithMany(p => p.Books)
        //    .HasForeignKey(b => b.PublisherId);

        //modelBuilder.Entity<Tasks>()
        //    .HasOne(b => b.Category)
        //    .WithMany(c => c.Books)
        //    .HasForeignKey(b => b.CategoryId);
        //}

    }
    }

