using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models;

public partial class PrjprnContext : DbContext
{
    public PrjprnContext()
    {
    }

    public PrjprnContext(DbContextOptions<PrjprnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Subjecttable> Subjecttables { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

    public virtual DbSet<Titlecode> Titlecodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(ConnectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Idcauhoi).HasName("PK__answer__484250D1EAE93BDD");

            entity.ToTable("answer");

            entity.HasIndex(e => new { e.Causo, e.Idmade }, "UC_CaudoMade").IsUnique();

            entity.Property(e => e.Idcauhoi).HasColumnName("idcauhoi");
            entity.Property(e => e.Causo).HasColumnName("causo");
            entity.Property(e => e.Dapan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dapan");
            entity.Property(e => e.Idmade).HasColumnName("idmade");

            entity.HasOne(d => d.IdmadeNavigation).WithMany(p => p.Answers)
                .HasForeignKey(d => d.Idmade)
                .HasConstraintName("FK__answer__idmade__49C3F6B7");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Classid).HasName("PK__class__75743806E40C20A5");

            entity.ToTable("class");

            entity.HasIndex(e => e.Classname, "UQ__class__279D4814E2E2F058").IsUnique();

            entity.Property(e => e.Classid).HasColumnName("classid");
            entity.Property(e => e.Classname)
                .HasMaxLength(255)
                .HasColumnName("classname");
        });

        modelBuilder.Entity<Subjecttable>(entity =>
        {
            entity.HasKey(e => e.Subjectid).HasName("PK__subjectt__ACE1437847A32BB1");

            entity.ToTable("subjecttable");

            entity.HasIndex(e => e.Subjectname, "UQ__subjectt__E8560E88F19E91EA").IsUnique();

            entity.Property(e => e.Subjectid).HasColumnName("subjectid");
            entity.Property(e => e.Subjectname)
                .HasMaxLength(255)
                .HasColumnName("subjectname");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Teacherid).HasName("PK__teacher__98EA44AD2841382E");

            entity.ToTable("teacher");

            entity.Property(e => e.Teacherid).HasColumnName("teacherid");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Teachername)
                .HasMaxLength(255)
                .HasColumnName("teachername");
        });

        modelBuilder.Entity<TeacherSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__teacher___3213E83FF918BC8D");

            entity.ToTable("teacher_subject");

            entity.HasIndex(e => new { e.Teacherid, e.Subjectid }, "UQ__teacher___0224509B5FB1C60F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Subjectid).HasColumnName("subjectid");
            entity.Property(e => e.Teacherid).HasColumnName("teacherid");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.Subjectid)
                .HasConstraintName("FK__teacher_s__subje__412EB0B6");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.Teacherid)
                .HasConstraintName("FK__teacher_s__teach__403A8C7D");
        });

        modelBuilder.Entity<Titlecode>(entity =>
        {
            entity.HasKey(e => e.Titlecodeid).HasName("PK__titlecod__08EB8920ED7AC1CA");

            entity.ToTable("titlecode");

            entity.HasIndex(e => new { e.Classid, e.TeacherSubjectId, e.Titlecodenumber }, "UC_TitleCode").IsUnique();

            entity.Property(e => e.Titlecodeid).HasColumnName("titlecodeid");
            entity.Property(e => e.Classid).HasColumnName("classid");
            entity.Property(e => e.TeacherSubjectId).HasColumnName("teacher_subject_id");
            entity.Property(e => e.Titlecodenumber).HasColumnName("titlecodenumber");
            entity.Property(e => e.Totalmark).HasColumnName("totalmark");

            entity.HasOne(d => d.Class).WithMany(p => p.Titlecodes)
                .HasForeignKey(d => d.Classid)
                .HasConstraintName("FK__titlecode__class__44FF419A");

            entity.HasOne(d => d.TeacherSubject).WithMany(p => p.Titlecodes)
                .HasForeignKey(d => d.TeacherSubjectId)
                .HasConstraintName("FK__titlecode__teach__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
