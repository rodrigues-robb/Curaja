namespace Curaja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bootstrapper : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(maxLength: 55),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movimentoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 75),
                        Descricao = c.String(maxLength: 255),
                        TempoExecucaoMaximo = c.Int(nullable: false),
                        TempoExecucaoMinimo = c.Int(nullable: false),
                        imagem = c.String(),
                        CategoriaId = c.Long(nullable: false),
                        ContraIndicacao = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.EstadoEsqueletoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MovimentoId = c.Long(nullable: false),
                        EsqueletoResultadoSessaoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EsqueletoResultadoSessaos", t => t.EsqueletoResultadoSessaoId)
                .ForeignKey("dbo.Movimentoes", t => t.MovimentoId)
                .Index(t => t.MovimentoId)
                .Index(t => t.EsqueletoResultadoSessaoId);
            
            CreateTable(
                "dbo.EsqueletoResultadoSessaos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ResultadoMovimento = c.Boolean(nullable: false),
                        Serie = c.Int(nullable: false),
                        Repeticao = c.Int(nullable: false),
                        SessaoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessaos", t => t.SessaoId)
                .Index(t => t.SessaoId);
            
            CreateTable(
                "dbo.Sessaos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DataHoraInicio = c.DateTime(nullable: false),
                        DataHoraFim = c.DateTime(nullable: false),
                        SequenciaId = c.Long(nullable: false),
                        TratamentoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tratamentoes", t => t.TratamentoId)
                .ForeignKey("dbo.Sequencias", t => t.SequenciaId)
                .Index(t => t.SequenciaId)
                .Index(t => t.TratamentoId);
            
            CreateTable(
                "dbo.Sequencias",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 75),
                        FisioterapeutaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.FisioterapeutaId)
                .Index(t => t.FisioterapeutaId);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                        Telefone = c.String(maxLength: 18),
                        Celular = c.String(maxLength: 19),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        Cpf = c.String(nullable: false, maxLength: 11),
                        UsuarioId = c.Long(nullable: false),
                        Profissao = c.String(maxLength: 50),
                        Responsavel = c.String(maxLength: 255),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.Email, unique: true)
                .Index(t => t.Cpf, unique: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Tratamentoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Patologia = c.String(nullable: false, maxLength: 75),
                        NumSessoes = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 50),
                        MotivoStatus = c.String(maxLength: 255),
                        DataCadastro = c.DateTime(nullable: false),
                        FisioterapeutaId = c.Long(nullable: false),
                        PacienteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.FisioterapeutaId)
                .ForeignKey("dbo.Pessoas", t => t.PacienteId)
                .Index(t => t.FisioterapeutaId)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                        Senha = c.String(nullable: false, maxLength: 64),
                        Permissao = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, unique: true);
            
            CreateTable(
                "dbo.MovimentoSequencias",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Posicao = c.Int(nullable: false),
                        Series = c.Int(nullable: false),
                        Repeticoes = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        SequenciaId = c.Long(nullable: false),
                        MovimentoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movimentoes", t => t.MovimentoId)
                .ForeignKey("dbo.Sequencias", t => t.SequenciaId)
                .Index(t => t.SequenciaId)
                .Index(t => t.MovimentoId);
            
            CreateTable(
                "dbo.EnumJoints",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 45),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Joints",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        X = c.Single(nullable: false),
                        Y = c.Single(nullable: false),
                        Z = c.Single(nullable: false),
                        EnumJointId = c.Long(nullable: false),
                        EstadoEsqueletoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnumJoints", t => t.EnumJointId)
                .ForeignKey("dbo.EstadoEsqueletoes", t => t.EstadoEsqueletoId)
                .Index(t => t.EnumJointId)
                .Index(t => t.EstadoEsqueletoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Joints", "EstadoEsqueletoId", "dbo.EstadoEsqueletoes");
            DropForeignKey("dbo.Joints", "EnumJointId", "dbo.EnumJoints");
            DropForeignKey("dbo.EstadoEsqueletoes", "MovimentoId", "dbo.Movimentoes");
            DropForeignKey("dbo.EstadoEsqueletoes", "EsqueletoResultadoSessaoId", "dbo.EsqueletoResultadoSessaos");
            DropForeignKey("dbo.Sessaos", "SequenciaId", "dbo.Sequencias");
            DropForeignKey("dbo.MovimentoSequencias", "SequenciaId", "dbo.Sequencias");
            DropForeignKey("dbo.MovimentoSequencias", "MovimentoId", "dbo.Movimentoes");
            DropForeignKey("dbo.Sessaos", "TratamentoId", "dbo.Tratamentoes");
            DropForeignKey("dbo.Pessoas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Tratamentoes", "PacienteId", "dbo.Pessoas");
            DropForeignKey("dbo.Tratamentoes", "FisioterapeutaId", "dbo.Pessoas");
            DropForeignKey("dbo.Sequencias", "FisioterapeutaId", "dbo.Pessoas");
            DropForeignKey("dbo.EsqueletoResultadoSessaos", "SessaoId", "dbo.Sessaos");
            DropForeignKey("dbo.Movimentoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Joints", new[] { "EstadoEsqueletoId" });
            DropIndex("dbo.Joints", new[] { "EnumJointId" });
            DropIndex("dbo.MovimentoSequencias", new[] { "MovimentoId" });
            DropIndex("dbo.MovimentoSequencias", new[] { "SequenciaId" });
            DropIndex("dbo.Usuarios", new[] { "Nome" });
            DropIndex("dbo.Tratamentoes", new[] { "PacienteId" });
            DropIndex("dbo.Tratamentoes", new[] { "FisioterapeutaId" });
            DropIndex("dbo.Pessoas", new[] { "UsuarioId" });
            DropIndex("dbo.Pessoas", new[] { "Cpf" });
            DropIndex("dbo.Pessoas", new[] { "Email" });
            DropIndex("dbo.Sequencias", new[] { "FisioterapeutaId" });
            DropIndex("dbo.Sessaos", new[] { "TratamentoId" });
            DropIndex("dbo.Sessaos", new[] { "SequenciaId" });
            DropIndex("dbo.EsqueletoResultadoSessaos", new[] { "SessaoId" });
            DropIndex("dbo.EstadoEsqueletoes", new[] { "EsqueletoResultadoSessaoId" });
            DropIndex("dbo.EstadoEsqueletoes", new[] { "MovimentoId" });
            DropIndex("dbo.Movimentoes", new[] { "CategoriaId" });
            DropTable("dbo.Joints");
            DropTable("dbo.EnumJoints");
            DropTable("dbo.MovimentoSequencias");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Tratamentoes");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Sequencias");
            DropTable("dbo.Sessaos");
            DropTable("dbo.EsqueletoResultadoSessaos");
            DropTable("dbo.EstadoEsqueletoes");
            DropTable("dbo.Movimentoes");
            DropTable("dbo.Categorias");
        }
    }
}
