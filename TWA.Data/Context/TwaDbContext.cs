using Microsoft.EntityFrameworkCore;
using TWA.Core.Entities;

namespace TWA.Data.Context
{
    public class TwaDbContext : DbContext
    {
        public TwaDbContext(DbContextOptions<TwaDbContext> options) : base(options)
        {
        }

        // Tablolarımız
        public DbSet<Village> Villages { get; set; }
        public DbSet<AttackTask> AttackTasks { get; set; }
        public DbSet<ScheduledOperation> ScheduledOperations { get; set; }
        public DbSet<DailyTask> DailyTasks { get; set; }
        public DbSet<BuildingPlan> BuildingPlans { get; set; }
        public DbSet<WorldConfig> WorldConfigs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Köy Ayarları
            modelBuilder.Entity<Village>(entity =>
            {
                // Koordinatlara göre hızlı arama için Index
                entity.HasIndex(e => new { e.CoordinateX, e.CoordinateY }).IsUnique();

                // TroopSet (Value Object) Yapılandırması
                // Köyün Kendi Askeri
                entity.OwnsOne(e => e.OwnedTroops, cb =>
                {
                    cb.Property(p => p.Spear).HasColumnName("Own_Spear");
                    cb.Property(p => p.Sword).HasColumnName("Own_Sword");
                    cb.Property(p => p.Axe).HasColumnName("Own_Axe");
                    cb.Property(p => p.Spy).HasColumnName("Own_Spy");
                    cb.Property(p => p.Light).HasColumnName("Own_Light");
                    cb.Property(p => p.Heavy).HasColumnName("Own_Heavy");
                    cb.Property(p => p.Ram).HasColumnName("Own_Ram");
                    cb.Property(p => p.Catapult).HasColumnName("Own_Catapult");
                    cb.Property(p => p.Knight).HasColumnName("Own_Knight");
                    cb.Property(p => p.Snob).HasColumnName("Own_Snob");
                    cb.Property(p => p.Militia).HasColumnName("Own_Militia");
                });

                // Toplam Asker (Dışarıdakiler dahil)
                entity.OwnsOne(e => e.TotalTroops, cb =>
                {
                    cb.Property(p => p.Spear).HasColumnName("Total_Spear");
                    // ... Diğer kolonlar otomatik map edilir, gerekirse yukarıdaki gibi özelleştirilir
                });
            });

            // 2. Saldırı Görevi Ayarları
            modelBuilder.Entity<AttackTask>(entity =>
            {
                // Asker Seti
                entity.OwnsOne(e => e.Troops);
                
                // İlişkiler
                entity.HasOne(d => d.SourceVillage)
                      .WithMany(p => p.Attacks)
                      .HasForeignKey(d => d.SourceVillageId)
                      .OnDelete(DeleteBehavior.Restrict); // Köy silinirse saldırı logları kalsın
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
