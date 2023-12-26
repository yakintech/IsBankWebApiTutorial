namespace IsBankWebApiTutorial.Models.DTO.Auth
{
    public class LoginRequestDto
    {
        public string EMail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
