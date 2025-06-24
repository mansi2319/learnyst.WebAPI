using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using learnyst.Core.Entities;

namespace learnyst.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<batch> batches { get; set; }

    public virtual DbSet<bundle> bundles { get; set; }

    public virtual DbSet<couponcode> couponcodes { get; set; }

    public virtual DbSet<course> courses { get; set; }

    public virtual DbSet<invoice> invoices { get; set; }

    public virtual DbSet<lesson> lessons { get; set; }

    public virtual DbSet<liveclass> liveclasses { get; set; }

    public virtual DbSet<paymentgateway> paymentgateways { get; set; }

    public virtual DbSet<paymenttransaction> paymenttransactions { get; set; }

    public virtual DbSet<referralcode> referralcodes { get; set; }

    public virtual DbSet<section> sections { get; set; }

    public virtual DbSet<session> sessions { get; set; }

    public virtual DbSet<subscription> subscriptions { get; set; }

    public virtual DbSet<subscriptionitem> subscriptionitems { get; set; }

    public virtual DbSet<user> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=elearning;user=root;password=sasa", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<batch>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.course_id, "course_id");

            entity.HasIndex(e => e.instructor_id, "instructor_id");

            entity.Property(e => e.price).HasPrecision(10, 2);
            entity.Property(e => e.title).HasMaxLength(255);

            entity.HasOne(d => d.course).WithMany(p => p.batches)
                .HasForeignKey(d => d.course_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("batches_ibfk_1");

            entity.HasOne(d => d.instructor).WithMany(p => p.batches)
                .HasForeignKey(d => d.instructor_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("batches_ibfk_2");
        });

        modelBuilder.Entity<bundle>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.Property(e => e.course_ids).HasColumnType("json");
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.price).HasPrecision(10, 2);
            entity.Property(e => e.title).HasMaxLength(255);
            entity.Property(e => e.updated_at)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<couponcode>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.coupon_code, "coupon_code").IsUnique();

            entity.Property(e => e.coupon_code).HasMaxLength(20);
            entity.Property(e => e.is_active).HasDefaultValueSql("'1'");
            entity.Property(e => e.max_usage_per_user).HasDefaultValueSql("'1'");
            entity.Property(e => e.max_user).HasDefaultValueSql("'0'");
            entity.Property(e => e.min_subscription_price)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.type).HasColumnType("enum('Flat','Percentage')");
            entity.Property(e => e.user_used).HasDefaultValueSql("'0'");
            entity.Property(e => e.valid_from).HasColumnType("datetime");
            entity.Property(e => e.valid_till).HasColumnType("datetime");
            entity.Property(e => e.value).HasPrecision(5, 2);
        });

        modelBuilder.Entity<course>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.instructor_id, "instructor_id");

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.price).HasPrecision(10, 2);
            entity.Property(e => e.status).HasColumnType("enum('draft','published','unpublished')");
            entity.Property(e => e.title).HasMaxLength(255);
            entity.Property(e => e.updated_at)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.visibility).HasColumnType("enum('public','private')");

            entity.HasOne(d => d.instructor).WithMany(p => p.courses)
                .HasForeignKey(d => d.instructor_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("courses_ibfk_1");
        });

        modelBuilder.Entity<invoice>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.subscription_id, "subscription_id");

            entity.Property(e => e.billing_info).HasColumnType("text");
            entity.Property(e => e.invoice_number).HasMaxLength(100);
            entity.Property(e => e.issued_at).HasColumnType("datetime");
            entity.Property(e => e.status)
                .HasDefaultValueSql("'issued'")
                .HasColumnType("enum('issued','cancelled','refunded')");
            entity.Property(e => e.total_amount).HasPrecision(10, 2);

            entity.HasOne(d => d.subscription).WithMany(p => p.invoices)
                .HasForeignKey(d => d.subscription_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoices_ibfk_1");
        });

        modelBuilder.Entity<lesson>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.section_id, "section_id");

            entity.Property(e => e.content_url).HasColumnType("text");
            entity.Property(e => e.title).HasMaxLength(255);
            entity.Property(e => e.type).HasColumnType("enum('video','pdf','audio','slides','live','article','scorm','quiz','assignment','code-challenge')");

            entity.HasOne(d => d.section).WithMany(p => p.lessons)
                .HasForeignKey(d => d.section_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("lessons_ibfk_1");
        });

        modelBuilder.Entity<liveclass>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.course_id, "course_id");

            entity.HasIndex(e => e.instructor_id, "instructor_id");

            entity.HasIndex(e => e.lessons_id, "lessons_id");

            entity.HasIndex(e => e.section_id, "section_id");

            entity.Property(e => e.end_time).HasColumnType("datetime");
            entity.Property(e => e.meeting_url).HasColumnType("text");
            entity.Property(e => e.recording_url).HasColumnType("text");
            entity.Property(e => e.start_time).HasColumnType("datetime");
            entity.Property(e => e.title).HasMaxLength(255);

            entity.HasOne(d => d.course).WithMany(p => p.liveclasses)
                .HasForeignKey(d => d.course_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("liveclasses_ibfk_1");

            entity.HasOne(d => d.instructor).WithMany(p => p.liveclasses)
                .HasForeignKey(d => d.instructor_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("liveclasses_ibfk_4");

            entity.HasOne(d => d.lessons).WithMany(p => p.liveclasses)
                .HasForeignKey(d => d.lessons_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("liveclasses_ibfk_3");

            entity.HasOne(d => d.section).WithMany(p => p.liveclasses)
                .HasForeignKey(d => d.section_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("liveclasses_ibfk_2");
        });

        modelBuilder.Entity<paymentgateway>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.Property(e => e.config_data).HasColumnType("text");
            entity.Property(e => e.is_active).HasDefaultValueSql("'1'");
            entity.Property(e => e.name).HasMaxLength(50);
        });

        modelBuilder.Entity<paymenttransaction>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("paymenttransaction");

            entity.HasIndex(e => e.payment_gateway_id, "payment_gateway_id");

            entity.HasIndex(e => e.subscription_id, "subscription_id");

            entity.Property(e => e.amount).HasPrecision(10, 2);
            entity.Property(e => e.gateway_transaction_id).HasMaxLength(255);
            entity.Property(e => e.payment_method).HasMaxLength(255);
            entity.Property(e => e.status)
                .HasDefaultValueSql("'pending'")
                .HasColumnType("enum('pending','completed','failed')");
            entity.Property(e => e.transaction_date).HasColumnType("datetime");

            entity.HasOne(d => d.payment_gateway).WithMany(p => p.paymenttransactions)
                .HasForeignKey(d => d.payment_gateway_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paymenttransaction_ibfk_2");

            entity.HasOne(d => d.subscription).WithMany(p => p.paymenttransactions)
                .HasForeignKey(d => d.subscription_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paymenttransaction_ibfk_1");
        });

        modelBuilder.Entity<referralcode>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.coupon_id, "coupon_id");

            entity.HasIndex(e => e.referred_user_id, "referred_user_id");

            entity.HasOne(d => d.coupon).WithMany(p => p.referralcodes)
                .HasForeignKey(d => d.coupon_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("referralcodes_ibfk_1");

            entity.HasOne(d => d.referred_user).WithMany(p => p.referralcodes)
                .HasForeignKey(d => d.referred_user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("referralcodes_ibfk_2");
        });

        modelBuilder.Entity<section>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.course_id, "course_id");

            entity.Property(e => e.title).HasMaxLength(255);

            entity.HasOne(d => d.course).WithMany(p => p.sections)
                .HasForeignKey(d => d.course_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sections_ibfk_1");
        });

        modelBuilder.Entity<session>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.user_id, "user_id");

            entity.Property(e => e.device_info).HasColumnType("text");
            entity.Property(e => e.ip_address).HasMaxLength(45);
            entity.Property(e => e.login_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.logout_at).HasColumnType("datetime");
            entity.Property(e => e.token).HasColumnType("text");

            entity.HasOne(d => d.user).WithMany(p => p.sessions)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sessions_ibfk_1");
        });

        modelBuilder.Entity<subscription>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("subscription");

            entity.HasIndex(e => e.couplon_code, "couplon_code");

            entity.HasIndex(e => e.user_id, "user_id");

            entity.Property(e => e.couplon_code).HasMaxLength(20);
            entity.Property(e => e.discount_amount)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.status)
                .HasDefaultValueSql("'pending'")
                .HasColumnType("enum('pending','completed','failed')");
            entity.Property(e => e.subscription_date).HasColumnType("datetime");
            entity.Property(e => e.total_amount).HasPrecision(10, 2);

            entity.HasOne(d => d.couplon_codeNavigation).WithMany(p => p.subscriptions)
                .HasPrincipalKey(p => p.coupon_code)
                .HasForeignKey(d => d.couplon_code)
                .HasConstraintName("subscription_ibfk_2");

            entity.HasOne(d => d.user).WithMany(p => p.subscriptions)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subscription_ibfk_1");
        });

        modelBuilder.Entity<subscriptionitem>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.ToTable("subscriptionitem");

            entity.HasIndex(e => e.subscription_id, "subscription_id");

            entity.Property(e => e.discount)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.item_type).HasColumnType("enum('Batch','Bundle','Course','TestSeries')");
            entity.Property(e => e.price).HasPrecision(10, 2);

            entity.HasOne(d => d.subscription).WithMany(p => p.subscriptionitems)
                .HasForeignKey(d => d.subscription_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subscriptionitem_ibfk_1");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.email, "email").IsUnique();

            entity.HasIndex(e => e.mobile_number, "mobile_number").IsUnique();

            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.mobile_number).HasMaxLength(15);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.password).HasColumnType("text");
            entity.Property(e => e.profile_image_url).HasColumnType("text");
            entity.Property(e => e.role).HasColumnType("enum('Admin','Instructor','Learner')");
            entity.Property(e => e.signup_date)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.updated_at)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
