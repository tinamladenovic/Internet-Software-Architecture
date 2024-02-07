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
    public class CompanyService : CrudService<CompanyDto, Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICrudRepository<Company> repository, ICompanyRepository companyRepository, IMapper mapper) : base(repository, mapper)
        {
            _companyRepository = companyRepository;
        }

        public Result<PagedResult<CompanyDto>> Search(CompanySearchDto companySearch)
        {
            var result = _companyRepository.Search(companySearch)
                                           .Select(company =>
        {
            return new CompanyDto
            {
                Name = company.Name,
                City = company.City,
                Id = company.Id,
                AverageCompanyRating = company.AverageCompanyRating,
                Country = company.Country,
                Description = company.Description,
                //EquipmentStock = company.EquipmentStock,
                Street = company.Street,
                CompanyWorkingHours = company.CompanyWorkingHours,
            };
            }).ToList();
            var pagedResult = new PagedResult<CompanyDto>(result, result.Count());
            return Result.Ok(pagedResult);
        }

    }
}
