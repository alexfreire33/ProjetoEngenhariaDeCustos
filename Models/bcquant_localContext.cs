using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bcquant.Models
{
    public partial class bcquant_localContext : DbContext
    {
        public bcquant_localContext()
        {
        }

        public bcquant_localContext(DbContextOptions<bcquant_localContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAmbiente> TbAmbiente { get; set; }
        public virtual DbSet<TbAmbienteBasico> TbAmbienteBasico { get; set; }
        public virtual DbSet<TbConstrutor> TbConstrutor { get; set; }
        public virtual DbSet<TbCores> TbCores { get; set; }
        public virtual DbSet<TbFabricantes> TbFabricantes { get; set; }
        public virtual DbSet<TbGrupoInsumo> TbGrupoInsumo { get; set; }
        public virtual DbSet<TbGrupoServico> TbGrupoServico { get; set; }
        public virtual DbSet<TbInsumoBcQuant> TbInsumoBcQuant { get; set; }
        public virtual DbSet<TbItensLevantamento> TbItensLevantamento { get; set; }
        public virtual DbSet<TbLevantamento> TbLevantamento { get; set; }
        public virtual DbSet<TbLog> TbLog { get; set; }
        public virtual DbSet<TbMateriaPrima> TbMateriaPrima { get; set; }
        public virtual DbSet<TbObra> TbObra { get; set; }
        public virtual DbSet<TbPavimentos> TbPavimentos { get; set; }
        public virtual DbSet<TbPavimentoUc> TbPavimentoUc { get; set; }
        public virtual DbSet<TbPerfil> TbPerfil { get; set; }
        public virtual DbSet<TbPerfilHasTbTransacao> TbPerfilHasTbTransacao { get; set; }
        public virtual DbSet<TbPosicao> TbPosicao { get; set; }
        public virtual DbSet<TbPosicaoAmbiente> TbPosicaoAmbiente { get; set; }
        public virtual DbSet<TbServicoBc> TbServicoBc { get; set; }
        public virtual DbSet<TbStatusGeral> TbStatusGeral { get; set; }
        public virtual DbSet<TbStatusLevantamento> TbStatusLevantamento { get; set; }
        public virtual DbSet<TbTipologia> TbTipologia { get; set; }
        public virtual DbSet<TbTiposLevantamento> TbTiposLevantamento { get; set; }
        public virtual DbSet<TbTransacao> TbTransacao { get; set; }
        public virtual DbSet<TbUcObra> TbUcObra { get; set; }
        public virtual DbSet<TbUnidade> TbUnidade { get; set; }
        public virtual DbSet<TbUnidadeConstrutiva> TbUnidadeConstrutiva { get; set; }
        public virtual DbSet<TbUnidadeMedida> TbUnidadeMedida { get; set; }
        public virtual DbSet<TbUsuario> TbUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseMySql("Server=localhost;Database=bcquant_local;Uid=root;Pwd=;");
                optionsBuilder.UseMySql("Server=localhost;DataBase=bcquant;Uid=alex_freire;Pwd=Bcengcustos@123");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAmbiente>(entity =>
            {
                entity.HasKey(e => e.CodAmbiente);

                entity.ToTable("tb_ambiente");

                entity.HasIndex(e => e.TbAmbienteBasicoCodAmbienteBasico)
                    .HasName("fk_tb_ambiente_tb_ambiente_basico1_idx");

                entity.HasIndex(e => e.TbPavimentoUcCodPavimentoUc)
                    .HasName("fk_tb_ambiente_tb_pavimento_uc1_idx");

                entity.HasIndex(e => e.TbUcObraCodUcObra)
                    .HasName("fk_tb_ambiente_tb_uc_obra1_idx");

                entity.Property(e => e.CodAmbiente)
                    .HasColumnName("cod_ambiente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomePiso)
                    .HasColumnName("nome_piso")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.NumeroRepeticaoObra)
                    .HasColumnName("numero_repeticao_obra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumeroRepeticaoPavimento)
                    .HasColumnName("numero_repeticao_pavimento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ObsAmbiente)
                    .HasColumnName("obs_ambiente")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.TbAmbienteBasicoCodAmbienteBasico)
                    .HasColumnName("tb_ambiente_basico_cod_ambiente_basico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbPavimentoUcCodPavimentoUc)
                    .HasColumnName("tb_pavimento_uc_cod_pavimento_uc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbUcObraCodUcObra)
                    .HasColumnName("tb_uc_obra_cod_uc_obra")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TbAmbienteBasicoCodAmbienteBasicoNavigation)
                    .WithMany(p => p.TbAmbiente)
                    .HasForeignKey(d => d.TbAmbienteBasicoCodAmbienteBasico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_ambiente_tb_ambiente_basico1");

                entity.HasOne(d => d.TbPavimentoUcCodPavimentoUcNavigation)
                    .WithMany(p => p.TbAmbiente)
                    .HasForeignKey(d => d.TbPavimentoUcCodPavimentoUc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_ambiente_tb_pavimento_uc1");

                entity.HasOne(d => d.TbUcObraCodUcObraNavigation)
                    .WithMany(p => p.TbAmbiente)
                    .HasForeignKey(d => d.TbUcObraCodUcObra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_ambiente_tb_uc_obra1");
            });

            modelBuilder.Entity<TbAmbienteBasico>(entity =>
            {
                entity.HasKey(e => e.CodAmbienteBasico);

                entity.ToTable("tb_ambiente_basico");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_ambiente_basico_tb_status_geral1_idx");

                entity.Property(e => e.CodAmbienteBasico)
                    .HasColumnName("cod_ambiente_basico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeAmbienteBasico)
                    .HasColumnName("nome_ambiente_basico")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbAmbienteBasico)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_ambiente_basico_tb_status_geral1");
            });

            modelBuilder.Entity<TbConstrutor>(entity =>
            {
                entity.HasKey(e => e.CodConstrutor);

                entity.ToTable("tb_construtor");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_construtor_tb_status_geral1_idx");

                entity.Property(e => e.CodConstrutor)
                    .HasColumnName("cod_construtor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BairroConstrutor)
                    .HasColumnName("bairro_construtor")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.CepConstrutor)
                    .HasColumnName("cep_construtor")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.CidadeConstrutor)
                    .HasColumnName("cidade_construtor")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.CnpjConstrutor)
                    .HasColumnName("cnpj_construtor")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.DddConstrutor)
                    .HasColumnName("ddd_construtor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmailConstrutor)
                    .HasColumnName("email_construtor")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.EstadoConstrutor)
                    .HasColumnName("estado_construtor")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.NomeConstrutor)
                    .HasColumnName("nome_construtor")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.NumeroConstrutor)
                    .HasColumnName("numero_construtor")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.RuaConstrutor)
                    .HasColumnName("rua_construtor")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TelefoneConstrutor)
                    .HasColumnName("telefone_construtor")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbConstrutor)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_construtor_tb_status_geral1");
            });

            modelBuilder.Entity<TbCores>(entity =>
            {
                entity.HasKey(e => new { e.CodCores, e.TbStatusGeralCodStatusGeral });

                entity.ToTable("tb_cores");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_cores_tb_status_geral1_idx");

                entity.Property(e => e.CodCores)
                    .HasColumnName("cod_cores")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NomeCores)
                    .HasColumnName("nome_cores")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbCores)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_cores_tb_status_geral1");
            });

            modelBuilder.Entity<TbFabricantes>(entity =>
            {
                entity.HasKey(e => e.CodFabricantes);

                entity.ToTable("tb_fabricantes");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_fabricantes_tb_status_geral1_idx");

                entity.Property(e => e.CodFabricantes)
                    .HasColumnName("cod_fabricantes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeFabricantes)
                    .HasColumnName("nome_fabricantes")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbFabricantes)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .HasConstraintName("fk_tb_fabricantes_tb_status_geral1");
            });

            modelBuilder.Entity<TbGrupoInsumo>(entity =>
            {
                entity.HasKey(e => e.CodGrupoInsumo);

                entity.ToTable("tb_grupo_insumo");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_grupo_insumo_tb_status_geral1_idx");

                entity.Property(e => e.CodGrupoInsumo)
                    .HasColumnName("cod_grupo_insumo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeGrupoInsumo)
                    .HasColumnName("nome_grupo_insumo")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SiglaGrupoInsumo)
                    .HasColumnName("sigla_grupo_insumo")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbGrupoInsumo)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_grupo_insumo_tb_status_geral1");
            });

            modelBuilder.Entity<TbGrupoServico>(entity =>
            {
                entity.HasKey(e => e.CodGrupoServico);

                entity.ToTable("tb_grupo_servico");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_grupo_servico_tb_status_geral1_idx");

                entity.Property(e => e.CodGrupoServico)
                    .HasColumnName("cod_grupo_servico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeGrupoServico)
                    .HasColumnName("nome_grupo_servico")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SigaGrupoServico)
                    .HasColumnName("siga_grupo_servico")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbGrupoServico)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_grupo_servico_tb_status_geral1");
            });

            modelBuilder.Entity<TbInsumoBcQuant>(entity =>
            {
                entity.HasKey(e => e.CodInsumoBcQuant);

                entity.ToTable("tb_insumo_bc_quant");

                entity.HasIndex(e => e.TbCoresCodCores)
                    .HasName("fk_tb_insumo_bc_quant_tb_cores1_idx");

                entity.HasIndex(e => e.TbFabricantesCodFabricantes)
                    .HasName("fk_tb_insumo_bc_quant_tb_fabricantes1_idx");

                entity.HasIndex(e => e.TbItensLevantamentoCodItensLevantamento)
                    .HasName("fk_tb_insumo_bc_quant_tb_itens_levantamento1_idx");

                entity.HasIndex(e => e.TbMateriaPrimaCodMateriaPrima)
                    .HasName("fk_tb_insumo_bc_quant_tb_materia_prima1_idx");

                entity.HasIndex(e => e.TbPosicaoCodPosicao)
                    .HasName("fk_tb_insumo_bc_quant_tb_posicao1_idx");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_insumo_bc_quant_tb_status_geral1_idx");

                entity.HasIndex(e => e.TbUnidadeMedidaCodUnidadeMedida)
                    .HasName("fk_tb_insumo_bc_quant_tb_unidade_medida1_idx");

                entity.Property(e => e.CodInsumoBcQuant)
                    .HasColumnName("cod_insumo_bc_quant")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoInternoInsumoBcQuant)
                    .HasColumnName("codigo_interno_insumo_bc_quant")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.DataCadastroInsumoBc)
                    .HasColumnName("data_cadastro_insumo_bc")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImagemInsumo)
                    .HasColumnName("imagem_insumo")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.NomeInsumoBcQuant)
                    .HasColumnName("nome_insumo_bc_quant")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ObservacaoInsumoBcQuant)
                    .HasColumnName("observacao_insumo_bc_quant")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Peso)
                    .HasColumnName("peso")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.TbCoresCodCores)
                    .HasColumnName("tb_cores_cod_cores")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbFabricantesCodFabricantes)
                    .HasColumnName("tb_fabricantes_cod_fabricantes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbItensLevantamentoCodItensLevantamento)
                    .HasColumnName("tb_itens_levantamento_cod_itens_levantamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbMateriaPrimaCodMateriaPrima)
                    .HasColumnName("tb_materia_prima_cod_materia_prima")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbPosicaoCodPosicao)
                    .HasColumnName("tb_posicao_cod_posicao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TbUnidadeMedidaCodUnidadeMedida)
                    .HasColumnName("tb_unidade_medida_cod_unidade_medida")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TbFabricantesCodFabricantesNavigation)
                    .WithMany(p => p.TbInsumoBcQuant)
                    .HasForeignKey(d => d.TbFabricantesCodFabricantes)
                    .HasConstraintName("fk_tb_insumo_bc_quant_tb_fabricantes1");

                entity.HasOne(d => d.TbItensLevantamentoCodItensLevantamentoNavigation)
                    .WithMany(p => p.TbInsumoBcQuant)
                    .HasForeignKey(d => d.TbItensLevantamentoCodItensLevantamento)
                    .HasConstraintName("fk_tb_insumo_bc_quant_tb_itens_levantamento1");

                entity.HasOne(d => d.TbMateriaPrimaCodMateriaPrimaNavigation)
                    .WithMany(p => p.TbInsumoBcQuant)
                    .HasForeignKey(d => d.TbMateriaPrimaCodMateriaPrima)
                    .HasConstraintName("fk_tb_insumo_bc_quant_tb_materia_prima1");

                entity.HasOne(d => d.TbPosicaoCodPosicaoNavigation)
                    .WithMany(p => p.TbInsumoBcQuant)
                    .HasForeignKey(d => d.TbPosicaoCodPosicao)
                    .HasConstraintName("fk_tb_insumo_bc_quant_tb_posicao1");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbInsumoBcQuant)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .HasConstraintName("fk_tb_insumo_bc_quant_tb_status_geral1");

                entity.HasOne(d => d.TbUnidadeMedidaCodUnidadeMedidaNavigation)
                    .WithMany(p => p.TbInsumoBcQuant)
                    .HasForeignKey(d => d.TbUnidadeMedidaCodUnidadeMedida)
                    .HasConstraintName("fk_tb_insumo_bc_quant_tb_unidade_medida1");
            });

            modelBuilder.Entity<TbItensLevantamento>(entity =>
            {
                entity.HasKey(e => e.CodItensLevantamento);

                entity.ToTable("tb_itens_levantamento");

                entity.HasIndex(e => e.TbGrupoInsumoCodGrupoInsumo)
                    .HasName("fk_tb_itens_levantamento_tb_grupo_insumo1_idx");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_itens_levantamento_tb_status_geral1_idx");

                entity.HasIndex(e => e.TbUnidadeMedidaCodUnidadeMedida)
                    .HasName("fk_tb_itens_levantamento_tb_unidade_medida1_idx");

                entity.Property(e => e.CodItensLevantamento)
                    .HasColumnName("cod_itens_levantamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeItensLevantamento)
                    .HasColumnName("nome_itens_levantamento")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TbGrupoInsumoCodGrupoInsumo)
                    .HasColumnName("tb_grupo_insumo_cod_grupo_insumo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TbUnidadeMedidaCodUnidadeMedida)
                    .HasColumnName("tb_unidade_medida_cod_unidade_medida")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TbGrupoInsumoCodGrupoInsumoNavigation)
                    .WithMany(p => p.TbItensLevantamento)
                    .HasForeignKey(d => d.TbGrupoInsumoCodGrupoInsumo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_itens_levantamento_tb_grupo_insumo1");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbItensLevantamento)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_itens_levantamento_tb_status_geral1");

                entity.HasOne(d => d.TbUnidadeMedidaCodUnidadeMedidaNavigation)
                    .WithMany(p => p.TbItensLevantamento)
                    .HasForeignKey(d => d.TbUnidadeMedidaCodUnidadeMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_itens_levantamento_tb_unidade_medida1");
            });

            modelBuilder.Entity<TbLevantamento>(entity =>
            {
                entity.HasKey(e => e.CodLevantamento);

                entity.ToTable("tb_levantamento");

                entity.HasIndex(e => e.TbObraCodObra)
                    .HasName("fk_tb_levantamento_tb_obra1_idx");

                entity.HasIndex(e => e.TbStatusLevantamentoCodStatusLevantamento)
                    .HasName("fk_tb_levantamento_tb_status_levantamento1_idx");

                entity.HasIndex(e => e.TbTiposLevantamentoCodTiposLevantamento)
                    .HasName("fk_tb_levantamento_tb_tipos_levantamento1_idx");

                entity.HasIndex(e => e.TbUcObraCodUcObra)
                    .HasName("fk_tb_levantamento_tb_uc_obra1_idx");

                entity.Property(e => e.CodLevantamento)
                    .HasColumnName("cod_levantamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataAtualizacaoLevantamento)
                    .HasColumnName("data_atualizacao_levantamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataConclusaoLevantamento)
                    .HasColumnName("data_conclusao_levantamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataInicioLevantamento)
                    .HasColumnName("data_inicio_levantamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailResponsavel)
                    .HasColumnName("email_responsavel")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.NomeResponsavel)
                    .HasColumnName("nome_responsavel")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.NumeroVersaoLevantamento)
                    .HasColumnName("numero_versao_levantamento")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.ObservacaoLevantamento)
                    .HasColumnName("observacao_levantamento")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.TbObraCodObra)
                    .HasColumnName("tb_obra_cod_obra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbStatusLevantamentoCodStatusLevantamento)
                    .HasColumnName("tb_status_levantamento_cod_status_levantamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbTiposLevantamentoCodTiposLevantamento)
                    .HasColumnName("tb_tipos_levantamento_cod_tipos_levantamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbUcObraCodUcObra)
                    .HasColumnName("tb_uc_obra_cod_uc_obra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TelefoneResponsavel)
                    .HasColumnName("telefone_responsavel")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.UrlArquivoLevantamento)
                    .HasColumnName("url_arquivo_levantamento")
                    .HasColumnType("varchar(500)");

                entity.HasOne(d => d.TbObraCodObraNavigation)
                    .WithMany(p => p.TbLevantamento)
                    .HasForeignKey(d => d.TbObraCodObra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_levantamento_tb_obra1");

                entity.HasOne(d => d.TbStatusLevantamentoCodStatusLevantamentoNavigation)
                    .WithMany(p => p.TbLevantamento)
                    .HasForeignKey(d => d.TbStatusLevantamentoCodStatusLevantamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_levantamento_tb_status_levantamento1");

                entity.HasOne(d => d.TbTiposLevantamentoCodTiposLevantamentoNavigation)
                    .WithMany(p => p.TbLevantamento)
                    .HasForeignKey(d => d.TbTiposLevantamentoCodTiposLevantamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_levantamento_tb_tipos_levantamento1");

                entity.HasOne(d => d.TbUcObraCodUcObraNavigation)
                    .WithMany(p => p.TbLevantamento)
                    .HasForeignKey(d => d.TbUcObraCodUcObra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_levantamento_tb_uc_obra1");
            });

            modelBuilder.Entity<TbLog>(entity =>
            {
                entity.HasKey(e => e.CodLog);

                entity.ToTable("tb_log");

                entity.HasIndex(e => e.TbUsuarioCodUsuario)
                    .HasName("fk_tb_log_tb_usuario1_idx");

                entity.Property(e => e.CodLog)
                    .HasColumnName("cod_log")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataLog)
                    .HasColumnName("data_log")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpLog)
                    .HasColumnName("ip_log")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Navegador)
                    .HasColumnName("navegador")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.NomeDaPagina)
                    .HasColumnName("nome_da_pagina")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.NumeroDaLinha)
                    .HasColumnName("numero_da_linha")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.So)
                    .HasColumnName("so")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TbUsuarioCodUsuario)
                    .HasColumnName("tb_usuario_cod_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Texto)
                    .HasColumnName("texto")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.TipoDoLog)
                    .HasColumnName("tipo_do_log")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.VelocidadeDeExecucao)
                    .HasColumnName("velocidade_de_execucao")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.TbUsuarioCodUsuarioNavigation)
                    .WithMany(p => p.TbLog)
                    .HasForeignKey(d => d.TbUsuarioCodUsuario)
                    .HasConstraintName("fk_tb_log_tb_usuario1");
            });

            modelBuilder.Entity<TbMateriaPrima>(entity =>
            {
                entity.HasKey(e => e.CodMateriaPrima);

                entity.ToTable("tb_materia_prima");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_materia_prima_tb_status_geral1_idx");

                entity.Property(e => e.CodMateriaPrima)
                    .HasColumnName("cod_materia_prima")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeMateriaPrima)
                    .HasColumnName("nome_materia_prima")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbMateriaPrima)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_materia_prima_tb_status_geral1");
            });

            modelBuilder.Entity<TbObra>(entity =>
            {
                entity.HasKey(e => e.CodObra);

                entity.ToTable("tb_obra");

                entity.HasIndex(e => e.TbConstrutorCodConstrutor)
                    .HasName("fk_tb_obra_tb_construtor1_idx");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_obra_tb_status_geral1_idx");

                entity.HasIndex(e => e.TbTipologiaCodTipologia)
                    .HasName("fk_tb_obra_tb_tipologia1_idx");

                entity.Property(e => e.CodObra)
                    .HasColumnName("cod_obra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AreaConstruida)
                    .HasColumnName("area_construida")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BairroObra)
                    .HasColumnName("bairro_obra")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.CidadeObra)
                    .HasColumnName("cidade_obra")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.DescricaoObra)
                    .HasColumnName("descricao_obra")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.EstadoObra)
                    .HasColumnName("estado_obra")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.NomeObra)
                    .HasColumnName("nome_obra")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.NumeroObra)
                    .HasColumnName("numero_obra")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.RuaObra)
                    .HasColumnName("rua_obra")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TbConstrutorCodConstrutor)
                    .HasColumnName("tb_construtor_cod_construtor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TbTipologiaCodTipologia)
                    .HasColumnName("tb_tipologia_cod_tipologia")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TbConstrutorCodConstrutorNavigation)
                    .WithMany(p => p.TbObra)
                    .HasForeignKey(d => d.TbConstrutorCodConstrutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_obra_tb_construtor1");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbObra)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_obra_tb_status_geral1");

                entity.HasOne(d => d.TbTipologiaCodTipologiaNavigation)
                    .WithMany(p => p.TbObra)
                    .HasForeignKey(d => d.TbTipologiaCodTipologia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_obra_tb_tipologia1");
            });

            modelBuilder.Entity<TbPavimentos>(entity =>
            {
                entity.HasKey(e => e.CodPavimentos);

                entity.ToTable("tb_pavimentos");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_pavimentos_tb_status_geral1_idx");

                entity.Property(e => e.CodPavimentos)
                    .HasColumnName("cod_pavimentos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomePavimentos)
                    .HasColumnName("nome_pavimentos")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbPavimentos)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_pavimentos_tb_status_geral1");
            });

            modelBuilder.Entity<TbPavimentoUc>(entity =>
            {
                entity.HasKey(e => e.CodPavimentoUc);

                entity.ToTable("tb_pavimento_uc");

                entity.HasIndex(e => e.TbPavimentosCodPavimentos)
                    .HasName("fk_tb_pavimento_uc_tb_pavimentos1_idx");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_pavimento_uc_tb_status_geral1_idx");

                entity.HasIndex(e => e.TbUcObraCodUcObra)
                    .HasName("fk_tb_pavimento_uc_tb_uc_obra1_idx");

                entity.Property(e => e.CodPavimentoUc)
                    .HasColumnName("cod_pavimento_uc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumeroRepeticoesPavimento)
                    .HasColumnName("numero_repeticoes_pavimento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbPavimentosCodPavimentos)
                    .HasColumnName("tb_pavimentos_cod_pavimentos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbUcObraCodUcObra)
                    .HasColumnName("tb_uc_obra_cod_uc_obra")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TbPavimentosCodPavimentosNavigation)
                    .WithMany(p => p.TbPavimentoUc)
                    .HasForeignKey(d => d.TbPavimentosCodPavimentos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_pavimento_uc_tb_pavimentos1");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbPavimentoUc)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_pavimento_uc_tb_status_geral1");

                entity.HasOne(d => d.TbUcObraCodUcObraNavigation)
                    .WithMany(p => p.TbPavimentoUc)
                    .HasForeignKey(d => d.TbUcObraCodUcObra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_pavimento_uc_tb_uc_obra1");
            });

            modelBuilder.Entity<TbPerfil>(entity =>
            {
                entity.HasKey(e => e.CodPerfil);

                entity.ToTable("tb_perfil");

                entity.HasIndex(e => e.TbPerfilCodPerfil)
                    .HasName("fk_tb_perfil_tb_perfil1_idx");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_perfil_tb_status_geral1_idx");

                entity.Property(e => e.CodPerfil)
                    .HasColumnName("cod_perfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Master)
                    .HasColumnName("master")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TbPerfilCodPerfil)
                    .HasColumnName("tb_perfil_cod_perfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbPerfilCodPerfilNavigation)
                    .WithMany(p => p.InverseTbPerfilCodPerfilNavigation)
                    .HasForeignKey(d => d.TbPerfilCodPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_perfil_tb_perfil1");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbPerfil)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_perfil_tb_status_geral1");
            });

            modelBuilder.Entity<TbPerfilHasTbTransacao>(entity =>
            {
                entity.HasKey(e => new { e.TbPerfilCodPerfil, e.TbTransacaoCodTransacao });

                entity.ToTable("tb_perfil_has_tb_transacao");

                entity.HasIndex(e => e.TbPerfilCodPerfil)
                    .HasName("fk_tb_perfil_has_tb_transacao_tb_perfil1_idx");

                entity.HasIndex(e => e.TbTransacaoCodTransacao)
                    .HasName("fk_tb_perfil_has_tb_transacao_tb_transacao1_idx");

                entity.Property(e => e.TbPerfilCodPerfil)
                    .HasColumnName("tb_perfil_cod_perfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbTransacaoCodTransacao)
                    .HasColumnName("tb_transacao_cod_transacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ordem)
                    .HasColumnName("ordem")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TbPerfilCodPerfilNavigation)
                    .WithMany(p => p.TbPerfilHasTbTransacao)
                    .HasForeignKey(d => d.TbPerfilCodPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_perfil_has_tb_transacao_tb_perfil1");

                entity.HasOne(d => d.TbTransacaoCodTransacaoNavigation)
                    .WithMany(p => p.TbPerfilHasTbTransacao)
                    .HasForeignKey(d => d.TbTransacaoCodTransacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_perfil_has_tb_transacao_tb_transacao1");
            });

            modelBuilder.Entity<TbPosicao>(entity =>
            {
                entity.HasKey(e => e.CodPosicao);

                entity.ToTable("tb_posicao");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_posicao_tb_status_geral1_idx");

                entity.Property(e => e.CodPosicao)
                    .HasColumnName("cod_posicao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomePosicao)
                    .HasColumnName("nome_posicao")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbPosicao)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .HasConstraintName("fk_tb_posicao_tb_status_geral1");
            });

            modelBuilder.Entity<TbPosicaoAmbiente>(entity =>
            {
                entity.HasKey(e => e.CodPosicaoAmbiente);

                entity.ToTable("tb_posicao_ambiente");

                entity.HasIndex(e => e.TbAmbienteCodAmbiente)
                    .HasName("fk_tb_posicao_ambiente_tb_ambiente1_idx");

                entity.Property(e => e.CodPosicaoAmbiente)
                    .HasColumnName("cod_posicao_ambiente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AreaADescontar)
                    .HasColumnName("area_a_descontar")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.AreaDaObra)
                    .HasColumnName("area_da_obra")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.AreaDoAmbiente)
                    .HasColumnName("area_do_ambiente")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.Comprimento)
                    .HasColumnName("comprimento")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.ComprimentoADescontar)
                    .HasColumnName("comprimento_a_descontar")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.Descontos)
                    .HasColumnName("descontos")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.Largura)
                    .HasColumnName("largura")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.PeDireito)
                    .HasColumnName("pe_direito")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.PerimetroDaObra)
                    .HasColumnName("perimetro_da_obra")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.PerimetroDoAmbiente)
                    .HasColumnName("perimetro_do_ambiente")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.Posicao)
                    .HasColumnName("posicao")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TbAmbienteCodAmbiente)
                    .HasColumnName("tb_ambiente_cod_ambiente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.TbAmbienteCodAmbienteNavigation)
                    .WithMany(p => p.TbPosicaoAmbiente)
                    .HasForeignKey(d => d.TbAmbienteCodAmbiente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_posicao_ambiente_tb_ambiente1");
            });

            modelBuilder.Entity<TbServicoBc>(entity =>
            {
                entity.HasKey(e => e.CodServicoBc);

                entity.ToTable("tb_servico_bc");

                entity.HasIndex(e => e.TbGrupoServicoCodGrupoServico)
                    .HasName("fk_tb_servico_bc_tb_grupo_servico1_idx");

                entity.HasIndex(e => e.TbPosicaoCodPosicao)
                    .HasName("fk_tb_servico_bc_tb_posicao1_idx");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_servico_bc_tb_status_geral1_idx");

                entity.HasIndex(e => e.TbUnidadeMedidaCodUnidadeMedida)
                    .HasName("fk_tb_servico_bc_tb_unidade_medida1_idx");

                entity.Property(e => e.CodServicoBc)
                    .HasColumnName("cod_servico_bc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoInternoServicoBc)
                    .HasColumnName("codigo_interno_servico_bc")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DescricaoServicoBc)
                    .HasColumnName("descricao_servico_bc")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ObservacaoServicoBc)
                    .HasColumnName("observacao_servico_bc")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TbGrupoServicoCodGrupoServico)
                    .HasColumnName("tb_grupo_servico_cod_grupo_servico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbPosicaoCodPosicao)
                    .HasColumnName("tb_posicao_cod_posicao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TbUnidadeMedidaCodUnidadeMedida)
                    .HasColumnName("tb_unidade_medida_cod_unidade_medida")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TbGrupoServicoCodGrupoServicoNavigation)
                    .WithMany(p => p.TbServicoBc)
                    .HasForeignKey(d => d.TbGrupoServicoCodGrupoServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_servico_bc_tb_grupo_servico1");

                entity.HasOne(d => d.TbPosicaoCodPosicaoNavigation)
                    .WithMany(p => p.TbServicoBc)
                    .HasForeignKey(d => d.TbPosicaoCodPosicao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_servico_bc_tb_posicao1");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbServicoBc)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_servico_bc_tb_status_geral1");

                entity.HasOne(d => d.TbUnidadeMedidaCodUnidadeMedidaNavigation)
                    .WithMany(p => p.TbServicoBc)
                    .HasForeignKey(d => d.TbUnidadeMedidaCodUnidadeMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_servico_bc_tb_unidade_medida1");
            });

            modelBuilder.Entity<TbStatusGeral>(entity =>
            {
                entity.HasKey(e => e.CodStatusGeral);

                entity.ToTable("tb_status_geral");

                entity.Property(e => e.CodStatusGeral)
                    .HasColumnName("cod_status_geral")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<TbStatusLevantamento>(entity =>
            {
                entity.HasKey(e => e.CodStatusLevantamento);

                entity.ToTable("tb_status_levantamento");

                entity.Property(e => e.CodStatusLevantamento)
                    .HasColumnName("cod_status_levantamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeStatusLevantamento)
                    .HasColumnName("nome_status_levantamento")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<TbTipologia>(entity =>
            {
                entity.HasKey(e => e.CodTipologia);

                entity.ToTable("tb_tipologia");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_tipologia_tb_status_geral1_idx");

                entity.Property(e => e.CodTipologia)
                    .HasColumnName("cod_tipologia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeTipologia)
                    .HasColumnName("nome_tipologia")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbTipologia)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_tipologia_tb_status_geral1");
            });

            modelBuilder.Entity<TbTiposLevantamento>(entity =>
            {
                entity.HasKey(e => e.CodTiposLevantamento);

                entity.ToTable("tb_tipos_levantamento");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_tipos_levantamento_tb_status_geral1_idx");

                entity.Property(e => e.CodTiposLevantamento)
                    .HasColumnName("cod_tipos_levantamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeTiposLevantamento)
                    .HasColumnName("nome_tipos_levantamento")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbTiposLevantamento)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_tipos_levantamento_tb_status_geral1");
            });

            modelBuilder.Entity<TbTransacao>(entity =>
            {
                entity.HasKey(e => e.CodTransacao);

                entity.ToTable("tb_transacao");

                entity.Property(e => e.CodTransacao)
                    .HasColumnName("cod_transacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Acao)
                    .HasColumnName("acao")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Icone)
                    .HasColumnName("icone")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IdMenu)
                    .HasColumnName("id_menu")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Menu)
                    .HasColumnName("menu")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Sigla)
                    .HasColumnName("sigla")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(1000)");
            });

            modelBuilder.Entity<TbUcObra>(entity =>
            {
                entity.HasKey(e => e.CodUcObra);

                entity.ToTable("tb_uc_obra");

                entity.HasIndex(e => e.TbObraCodObra)
                    .HasName("fk_tb_uc_obra_tb_obra1_idx");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_uc_obra_tb_status_geral1_idx");

                entity.HasIndex(e => e.TbUnidadeConstrutivaCodUnidadeConstrutiva)
                    .HasName("fk_tb_uc_obra_tb_unidade_construtiva1_idx");

                entity.Property(e => e.CodUcObra)
                    .HasColumnName("cod_uc_obra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AreaConstruidaUc)
                    .HasColumnName("area_construida_uc")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.NumeroRepeticoesUc)
                    .HasColumnName("numero_repeticoes_uc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbObraCodObra)
                    .HasColumnName("tb_obra_cod_obra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbUnidadeConstrutivaCodUnidadeConstrutiva)
                    .HasColumnName("tb_unidade_construtiva_cod_unidade_construtiva")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TbObraCodObraNavigation)
                    .WithMany(p => p.TbUcObra)
                    .HasForeignKey(d => d.TbObraCodObra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_uc_obra_tb_obra1");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbUcObra)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_uc_obra_tb_status_geral1");

                entity.HasOne(d => d.TbUnidadeConstrutivaCodUnidadeConstrutivaNavigation)
                    .WithMany(p => p.TbUcObra)
                    .HasForeignKey(d => d.TbUnidadeConstrutivaCodUnidadeConstrutiva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_uc_obra_tb_unidade_construtiva1");
            });

            modelBuilder.Entity<TbUnidade>(entity =>
            {
                entity.HasKey(e => e.CodTbUnidade);

                entity.ToTable("tb_unidade");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_unidade_tb_status_geral1_idx");

                entity.Property(e => e.CodTbUnidade)
                    .HasColumnName("cod_tb_unidade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbUnidade)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_unidade_tb_status_geral1");
            });

            modelBuilder.Entity<TbUnidadeConstrutiva>(entity =>
            {
                entity.HasKey(e => e.CodUnidadeConstrutiva);

                entity.ToTable("tb_unidade_construtiva");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_unidade_construtiva_tb_status_geral1_idx");

                entity.Property(e => e.CodUnidadeConstrutiva)
                    .HasColumnName("cod_unidade_construtiva")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeUnidadeConstrutiva)
                    .HasColumnName("nome_unidade_construtiva")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbUnidadeConstrutiva)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_unidade_construtiva_tb_status_geral1");
            });

            modelBuilder.Entity<TbUnidadeMedida>(entity =>
            {
                entity.HasKey(e => e.CodUnidadeMedida);

                entity.ToTable("tb_unidade_medida");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_unidade_medida_tb_status_geral1_idx");

                entity.Property(e => e.CodUnidadeMedida)
                    .HasColumnName("cod_unidade_medida")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeUnidadeMedida)
                    .HasColumnName("nome_unidade_medida")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbUnidadeMedida)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_unidade_medida_tb_status_geral1");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.CodUsuario);

                entity.ToTable("tb_usuario");

                entity.HasIndex(e => e.TbPerfilCodPerfil)
                    .HasName("fk_tb_usuario_tb_perfil1_idx");

                entity.HasIndex(e => e.TbStatusGeralCodStatusGeral)
                    .HasName("fk_tb_usuario_tb_status_geral1_idx");

                entity.Property(e => e.CodUsuario)
                    .HasColumnName("cod_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataCadastroUsuario)
                    .HasColumnName("data_cadastro_usuario")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TbPerfilCodPerfil)
                    .HasColumnName("tb_perfil_cod_perfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TbStatusGeralCodStatusGeral)
                    .HasColumnName("tb_status_geral_cod_status_geral")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasColumnType("varchar(500)");

                entity.HasOne(d => d.TbPerfilCodPerfilNavigation)
                    .WithMany(p => p.TbUsuario)
                    .HasForeignKey(d => d.TbPerfilCodPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_usuario_tb_perfil1");

                entity.HasOne(d => d.TbStatusGeralCodStatusGeralNavigation)
                    .WithMany(p => p.TbUsuario)
                    .HasForeignKey(d => d.TbStatusGeralCodStatusGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_usuario_tb_status_geral1");
            });
        }
    }
}
