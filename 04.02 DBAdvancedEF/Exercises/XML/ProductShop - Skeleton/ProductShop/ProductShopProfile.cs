using System.Xml.Linq;
using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDTO, User>();

            this.CreateMap<ImportProductDTO, Product>();

            this.CreateMap<ImportCategoriesDTO, Category>();
                
            this.CreateMap<ImportCategoryProductDTO,CategoryProduct>();

            this.CreateMap<XDocument, ImportUserDTO>();

            this.CreateMap<Product, ProductDTO>()
                .ForMember(x=>x.Buyer,opt=>opt.MapFrom(p=>$"{p.Buyer.FirstName} {p.Buyer.LastName}"));

            this.CreateMap<User, UsersWithSoldProductsDTO>()
                .ForMember(x => x.ProductsSold, opt => opt.MapFrom(u => u.ProductsSold));

            this.CreateMap<Product, SoldProductDTO>();


        }
    }
}
