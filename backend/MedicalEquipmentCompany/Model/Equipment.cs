using MedicalEquipmentCompany.Model.Result;
using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Numerics;

namespace MedicalEquipmentCompany.Model
{
    public class Equipment : Entity
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Description { get; private set; }
        public int QuantityInStock { get; private set; }
        public double Price { get; private set; }
        public long CompanyId { get; private set; }

        public Equipment() { }
        public Equipment( string name, string type, string destription, int quantityInStock, double price, long companyId)
        {
            Name = name;
            Type = type;
            Description = destription;
            QuantityInStock = quantityInStock;
            Price = price;
            CompanyId = companyId;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name.");
            if (string.IsNullOrWhiteSpace(Type)) throw new ArgumentException("Invalid Type.");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid Descritpion.");
            if (QuantityInStock < 0) throw new ArgumentException("Invalid QuantityInStock.");
            if (Price < 0) throw new ArgumentException("Invalid Price.");
            if (CompanyId < 0) throw new ArgumentException("Invalid company id.");
        }
    }
}
