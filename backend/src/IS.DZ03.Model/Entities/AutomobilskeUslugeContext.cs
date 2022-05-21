using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class AutomobilskeUslugeContext : DbContext
    {
        public AutomobilskeUslugeContext()
        {
        }

        public AutomobilskeUslugeContext(DbContextOptions<AutomobilskeUslugeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administracija> Administracija { get; set; }
        public virtual DbSet<Dobavljač> Dobavljač { get; set; }
        public virtual DbSet<KorisničkaSlužba> KorisničkaSlužba { get; set; }
        public virtual DbSet<Narudžba> Narudžba { get; set; }
        public virtual DbSet<Osoba> Osoba { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }
        public virtual DbSet<Račun> Račun { get; set; }
        public virtual DbSet<Sadržajnarudžbe> Sadržajnarudžbe { get; set; }
        public virtual DbSet<Sadržajračuna> Sadržajračuna { get; set; }
        public virtual DbSet<Statuszadatka> Statuszadatka { get; set; }
        public virtual DbSet<Usluga> Usluga { get; set; }
        public virtual DbSet<Zadatak> Zadatak { get; set; }
        public virtual DbSet<Zaposlenik> Zaposlenik { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Administracija>(entity =>
            {
                entity.ToTable("administracija");

                entity.Property(e => e.Administracijaid)
                    .HasColumnName("administracijaid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Oib)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("oib");

                entity.HasOne(d => d.OibNavigation)
                    .WithMany(p => p.Administracija)
                    .HasForeignKey(d => d.Oib)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("administracija_oib_fkey");
            });

            modelBuilder.Entity<Dobavljač>(entity =>
            {
                entity.HasKey(e => e.Dobavljacid)
                    .HasName("dobavljač_pkey");

                entity.ToTable("dobavljač");

                entity.Property(e => e.Dobavljacid)
                    .HasColumnName("dobavljacid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Nazivdobavljača)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nazivdobavljača");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(15)
                    .HasColumnName("telefon");
            });

            modelBuilder.Entity<KorisničkaSlužba>(entity =>
            {
                entity.HasKey(e => e.Korisnickasluzbaid)
                    .HasName("korisnička_služba_pkey");

                entity.ToTable("korisnička_služba");

                entity.Property(e => e.Korisnickasluzbaid)
                    .HasColumnName("korisnickasluzbaid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Oib)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("oib");

                entity.HasOne(d => d.OibNavigation)
                    .WithMany(p => p.KorisničkaSlužba)
                    .HasForeignKey(d => d.Oib)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("korisnička_služba_oib_fkey");
            });

            modelBuilder.Entity<Narudžba>(entity =>
            {
                entity.ToTable("narudžba");

                entity.Property(e => e.Narudžbaid)
                    .HasColumnName("narudžbaid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Dobavljacid).HasColumnName("dobavljacid");

                entity.Property(e => e.Korisnickasluzbaid).HasColumnName("korisnickasluzbaid");

                entity.Property(e => e.Napomena)
                    .HasMaxLength(100)
                    .HasColumnName("napomena");

                entity.HasOne(d => d.Dobavljac)
                    .WithMany(p => p.Narudžba)
                    .HasForeignKey(d => d.Dobavljacid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("narudžba_dobavljacid_fkey");

                entity.HasOne(d => d.Korisnickasluzba)
                    .WithMany(p => p.Narudžba)
                    .HasForeignKey(d => d.Korisnickasluzbaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("narudžba_korisnickasluzbaid_fkey");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.HasKey(e => e.Oib)
                    .HasName("osoba_pkey");

                entity.ToTable("osoba");

                entity.HasIndex(e => e.Email, "osoba_email_key")
                    .IsUnique();

                entity.Property(e => e.Oib)
                    .HasMaxLength(11)
                    .HasColumnName("oib");

                entity.Property(e => e.Datumrodjenja)
                    .HasColumnType("date")
                    .HasColumnName("datumrodjenja");

                entity.Property(e => e.Datumzaposlenja)
                    .HasColumnType("date")
                    .HasColumnName("datumzaposlenja");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ime");

                entity.Property(e => e.Lozinka)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("lozinka");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("prezime");

                entity.Property(e => e.Spol)
                    .HasMaxLength(1)
                    .HasColumnName("spol");
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.ToTable("proizvod");

                entity.Property(e => e.Proizvodid)
                    .HasColumnName("proizvodid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Cijena)
                    .HasPrecision(9, 2)
                    .HasColumnName("cijena");

                entity.Property(e => e.Količinaproizvoda).HasColumnName("količinaproizvoda");

                entity.Property(e => e.Nazivproizvoda)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nazivproizvoda");
            });

            modelBuilder.Entity<Račun>(entity =>
            {
                entity.HasKey(e => e.Brracuna)
                    .HasName("račun_pkey");

                entity.ToTable("račun");

                entity.Property(e => e.Brracuna)
                    .HasColumnName("brracuna")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Korisnickasluzbaid).HasColumnName("korisnickasluzbaid");

                entity.HasOne(d => d.Korisnickasluzba)
                    .WithMany(p => p.Račun)
                    .HasForeignKey(d => d.Korisnickasluzbaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("račun_korisnickasluzbaid_fkey");
            });

            modelBuilder.Entity<Sadržajnarudžbe>(entity =>
            {
                entity.ToTable("sadržajnarudžbe");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Cijena)
                    .HasPrecision(9, 2)
                    .HasColumnName("cijena");

                entity.Property(e => e.Količina).HasColumnName("količina");

                entity.Property(e => e.Narudžbaid).HasColumnName("narudžbaid");

                entity.Property(e => e.Proizvodid).HasColumnName("proizvodid");

                entity.HasOne(d => d.Narudžba)
                    .WithMany(p => p.Sadržajnarudžbe)
                    .HasForeignKey(d => d.Narudžbaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sadržajnarudžbe_narudžbaid_fkey");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.Sadržajnarudžbe)
                    .HasForeignKey(d => d.Proizvodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sadržajnarudžbe_proizvodid_fkey");
            });

            modelBuilder.Entity<Sadržajračuna>(entity =>
            {
                entity.ToTable("sadržajračuna");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Brracuna).HasColumnName("brracuna");

                entity.Property(e => e.Količina).HasColumnName("količina");

                entity.Property(e => e.Proizvodid).HasColumnName("proizvodid");

                entity.Property(e => e.Zadatakid).HasColumnName("zadatakid");

                entity.HasOne(d => d.BrracunaNavigation)
                    .WithMany(p => p.Sadržajračuna)
                    .HasForeignKey(d => d.Brracuna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sadržajračuna_brracuna_fkey");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.Sadržajračuna)
                    .HasForeignKey(d => d.Proizvodid)
                    .HasConstraintName("sadržajračuna_proizvodid_fkey");

                entity.HasOne(d => d.Zadatak)
                    .WithMany(p => p.Sadržajračuna)
                    .HasForeignKey(d => d.Zadatakid)
                    .HasConstraintName("sadržajračuna_zadatakid_fkey");
            });

            modelBuilder.Entity<Statuszadatka>(entity =>
            {
                entity.ToTable("statuszadatka");

                entity.HasIndex(e => e.Opisstatusa, "statuszadatka_opisstatusa_key")
                    .IsUnique();

                entity.Property(e => e.Statuszadatkaid)
                    .HasColumnName("statuszadatkaid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Opisstatusa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("opisstatusa");
            });

            modelBuilder.Entity<Usluga>(entity =>
            {
                entity.ToTable("usluga");

                entity.HasIndex(e => e.Opisusluga, "usluga_opisusluga_key")
                    .IsUnique();

                entity.Property(e => e.Uslugaid)
                    .HasColumnName("uslugaid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Cijena)
                    .HasPrecision(9, 2)
                    .HasColumnName("cijena");

                entity.Property(e => e.Opisusluga)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("opisusluga");
            });

            modelBuilder.Entity<Zadatak>(entity =>
            {
                entity.ToTable("zadatak");

                entity.Property(e => e.Zadatakid)
                    .HasColumnName("zadatakid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Korisnickasluzbaid).HasColumnName("korisnickasluzbaid");

                entity.Property(e => e.Opis)
                    .HasMaxLength(100)
                    .HasColumnName("opis");

                entity.Property(e => e.Statuszadatkaid).HasColumnName("statuszadatkaid");

                entity.Property(e => e.Uslugaid).HasColumnName("uslugaid");

                entity.Property(e => e.Zaposlenikid).HasColumnName("zaposlenikid");

                entity.HasOne(d => d.Korisnickasluzba)
                    .WithMany(p => p.Zadatak)
                    .HasForeignKey(d => d.Korisnickasluzbaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zadatak_korisnickasluzbaid_fkey");

                entity.HasOne(d => d.Statuszadatka)
                    .WithMany(p => p.Zadatak)
                    .HasForeignKey(d => d.Statuszadatkaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zadatak_statuszadatkaid_fkey");

                entity.HasOne(d => d.Usluga)
                    .WithMany(p => p.Zadatak)
                    .HasForeignKey(d => d.Uslugaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zadatak_uslugaid_fkey");

                entity.HasOne(d => d.Zaposlenik)
                    .WithMany(p => p.Zadatak)
                    .HasForeignKey(d => d.Zaposlenikid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zadatak_zaposlenikid_fkey");
            });

            modelBuilder.Entity<Zaposlenik>(entity =>
            {
                entity.ToTable("zaposlenik");

                entity.Property(e => e.Zaposlenikid)
                    .HasColumnName("zaposlenikid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Oib)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("oib");

                entity.HasOne(d => d.OibNavigation)
                    .WithMany(p => p.Zaposlenik)
                    .HasForeignKey(d => d.Oib)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zaposlenik_oib_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
