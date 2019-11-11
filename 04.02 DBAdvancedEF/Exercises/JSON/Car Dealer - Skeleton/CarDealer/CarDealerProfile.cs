using System.Globalization;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {

            this.CreateMap<CarDto, Car>();
            //this.CreateMap<Customer, CustomerDto>()
            //     .ForMember(x => x.BirthDate, y => y.MapFrom(x => x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
