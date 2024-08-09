using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

            // Ako imate specifične konfiguracije za Paket, dodajte ih ovde
            builder.Entity<Paket>()
                .HasKey(p => p.Id);

            // Ako Paket ima relacije sa drugim entitetima, konfigurišite ih ovde
            // Na primer, ako Paket ima relaciju sa Destinacija:
            // builder.Entity<Paket>()
            //     .HasOne(p => p.Destinacija)
            //     .WithMany(d => d.Paketi)
            //     .HasForeignKey(p => p.DestinacijaId);
        }

        public DbSet<Destinacija> Destinacije { get; set; }
        public DbSet<KorisnikDestinacija> KorisnikDestinacije { get; set; }
        public DbSet<Komentar> Komentari { get; set; }
        public DbSet<Paket> Paketi { get; set; }
    }
}
