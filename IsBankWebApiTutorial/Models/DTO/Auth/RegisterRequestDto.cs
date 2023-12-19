namespace IsBankWebApiTutorial.Models.DTO.Auth
{
    public class RegisterRequestDto
    {
        public string EMail { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; 
    }
}
