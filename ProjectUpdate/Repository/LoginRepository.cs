using ProjectUpdateApp.Data;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;

namespace ProjectUpdateApp.Repository
{
    public class LoginRepository:ILoginRepository
    {
        private readonly DataContext _Context;

        public LoginRepository(DataContext Context)
        {
            _Context = Context;
        }
        public string UserLogin(LoginDto logindto)
        {
            var user = _Context.User.Where(x => x.Email == logindto.Email && x.Password == logindto.Password).FirstOrDefault();
            if (user == null)
            {
                return "Invalid User";
            }
            return "valid";

        }
    }
}
