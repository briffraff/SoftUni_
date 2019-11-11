using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Employees;
using FastFood.Web.ViewModels.Items;
using FastFood.Web.ViewModels.Orders;

namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using Models;

    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionName, y => y.MapFrom(p => p.Name));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();
                //.ForMember(x=>x.Position.Name,opt=>opt.Ignore());

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(z => z.Position.Name));

            //Categories

            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, opt => opt.MapFrom(c => c.CategoryName));

            //Items

            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(i => i.Name));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, opt => opt.MapFrom(i => i.Category.Name));

            //orders

            this.CreateMap<CreateOrderInputModel, Order>();

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.OrderId, opt => opt.MapFrom(o => o.Id))
                .ForMember(x => x.Employee, opt => opt.MapFrom(o => o.Employee.Name))
                .ForMember(x => x.DateTime, opt => opt.MapFrom(o => o.DateTime.ToString("g")));



        }
    }
}
