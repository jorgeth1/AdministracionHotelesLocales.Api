using AdministracionHotelesLocales.Domain.Entities;
using AdministracionHotelesLocales.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace AdministracionHotelesLocales.Infra.Contexts
{
    public class AdministracionHotelesLocalesContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AdministracionHotelesLocalesContext(DbContextOptions<AdministracionHotelesLocalesContext> dbContextOptions,
            IConfiguration configuration) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<AgenciaHotel> AgenciasHoteles { get; set; }
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Huesped> Huespedes { get; set; }
        public DbSet<ContactoEmergencia> ContactosEmergencia { get; set; }
        public DbSet<Viajero> Viajeros { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.HasDefaultSchema(_configuration.GetValue<string>("SchemaName"));


            modelBuilder.Entity<Habitacion>()
                .Property(habitacion => habitacion.Tipo)
                .HasConversion(
                    tipoHabitacion => tipoHabitacion.ToString(),
                    value => (TipoHabitacion)Enum.Parse(typeof(TipoHabitacion), value));

            modelBuilder.Entity<Viajero>()
                .Property(viajero => viajero.TipoDocumento)
                .HasConversion(
                    viajero => viajero.ToString(),
                    value => (TipoDocumento)Enum.Parse(typeof(TipoDocumento), value));

            modelBuilder.Entity<Viajero>()
                .Property(viajero => viajero.Genero)
                .HasConversion(
                    viajero => viajero.ToString(),
                    value => (Genero)Enum.Parse(typeof(Genero), value));

            modelBuilder.Entity<Huesped>()
                .Property(huesped => huesped.TipoDocumento)
                .HasConversion(
                    huesped => huesped.ToString(),
                    value => (TipoDocumento)Enum.Parse(typeof(TipoDocumento), value));

            modelBuilder.Entity<Huesped>()
                .Property(huesped => huesped.Genero)
                .HasConversion(
                    huesped => huesped.ToString(),
                    value => (Genero)Enum.Parse(typeof(Genero), value));

            modelBuilder.Entity<Agencia>()
                .HasMany(agencia => agencia.HotelesPreferidos)
                .WithOne(agenciaHotel => agenciaHotel.Agencia)
                .HasForeignKey(agenciaHotel => agenciaHotel.AgenciaId);

            modelBuilder.Entity<AgenciaHotel>()
                .HasOne(agenciaHotel => agenciaHotel.Agencia)
                .WithMany(agencia => agencia.HotelesPreferidos)
                .HasForeignKey(agenciaHotel => agenciaHotel.AgenciaId);

            modelBuilder.Entity<AgenciaHotel>()
                .HasOne(agenciaHotel => agenciaHotel.Hotel)
                .WithMany(hotel => hotel.AgenciasHoteles)
                .HasForeignKey(agenciaHotel => agenciaHotel.HotelId);

            modelBuilder.Entity<Hotel>()
                .HasMany(hotel => hotel.AgenciasHoteles)
                .WithOne(agenciaHotel => agenciaHotel.Hotel)
                .HasForeignKey(agenciaHotel => agenciaHotel.HotelId);

            modelBuilder.Entity<Hotel>()
                .HasMany(hotel => hotel.Habitaciones)
                .WithOne(habitacion => habitacion.Hotel)
                .HasForeignKey(hotel => hotel.HotelId);

            modelBuilder.Entity<Habitacion>()
                .HasMany(habitacion => habitacion.Reservas)
                .WithOne(reserva => reserva.Habitacion)
                .HasForeignKey(reserva => reserva.HabitacionId);

            modelBuilder.Entity<Reserva>()
                .HasOne(reserva => reserva.Habitacion)
                .WithMany(huesped => huesped.Reservas)
                .HasForeignKey(reserva => reserva.HabitacionId);

            modelBuilder.Entity<Viajero>()
                .HasMany(reserva => reserva.Reservas)
                .WithOne(reserva => reserva.Viajero)
                .HasForeignKey(reserva => reserva.ViajeroId);

            modelBuilder.Entity<Reserva>()
                .HasOne(reserva => reserva.Viajero)
                .WithMany(viajero => viajero.Reservas)
                .HasForeignKey(reserva => reserva.ViajeroId);

            modelBuilder.Entity<Huesped>()
                .HasOne(huesped => huesped.Reserva)
                .WithMany(reserva => reserva.Huespedes)
                .HasForeignKey(huesped => huesped.ReservaId);

            modelBuilder.Entity<Reserva>()
                .HasMany(reserva => reserva.Huespedes)
                .WithOne(huesped => huesped.Reserva)
                .HasForeignKey(reserva => reserva.ReservaId);

            modelBuilder.Entity<Reserva>()
                .HasOne(reserva => reserva.ContactoEmergencia)
                .WithOne(contactoEmergencia => contactoEmergencia.Reserva)
                .HasForeignKey<ContactoEmergencia>(contactoEmergencia => contactoEmergencia.ReservaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
