namespace MedicalEquipmentCompany.Model.Dtos
{
    public class EquipmentDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
        public double Price { get; set; }
        public long CompanyId { get; set; }
    }
}
