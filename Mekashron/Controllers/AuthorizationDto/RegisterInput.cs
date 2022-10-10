namespace Mekashron.Controllers.AuthorizationDto
{
    public class RegisterInput
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public int CountryId { get; set; }
        public int AId { get; set; }
        public string SingupIp { get; set; }
    }
}
