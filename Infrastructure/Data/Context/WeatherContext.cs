using System.Linq;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context
{
    public class WeatherContext : DbContext
    {
        private DbSet<CityEntity> Cities { get; set; }
        private DbSet<DailyWeatherForecastEntity> WeatherForecasts { get; set; }
        private DbSet<PrecipitationSpanEntity> PrecipitationSpans { get; set; }

        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {
        }

        public bool IsInitializedByDefault => Cities.Any();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<CityEntity>(Configure);
            modelBuilder.Entity<DailyWeatherForecastEntity>(Configure);
            modelBuilder.Entity<PrecipitationSpanEntity>(Configure);
        }
        
        private void Configure(EntityTypeBuilder<CityEntity> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            
            entity.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
            
            entity.Property(p => p.Country)
                .HasMaxLength(2)
                .IsRequired();
        }
        
        private void Configure(EntityTypeBuilder<DailyWeatherForecastEntity> entity)
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.PrecipitationSpan)
                .WithOne();
            
            entity.HasOne(d => d.City)
                .WithOne();
        }

        private void Configure(EntityTypeBuilder<PrecipitationSpanEntity> entity)
        {
            entity.HasKey(e => e.Id);
        }
    }
}