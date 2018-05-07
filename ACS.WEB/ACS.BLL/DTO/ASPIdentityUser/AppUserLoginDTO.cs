namespace ACS.BLL.DTO
{
    public class AppUserLoginDTO
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public int? UserId { get; set; }
    }
}
