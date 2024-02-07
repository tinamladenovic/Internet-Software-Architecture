using AutoMapper;
using FluentResults;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Repository;
using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service.Crud.Interface;
using MedicalEquipmentCompany.Service.Interface;

namespace MedicalEquipmentCompany.Service
{
    public class CompanyWorkingHoursService : CrudService<CompanyWorkingHoursDto, CompanyWorkingHours>, ICompanyWorkingHoursService
    {
        private readonly ICompanyWorkingHoursRepository _companyWorkingHoursRepository;
        private readonly IMapper _mapper;

        public CompanyWorkingHoursService(ICrudRepository<CompanyWorkingHours> repository, ICompanyWorkingHoursRepository companyWorkingHoursRepository, IMapper mapper) : base(repository, mapper)
        {
            _companyWorkingHoursRepository = companyWorkingHoursRepository;
           
        }

     

    }
}
