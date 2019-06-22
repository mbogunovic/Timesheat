using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.Interfaces
{
	public interface IUserService : IService<UserModel>
    {
        bool Login(string email, string passwordHash);
    }
}
