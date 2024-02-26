using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Purchase, PurchaseDetailDTO>()
                .ForMember(x => x.Person, opt => opt.Ignore())
                .ForMember(x => x.Product, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new PurchaseDetailDTO
                    {
                        Product = model.Product.Name,
                        Id = model.Id,
                        Date = model.Date,
                        Person = model.Person.Name
                    };
                    return dto;
                });
        }
    }
}
