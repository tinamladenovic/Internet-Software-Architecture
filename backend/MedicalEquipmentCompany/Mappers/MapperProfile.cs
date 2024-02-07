using AutoMapper;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;

namespace MedicalEquipmentCompany.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<AccountDto,  Account>().ReverseMap();
            CreateMap<UserAccountDto, User>().ReverseMap();
            CreateMap<EquipmentDto, Equipment>().ReverseMap();
            CreateMap<CompanyDto, Company>().ReverseMap();
            CreateMap<CompanyAdministratorProfileDto, CompanyAdministratorProfile>().ReverseMap();
            CreateMap<CompanyRatingDto, CompanyRating>().ReverseMap();
            CreateMap<CompanyWorkingHoursDto, CompanyWorkingHours>().ReverseMap();
            CreateMap<ComplainDto, Complain>().ReverseMap();
            CreateMap<DiscountDto, Model.Discount>().ReverseMap();
            CreateMap<EquipmentPickupDto, EquipmentPickup>().ReverseMap();
            CreateMap<EquipmentReservationDto, EquipmentReservation>().ReverseMap();
            CreateMap<LoyaltyClassEntryDto, LoyaltyClassEntry>().ReverseMap();
            CreateMap<LoyaltyProgramDto, LoyaltyProgram>().ReverseMap();
            CreateMap<ReplyDto, Reply>().ReverseMap();
        }
    }
}
