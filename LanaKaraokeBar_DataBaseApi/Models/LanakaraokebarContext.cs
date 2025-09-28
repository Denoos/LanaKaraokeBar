using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace LanaKaraokeBar_DataBaseApi.Models;

public partial class LanaKaraokeBarContext : DbContext
{
    public LanaKaraokeBarContext()
    {
    }

    public LanaKaraokeBarContext(DbContextOptions<LanaKaraokeBarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Paymenttype> Paymenttypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productslist> Productslists { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Reporttype> Reporttypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Sell> Sells { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;user=root;database=LanaKaraokeBar", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.15-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("authors")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.NickName).HasMaxLength(255);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bookings")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.IdRoom, "FK_bookings_rooms_Id");

            entity.HasIndex(e => e.IdUser, "FK_bookings_users_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.HoursCount)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)");
            entity.Property(e => e.IdRate)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Rate");
            entity.Property(e => e.IdRoom)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Room");
            entity.Property(e => e.IdUser)
                .HasColumnType("int(11)")
                .HasColumnName("Id_User");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("'0001-01-01 00:00:00'")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.IdRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bookings_rooms_Id");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bookings_users_Id");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("genres")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("orders")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.IdBooking, "FK_orders_bookings_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Cost).HasPrecision(19, 2);
            entity.Property(e => e.IdBooking)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Booking");

            entity.HasOne(d => d.IdBookingNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdBooking)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_orders_bookings_Id");
        });

        modelBuilder.Entity<Paymenttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("paymenttypes")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("products")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Cost).HasPrecision(19, 2);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Productslist>(entity =>
        {
            entity.HasKey(e => new { e.IdOrder, e.IdProduct })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("productslists")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.IdProduct, "FK_prosuctslists_products_Id");

            entity.Property(e => e.IdOrder)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Order");
            entity.Property(e => e.IdProduct)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Product");
            entity.Property(e => e.ProductCount)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Productslists)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_prosuctslists_orders_Id");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Productslists)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_prosuctslists_products_Id");
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("rates")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("reports")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.IdReportType, "FK_reports_reporttypes_Id");

            entity.HasIndex(e => e.IdUser, "FK_reports_users_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdReportType)
                .HasColumnType("int(11)")
                .HasColumnName("Id_ReportType");
            entity.Property(e => e.IdUser)
                .HasColumnType("int(11)")
                .HasColumnName("Id_User");
            entity.Property(e => e.Path).HasMaxLength(255);
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("'0001-01-01 00:00:00'")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdReportTypeNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdReportType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reports_reporttypes_Id");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reports_users_Id");
        });

        modelBuilder.Entity<Reporttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("reporttypes")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("roles")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("rooms")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.IdRate, "FK_rooms_rates_Id");

            entity.HasIndex(e => e.IdStatus, "FK_rooms_statuses_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdRate)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Rate");
            entity.Property(e => e.IdStatus)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Status");
            entity.Property(e => e.MaxPeopleCount).HasColumnType("int(11)");

            entity.HasOne(d => d.IdRateNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.IdRate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_rooms_rates_Id");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_rooms_statuses_Id");
        });

        modelBuilder.Entity<Sell>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sells")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.IdBooking, "FK_sells_bookings_Id");

            entity.HasIndex(e => e.IdPaymenttype, "FK_sells_paymenttypes_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Amount).HasPrecision(8, 2);
            entity.Property(e => e.IdBooking)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Booking");
            entity.Property(e => e.IdPaymenttype)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Paymenttype");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("'0001-01-01 00:00:00'")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdBookingNavigation).WithMany(p => p.Sells)
                .HasForeignKey(d => d.IdBooking)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sells_bookings_Id");

            entity.HasOne(d => d.IdPaymenttypeNavigation).WithMany(p => p.Sells)
                .HasForeignKey(d => d.IdPaymenttype)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sells_paymenttypes_Id");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("songs")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.IdGenre, "FK_songs");

            entity.HasIndex(e => e.IdAuthor, "FK_songs_authors_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdAuthor)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Author");
            entity.Property(e => e.IdGenre)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Genre");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Songs)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_songs_authors_Id");

            entity.HasOne(d => d.IdGenreNavigation).WithMany(p => p.Songs)
                .HasForeignKey(d => d.IdGenre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_songs");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("statuses")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.IdRole, "FK_users_roles_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.BonusesCount).HasColumnType("int(11)");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IdRole)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Role");
            entity.Property(e => e.IsBlocked)
                .HasColumnType("tinyint(4)")
                .HasColumnName("Is_Blocked");
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Patronymic).HasMaxLength(255);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_roles_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
