using FluentResults;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Repository.Interface
{
    public interface ICompanyRepository
    {
        public List<Company> Search(CompanySearchDto companySearch);
    }
}
