using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TravelApp.Models;

namespace TravelApp.Data
{
    public class AppDbContext : IdentityDbContext<Korisnik, AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }



     


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<KorisnikDestinacija>()
                .HasKey(kd => kd.Id);

            builder.Entity<KorisnikDestinacija>()
                .HasOne(kd => kd.Korisnik)
                .WithMany(k => k.KorisnikDestinacije)
                .HasForeignKey(kd => kd.KorisnikId);

            builder.Entity<KorisnikDestinacija>()
                .HasOne(kd => kd.Destinacija)
                .WithMany(d => d.korisnikDestinacijas)
                .HasForeignKey(kd => kd.DestinacijaId);

            builder.Entity<Komentar>()
                .HasKey(k => k.Id);

            builder.Entity<Komentar>()
                .HasOne(k => k.Korisnik)
                .WithMany(k => k.Komentari)
                .HasForeignKey(k => k.KorisnikId);

            builder.Entity<Komentar>()
                .HasOne(k => k.Destinacija)
                .WithMany(d => d.Komentari)
                .HasForeignKey(k => k.DestinacijaId);

            // Konfiguracija za Paket
            builder.Entity<Paket>()
                .HasKey(p => p.Id);

           

            // Konfiguracija za DestinacijaPaketa
            builder.Entity<DestinacijaPaketa>()
                .HasKey(dp => dp.Id);

            builder.Entity<Paket>()
                .HasMany(p => p.DestinacijePaketa)
                .WithOne(dp => dp.Paket)
                .HasForeignKey(dp => dp.PaketId);

            builder.Entity<DestinacijaPaketa>()
                .HasOne(dp => dp.Paket)
                .WithMany(p => p.DestinacijePaketa)
                .HasForeignKey(dp => dp.PaketId);


            builder.Entity<List>()
    .HasOne(l => l.Paket)
    .WithMany(p => p.List)
    .HasForeignKey(l => l.PaketId)
    .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Destinacija> Destinacije { get; set; }
        public DbSet<KorisnikDestinacija> KorisnikDestinacije { get; set; }
        public DbSet<Komentar> Komentari { get; set; }
        public DbSet<Paket> Paketi { get; set; }
        public DbSet<DestinacijaPaketa> DestinacijaPaketa { get; set; }


        public DbSet<List> TravelLists { get; set; }
        public DbSet<List> Lists { get; set; }  // Dodajte ovo



    }
}
