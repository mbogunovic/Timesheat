namespace TimeshEAT.Business.Models
{
    public class LoginResultModel
    {
        public UserModel User { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsActive { get; set; }
    }
}
