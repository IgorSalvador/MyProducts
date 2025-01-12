using AutoMapper;
using DevIO.AppMvc.Models.ViewModels;
using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Produtos;
using System;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DevIO.AppMvc.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            return new MapperConfiguration(x =>
            {
                foreach (var profile in profiles)
                {
                    x.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}