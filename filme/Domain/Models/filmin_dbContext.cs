using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Models
{
    public partial class filmin_dbContext : DbContext
    {
        public filmin_dbContext()
        {
        }

        public filmin_dbContext(DbContextOptions<filmin_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BuscaGenero> BuscaGeneros { get; set; } = null!;
        public virtual DbSet<Elenco> Elencos { get; set; } = null!;
        public virtual DbSet<Filmes> Filmes { get; set; } = null!;
        public virtual DbSet<Info> Infos { get; set; } = null!;
        public virtual DbSet<Listum> Lista { get; set; } = null!;
        public virtual DbSet<Pessoa> Pessoas { get; set; } = null!;
        public virtual DbSet<Produtora> Produtoras { get; set; } = null!;
        public virtual DbSet<Rateview> Rateviews { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<Series> Series { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=filmin_db;Username=postgres;Password=felipe15");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuscaGenero>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("busca_genero");

                entity.Property(e => e.NomeFilmes)
                    .HasMaxLength(80)
                    .HasColumnName("nome_filmes");

                entity.Property(e => e.NomeSeries)
                    .HasMaxLength(80)
                    .HasColumnName("nome_series");
            });

            modelBuilder.Entity<Elenco>(entity =>
            {
                entity.ToTable("elenco");

                entity.Property(e => e.ElencoId)
                    .ValueGeneratedNever()
                    .HasColumnName("elenco_id");

                entity.Property(e => e.FilmeId).HasColumnName("filme_id");

                entity.Property(e => e.PessoaId).HasColumnName("pessoa_id");

                entity.Property(e => e.SerieId).HasColumnName("serie_id");

                entity.HasOne(d => d.Filme)
                    .WithMany(p => p.Elencos)
                    .HasForeignKey(d => d.FilmeId)
                    .HasConstraintName("elenco_filme_id_fkey");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Elencos)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("elenco_pessoa_id_fkey");

                entity.HasOne(d => d.Serie)
                    .WithMany(p => p.Elencos)
                    .HasForeignKey(d => d.SerieId)
                    .HasConstraintName("elenco_serie_id_fkey");
            });

            modelBuilder.Entity<Filmes>(entity =>
            {
                entity.ToTable("filmes");

                entity.HasIndex(e => e.Genero, "genero_filme");

                entity.HasIndex(e => e.Nome, "nome_filme");

                entity.Property(e => e.FilmeId)
                    .ValueGeneratedNever()
                    .HasColumnName("filme_id");

                entity.Property(e => e.AnoLancamento).HasColumnName("ano_lancamento");

                entity.Property(e => e.Genero)
                    .HasMaxLength(80)
                    .HasColumnName("genero");

                entity.Property(e => e.Nacionalidade)
                    .HasMaxLength(80)
                    .HasColumnName("nacionalidade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .HasColumnName("nome");

                entity.Property(e => e.ProdutoraId).HasColumnName("produtora_id");

                entity.Property(e => e.Resumo)
                    .HasMaxLength(255)
                    .HasColumnName("resumo");

                entity.HasOne(d => d.Produtora)
                    .WithMany(p => p.Filmes)
                    .HasForeignKey(d => d.ProdutoraId)
                    .HasConstraintName("filmes_produtora_id_fkey");
            });

            modelBuilder.Entity<Info>(entity =>
            {
                entity.ToTable("info");

                entity.Property(e => e.InfoId)
                    .ValueGeneratedNever()
                    .HasColumnName("info_id");

                entity.Property(e => e.FilmeId).HasColumnName("filme_id");

                entity.Property(e => e.ListaId).HasColumnName("lista_id");

                entity.Property(e => e.SerieId).HasColumnName("serie_id");

                entity.HasOne(d => d.Filme)
                    .WithMany(p => p.Infos)
                    .HasForeignKey(d => d.FilmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("info_filme_id_fkey");

                entity.HasOne(d => d.Lista)
                    .WithMany(p => p.Infos)
                    .HasForeignKey(d => d.ListaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("info_lista_id_fkey");

                entity.HasOne(d => d.Serie)
                    .WithMany(p => p.Infos)
                    .HasForeignKey(d => d.SerieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("info_serie_id_fkey");
            });

            modelBuilder.Entity<Listum>(entity =>
            {
                entity.HasKey(e => e.ListaId)
                    .HasName("lista_pkey");

                entity.ToTable("lista");

                entity.Property(e => e.ListaId)
                    .ValueGeneratedNever()
                    .HasColumnName("lista_id");

                entity.Property(e => e.DataCriacao).HasColumnName("data_criacao");

                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .HasColumnName("nome");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Lista)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lista_user_id_fkey");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoa");

                entity.HasIndex(e => e.Nome, "pessoa_nome");

                entity.Property(e => e.PessoaId)
                    .ValueGeneratedNever()
                    .HasColumnName("pessoa_id");

                entity.Property(e => e.Funcao)
                    .HasMaxLength(80)
                    .HasColumnName("funcao");

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.Nacionalidade)
                    .HasMaxLength(80)
                    .HasColumnName("nacionalidade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Produtora>(entity =>
            {
                entity.ToTable("produtora");

                entity.Property(e => e.ProdutoraId)
                    .ValueGeneratedNever()
                    .HasColumnName("produtora_id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Rateview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("rateview");

                entity.Property(e => e.FilmeId).HasColumnName("filme_id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .HasColumnName("nome");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.RatingId).HasColumnName("rating_id");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("rating");

                entity.Property(e => e.RatingId).HasColumnName("rating_id");

                entity.Property(e => e.FilmeId).HasColumnName("filme_id");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.SerieId).HasColumnName("serie_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Filme)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.FilmeId)
                    .HasConstraintName("rating_filme_id_fkey");

                entity.HasOne(d => d.Serie)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.SerieId)
                    .HasConstraintName("rating_serie_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rating_user_id_fkey");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.HasKey(e => e.SerieId)
                    .HasName("series_pkey");

                entity.ToTable("series");

                entity.HasIndex(e => e.Genero, "genero_serie");

                entity.HasIndex(e => e.Nome, "serie_nome");

                entity.Property(e => e.SerieId)
                    .ValueGeneratedNever()
                    .HasColumnName("serie_id");

                entity.Property(e => e.AnoFinal).HasColumnName("ano_final");

                entity.Property(e => e.AnoLancamento).HasColumnName("ano_lancamento");

                entity.Property(e => e.Genero)
                    .HasMaxLength(80)
                    .HasColumnName("genero");

                entity.Property(e => e.Nacionalicade)
                    .HasMaxLength(80)
                    .HasColumnName("nacionalicade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .HasColumnName("nome");

                entity.Property(e => e.NumeroEpisodios).HasColumnName("numero_episodios");

                entity.Property(e => e.NumeroSeasons).HasColumnName("numero_seasons");

                entity.Property(e => e.ProdutoraId).HasColumnName("produtora_id");

                entity.Property(e => e.Resumo)
                    .HasMaxLength(255)
                    .HasColumnName("resumo");

                entity.HasOne(d => d.Produtora)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.ProdutoraId)
                    .HasConstraintName("series_produtora_id_fkey");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("usuarios_pkey");

                entity.ToTable("usuarios");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Assinante).HasColumnName("assinante");

                entity.Property(e => e.Assinatura).HasColumnName("assinatura");

                entity.Property(e => e.DataCriacao).HasColumnName("data_criacao");

                entity.Property(e => e.Login)
                    .HasMaxLength(80)
                    .HasColumnName("login");

                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .HasMaxLength(80)
                    .HasColumnName("senha");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
