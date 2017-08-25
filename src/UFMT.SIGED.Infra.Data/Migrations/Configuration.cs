namespace UFMT.SIGED.Infra.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UFMT.SIGED.Domain.Entity;
    using UFMT.SIGED.Infra.CrossCuting;
    using UFMT.SIGED.Infra.Data.Context;

    internal sealed class Configuration : DbMigrationsConfiguration<UFMT.SIGED.Infra.Data.Context.SIGEDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SIGEDContext context)
        {
            if (context.NiveisDeEnsino.Count() == 0)
            {
                try
                {
                    PopularDados(context);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // TODO: fazer log de erro
                    ex.ToString();
                }
            }
        }

        private void PopularDados(SIGEDContext context)
        {
            var niveisEnsino = new List<NivelEnsino>
            {
                new NivelEnsino {
                    Descricao = "Fundamental",
                },

                new NivelEnsino {
                    Descricao = "Médio",
                },

                new NivelEnsino {
                    Descricao = "Superior",
                },
            };
            context.NiveisDeEnsino.AddRange(niveisEnsino);

            var professores = new List<Professor>
            {
                new Professor {
                    Nome = "Allan Turing",
                    NivelEnsino = niveisEnsino[2],
                    TipoProfessor = 1
                },
                new Professor {
                    Nome = "Eric Evans",
                    NivelEnsino = niveisEnsino[2],
                    TipoProfessor = 1
                },
            };
            context.Professores.AddRange(professores);

            var cursos = new List<Curso>
            {
                new Curso {

                    Descricao = "ASP.NET MVC",
                    DataEncerramento = DateTime.Now,
                    DataInicio = new DateTime(2017, 07, 11),
                },

                new Curso {

                    Descricao = "PHP",
                    DataEncerramento = DateTime.Now,
                    DataInicio = new DateTime(2017, 07, 11),
                },
            };
            context.Cursos.AddRange(cursos);

            var estudantes = new List<Estudante> {

                new Estudante{
                    Nome = "Dilma",
                    DataNascimento = DateTime.Now,
                    NivelEnsino = niveisEnsino[1],
                    Peso = 60,
                    Altura = 1.77M,
                    Cursos = new List<Curso>{
                        cursos[0],
                        cursos[1]
                    }
                },
            };
            context.Estudantes.AddRange(estudantes);

            var usuarios = new List<Usuario>
            {
                new Usuario {
                    Email = "admin@teste.com.br",
                    Senha = CriptografiaSHA256.GeraHashSHA256("Admin@123"),
                    NivelAcesso = NivelAcessoSistema.Administrador,
                    Bloqueado = false,
                    UltimoAcesso = DateTime.Now
                },

                new Usuario {
                    Email = "gestor@teste.com.br",
                    Senha = CriptografiaSHA256.GeraHashSHA256("Gestor@123"),
                    NivelAcesso = NivelAcessoSistema.Gestor,
                    Bloqueado = false,
                    UltimoAcesso = DateTime.Now
                },

                new Usuario {
                    Email = "usuario@teste.com.br",
                    Senha = CriptografiaSHA256.GeraHashSHA256("Usuario@123"),
                    NivelAcesso = NivelAcessoSistema.Usuario,
                    Bloqueado = false,
                    UltimoAcesso = DateTime.Now
                },

            };
            context.Usuarios.AddRange(usuarios);

        }
    }
}
