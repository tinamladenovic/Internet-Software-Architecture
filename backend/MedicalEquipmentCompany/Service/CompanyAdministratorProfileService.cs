using AutoMapper;
using FluentResults;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service.Crud.Interface;
using MedicalEquipmentCompany.Service.Interface;

namespace MedicalEquipmentCompany.Service
{
    public class CompanyAdministratorProfileService : CrudService<CompanyAdministratorProfileDto, CompanyAdministratorProfile>, ICompanyAdministratorProfileService
    {
        private readonly ICompanyAdministratorProfileRepository _companyAdministratorProfileRepository;
        private readonly IMapper _mapper;

        public CompanyAdministratorProfileService(ICrudRepository<CompanyAdministratorProfile> repository, ICompanyAdministratorProfileRepository companyAdministratorProfileRepository, IMapper mapper) : base(repository, mapper)
        {
            _companyAdministratorProfileRepository = companyAdministratorProfileRepository;
        }

        

    }
}
