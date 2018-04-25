namespace NLayerApp.BLL.DTO
{
    public class PhoneDTO: SystemParametersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public virtual PhoneInfoDTO PhoneInfo { get; set; } 
    }
}