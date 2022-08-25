using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WomenEmpowermentAPI.models
{
    public partial class WomenEmpowermentContext : DbContext
    {
        public WomenEmpowermentContext()
        {
        }

        public WomenEmpowermentContext(DbContextOptions<WomenEmpowermentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Ngo> Ngos { get; set; }
        public virtual DbSet<NgoApplication> NgoApplications { get; set; }
        public virtual DbSet<NgoContactDetail> NgoContactDetails { get; set; }
        public virtual DbSet<NgoCourse> NgoCourses { get; set; }
        public virtual DbSet<NgoDetail> NgoDetails { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<TraineeAddressDetail> TraineeAddressDetails { get; set; }
        public virtual DbSet<TraineeApplication> TraineeApplications { get; set; }
        public virtual DbSet<TraineeFamilyDetail> TraineeFamilyDetails { get; set; }
        public virtual DbSet<TraineeNgoCourse> TraineeNgoCourses { get; set; }
        public virtual DbSet<TraineePersonalDetail> TraineePersonalDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.\\sqlexpress;database=WomenEmpowerment;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.HasIndex(e => e.Username, "UQ__Admin__536C85E4539D4389")
                    .IsUnique();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ngo>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Ngos__536C85E494572CBF")
                    .IsUnique();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NgoApplication>(entity =>
            {
                entity.ToTable("NgoApplication");

                entity.Property(e => e.ActionDate).HasColumnType("date");

                entity.Property(e => e.RequestDate).HasColumnType("date");

                entity.HasOne(d => d.Ngo)
                    .WithMany(p => p.NgoApplications)
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__NgoApplic__NgoId__5535A963");
            });

            modelBuilder.Entity<NgoContactDetail>(entity =>
            {
                entity.HasKey(e => e.NgoContactDetailsId)
                    .HasName("PK__NgoConta__8CF9F27B7510C5E6");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ngo)
                    .WithMany(p => p.NgoContactDetails)
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__NgoContac__NgoId__52593CB8");
            });

            modelBuilder.Entity<NgoCourse>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.NgoCoursesId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__NgoCourse__Cours__5812160E");

                entity.HasOne(d => d.Ngo)
                    .WithMany()
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__NgoCourse__NgoId__571DF1D5");
            });

            modelBuilder.Entity<NgoDetail>(entity =>
            {
                entity.HasKey(e => e.NgoDetailsId)
                    .HasName("PK__NgoDetai__932D6F92235AF505");

                entity.HasIndex(e => e.OrganisationName, "UQ__NgoDetai__1B62E33D90BDC262")
                    .IsUnique();

                entity.HasIndex(e => e.Pan, "UQ__NgoDetai__C57098056609D036")
                    .IsUnique();

                entity.Property(e => e.ChairmanName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OrganisationName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SecretaryName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ngo)
                    .WithMany(p => p.NgoDetails)
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__NgoDetail__NgoId__4F7CD00D");
            });

            modelBuilder.Entity<Trainee>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Trainees__536C85E4617EA207")
                    .IsUnique();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TraineeAddressDetail>(entity =>
            {
                entity.HasKey(e => e.AddressDetailsId)
                    .HasName("PK__TraineeA__FE78D90B02B83D8B");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeAddressDetails)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK__TraineeAd__Train__4316F928");
            });

            modelBuilder.Entity<TraineeApplication>(entity =>
            {
                entity.ToTable("TraineeApplication");

                entity.Property(e => e.ActionDate).HasColumnType("date");

                entity.Property(e => e.RequestDate).HasColumnType("date");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeApplications)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK__TraineeAp__Train__45F365D3");
            });

            modelBuilder.Entity<TraineeFamilyDetail>(entity =>
            {
                entity.HasKey(e => e.FamilyDetailsId)
                    .HasName("PK__TraineeF__41067C25D17572FD");

                entity.Property(e => e.FatherDesignation)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HusbandName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MotherDesignation)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MotherName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeFamilyDetails)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK__TraineeFa__Train__403A8C7D");
            });

            modelBuilder.Entity<TraineeNgoCourse>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.TraineeNgoCourseId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TraineeNgoCourseID");

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__TraineeNg__Cours__5BE2A6F2");

                entity.HasOne(d => d.Ngo)
                    .WithMany()
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__TraineeNg__NgoId__5AEE82B9");

                entity.HasOne(d => d.Trainee)
                    .WithMany()
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK__TraineeNg__Train__59FA5E80");
            });

            modelBuilder.Entity<TraineePersonalDetail>(entity =>
            {
                entity.HasKey(e => e.PersonalDetailsId)
                    .HasName("PK__TraineeP__63B46EE6B180C819");

                entity.HasIndex(e => e.EmailId, "UQ__TraineeP__7ED91ACEB29FD4E2")
                    .IsUnique();

                entity.HasIndex(e => e.Aadhaar, "UQ__TraineeP__C4B33369772F2848")
                    .IsUnique();

                entity.HasIndex(e => e.Pan, "UQ__TraineeP__C5709805E8302D8F")
                    .IsUnique();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DisabilityType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Religion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineePersonalDetails)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK__TraineePe__Train__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
