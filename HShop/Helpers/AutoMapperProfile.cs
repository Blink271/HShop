using AutoMapper;
using HShop.Data;
using HShop.ViewModels;

namespace HShop.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<RegisterVM, KhachHang>();
        }

    }
}
