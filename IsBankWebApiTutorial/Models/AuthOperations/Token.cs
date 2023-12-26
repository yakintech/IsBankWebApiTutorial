namespace IsBankWebApiTutorial.Models.AuthOperations
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
