using DigitalAccelerator.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccelerator.API.DbContexts
{
    public class NoteContext : DbContext
    {
        public DbSet<Note> Notes { get; set; } = null!;
        public NoteContext(DbContextOptions<NoteContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Explicity sets Id property to be a primary key
            modelBuilder.Entity<Note>().HasKey(t => t.Id);
            //Generates Id value when a new record is added to the table
            modelBuilder.Entity<Note>().Property(t => t.Id).ValueGeneratedOnAdd();

            //Specifies the max length of Author propoerty
            modelBuilder.Entity<Note>().Property(t => t.Author).HasMaxLength(50);
            //Configures the Author property to be required
            modelBuilder.Entity<Note>().Property(t => t.Author).IsRequired();

            //Specifies the max length of Content property
            modelBuilder.Entity<Note>().Property(t => t.Content).HasMaxLength(200);

            //modelBuilder.Entity<Note>().HasData(
            //    new Note("Megan", "Test Note Content 1") {},
            //    new Note("Taylor", "Test Note Content 2") {},
            //    new Note("Benito", "Test Note Content 3") {},
            //    new Note("Tim", "Test Note Content 4") {}
            //    );

            base.OnModelCreating(modelBuilder);
        }

    }
}
