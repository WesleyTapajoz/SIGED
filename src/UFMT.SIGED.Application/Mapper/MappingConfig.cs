using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Application.ViewModels;
using UFMT.SIGED.Domain.Entity;

namespace UFMT.SIGED.Application.Mapper
{
    public static class MappingConfig
    {
        public static void RegisterMap()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                //Configurando o mapeamento automático
                //de classes de domínio para viewModels
                #region configurações de nivel de ensino
                cfg.CreateMap<NivelEnsino, NivelDeEnsinoViewModel>()
                .ReverseMap();

                cfg.CreateMap<NivelEnsino, AdicionarNivelEnsinoViewModel>()
                .ReverseMap();

                cfg.CreateMap<NivelEnsino, AtualizarNivelEnsinoViewModel>()
                .ReverseMap();
                #endregion

                #region configurações de estudante
                cfg.CreateMap<Estudante, EstudanteViewModel>()
                .ReverseMap();

                cfg.CreateMap<Estudante, AdicionarEstudanteViewModel>()
                .ReverseMap();

                cfg.CreateMap<Estudante, AtualizarEstudanteViewModel>()
                .ReverseMap();
                #endregion


            });
        }
    }
}
