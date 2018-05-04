namespace ACS.BLL.DTO
{
    public class ApplicationClaimDTO
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public int? UserId { get; set; }
    }
}
