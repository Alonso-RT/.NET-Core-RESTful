using Application.Features.Articulos.Commands.AddArticle;
using Application.Features.Articulos.Commands.UpdateArticle;
using Application.Features.Articulos.Queries.GetAllArticles;
using Application.Features.Articulos.Queries.GetArticlesByStore;
using Application.Features.Clientes.Commands.AddClient;
using Application.Features.Clientes.Commands.UpdateClient;
using Application.Features.Clientes.Queries.GetClientInfo;
using Application.Features.Tiendas.Commands.AddStore;
using Application.Features.Tiendas.Commands.UpdateStore;
using Application.Features.Tiendas.Queries.GetStoreList;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfile
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region tblCliente
            CreateMap<tblCliente, ClientInfoDto>().ReverseMap();
            CreateMap<tblCliente, AddClientCommand>().ReverseMap();
            CreateMap<tblCliente, UpdateClientCommand>().ReverseMap();
            #endregion

            #region tblTienda
            CreateMap<tblTienda, StoreListDto>().ReverseMap();  
            CreateMap<tblTienda, AddStoreCommand>().ReverseMap();
            CreateMap<tblTienda, UpdateStoreCommand>().ReverseMap();
            #endregion

            #region tblArticulo
            CreateMap<tblArticulo, ArticlesListDto>().ReverseMap();
            CreateMap<tblArticulo, GetArticlesByStoreDto>().ReverseMap();
            CreateMap<tblArticulo, AddArticleCommand>().ReverseMap();
            CreateMap<tblArticulo, UpdateArticleCommand>().ReverseMap();
            #endregion
        }
    }
}
