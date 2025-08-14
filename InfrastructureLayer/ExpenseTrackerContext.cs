using System;
using System.Collections.Generic;
using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.InfrastructureLayer;

public partial class ExpenseTrackerContext : DbContext
{
    public ExpenseTrackerContext()
    {
    }

    public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userauthdatum> Userauthdata { get; set; }

    public virtual DbSet<Userauthhistory> Userauthhistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(31)
                .HasColumnName("categoryname");
            entity.Property(e => e.Categorytype)
                .HasMaxLength(1)
                .HasColumnName("categorytype");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Categories)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("category_userid_fkey");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Reportid).HasName("report_pkey");

            entity.ToTable("report");

            entity.Property(e => e.Reportid).HasColumnName("reportid");
            entity.Property(e => e.Finishdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("finishdate");
            entity.Property(e => e.Startdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
            entity.Property(e => e.Totalsum)
                .HasPrecision(12, 2)
                .HasColumnName("totalsum");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Reports)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("report_userid_fkey");

            entity.HasMany(d => d.Transactions).WithMany(p => p.Reports)
                .UsingEntity<Dictionary<string, object>>(
                    "Reporttransaction",
                    r => r.HasOne<Transaction>().WithMany()
                        .HasForeignKey("Transactionid")
                        .HasConstraintName("reporttransaction_transactionid_fkey"),
                    l => l.HasOne<Report>().WithMany()
                        .HasForeignKey("Reportid")
                        .HasConstraintName("reporttransaction_reportid_fkey"),
                    j =>
                    {
                        j.HasKey("Reportid", "Transactionid").HasName("reporttransaction_pkey");
                        j.ToTable("reporttransaction");
                        j.IndexerProperty<int>("Reportid").HasColumnName("reportid");
                        j.IndexerProperty<long>("Transactionid").HasColumnName("transactionid");
                    });
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Transactionid).HasName("transaction_pkey");

            entity.ToTable("transaction");

            entity.Property(e => e.Transactionid).HasColumnName("transactionid");
            entity.Property(e => e.Amount)
                .HasPrecision(12, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Commentary)
                .HasMaxLength(255)
                .HasColumnName("commentary");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .HasColumnName("type");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Category).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("transaction_categoryid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("transaction_userid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("User_pkey");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "User_email_key").IsUnique();

            entity.HasIndex(e => e.Username, "User_username_key").IsUnique();

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Userauthdatum>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("userauthdata_pkey");

            entity.ToTable("userauthdata");

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasColumnName("userid");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .HasColumnName("passwordhash");
            entity.Property(e => e.Refreshtoken)
                .HasMaxLength(255)
                .HasColumnName("refreshtoken");
            entity.Property(e => e.Salt)
                .HasMaxLength(255)
                .HasColumnName("salt");

            entity.HasOne(d => d.User).WithOne(p => p.Userauthdatum)
                .HasForeignKey<Userauthdatum>(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userauthdata_userid_fkey");
        });

        modelBuilder.Entity<Userauthhistory>(entity =>
        {
            entity.HasKey(e => e.Authid).HasName("userauthhistory_pkey");

            entity.ToTable("userauthhistory");

            entity.Property(e => e.Authid).HasColumnName("authid");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(45)
                .HasColumnName("ipaddress");
            entity.Property(e => e.Issuccessful).HasColumnName("issuccessful");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Userauthhistories)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("userauthhistory_userid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
