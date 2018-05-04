namespace ACS.BLL.DTO
{
    public class ApplicationLoginDTO
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public int? UserId { get; set; }
    }
}
