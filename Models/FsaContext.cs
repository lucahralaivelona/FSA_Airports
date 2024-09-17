using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FSAproject.Models;

public partial class FsaContext : DbContext
{
    public FsaContext()
    {
    }

    public FsaContext(DbContextOptions<FsaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aerodrome> Aerodromes { get; set; }

    public virtual DbSet<Aircraft> Aircraft { get; set; }

    public virtual DbSet<Compagnie> Compagnies { get; set; }

    public virtual DbSet<GestionnaireAerodrome> GestionnaireAerodromes { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<Vol> Vols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HACKASHI\\SQLEXPRESS;Initial Catalog=FSA;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aerodrome>(entity =>
        {
            entity.HasKey(e => e.CodeIata);

            entity.ToTable("aerodrome");

            entity.Property(e => e.CodeIata)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codeIATA");

            entity.Property(e => e.Aeroport)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aeroport");

            entity.Property(e => e.CodeOaci)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codeOACI");

            entity.Property(e => e.IdGestionnaireAerodrome).HasColumnName("idGestionnaireAerodrome");

            entity.Property(e => e.Tarif)
              
                 .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tarif");

            entity.HasOne(d => d.IdGestionnaireAerodromeNavigation).WithMany(p => p.Aerodromes)
                .HasForeignKey(d => d.IdGestionnaireAerodrome)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_aerodrome_gestionnaireAerodrome");
        });

        modelBuilder.Entity<Aircraft>(entity =>
        {
            entity.HasKey(e => e.Immatriculation);

            entity.ToTable("aircraft");

            entity.Property(e => e.Immatriculation)
                .ValueGeneratedNever()
                .HasColumnName("immatriculation");

            entity.Property(e => e.IdCompagnie).HasColumnName("idCompagnie");

            entity.Property(e => e.NbSiege).HasColumnName("nbSiege");

            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.IdCompagnieNavigation).WithMany(p => p.Aircraft)
                .HasForeignKey(d => d.IdCompagnie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_aircraft_compagnie");

            entity.HasMany(a => a.Vols)
                .WithOne(v => v.ImmatriculationNavigation)
                .HasForeignKey(v => v.Immatriculation);
        });

        modelBuilder.Entity<Compagnie>(entity =>
        {
            entity.HasKey(e => e.IdCompagnie);

            entity.ToTable("compagnie");

            entity.Property(e => e.IdCompagnie).HasColumnName("idCompagnie");

            entity.Property(e => e.Adresse)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("adresse");

            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");

            entity.Property(e => e.InitialCompagnie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("initialCompagnie");

            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<GestionnaireAerodrome>(entity =>
        {
            entity.HasKey(e => e.IdGestionnaireAerodrome);

            entity.ToTable("gestionnaireAerodrome");

            entity.Property(e => e.IdGestionnaireAerodrome).HasColumnName("idGestionnaireAerodrome");

            entity.Property(e => e.ContactAdresse)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contact-adresse");

            entity.Property(e => e.GestionnaireAerodrome1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gestionnaireAerodrome");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur).HasName("PK_utilissateur");

            entity.ToTable("utilisateur");

            entity.Property(e => e.IdUtilisateur)
                
                .HasColumnName("idUtilisateur");

            entity.Property(e => e.IdGestionnaireAerodrome)
            .HasColumnName("idGestionnaireAerodrome");


            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("login");

            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom");

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");

            //  entity.HasOne(d => d.IdGestionnaireAerodromeNavigation).WithMany(p => p.Utilisateurs)
             
             //   .HasForeignKey(d => d.IdGestionnaireAerodrome)
           //     .HasConstraintName("fk_utilisateur");

            entity.Property(e => e.Prenom)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("prenom");

            entity.HasOne(d => d.IdGestionnaireAerodromeNavigation).WithMany(p => p.Utilisateurs)
                .HasForeignKey(d => d.IdGestionnaireAerodrome)
                .HasConstraintName("fk_utilisateur");
        });

        modelBuilder.Entity<Vol>(entity =>
        {
            entity.HasKey(e => e.idVol);

            entity.ToTable("vol");

            entity.Property(e => e.idVol)
                .HasColumnName("idVol");

            entity.Property(e => e.Annee).HasColumnName("annee");
            entity.Property(e => e.Bb).HasColumnName("bb");
            entity.Property(e => e.DestProv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("destProv");
         
            
            entity.Property(e => e.Local)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("local");
            entity.Property(e => e.HeureBloc).HasColumnName("heureBloc");
            entity.Property(e => e.HeurePiste).HasColumnName("heurePiste");
            entity.Property(e => e.Immatriculation).HasColumnName("immatriculation");
            entity.Property(e => e.Immd).HasColumnName("IMMD");

            entity.Property(e => e.Jour)
                
                .HasColumnName("jour");

            entity.Property(e => e.Mois)
                
                .HasColumnName("mois");

            entity.Property(e => e.PaxC).HasColumnName("paxC");
            entity.Property(e => e.PaxY).HasColumnName("paxY");

            entity.Property(e => e.Resau)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("resau");
            entity.Property(e => e.NumeroVol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NumeroVol");

            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.DestProvNavigation).WithMany(p => p.Vols)
                .HasForeignKey(d => d.DestProv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vol_aerodrome");

            entity.HasOne(v => v.ImmatriculationNavigation)
                .WithMany(a => a.Vols)
                .HasForeignKey(v => v.Immatriculation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vol_aircraft");
        });

        // Autres configurations

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
