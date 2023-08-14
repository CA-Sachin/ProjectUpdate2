using ProjectUpdateApp.Dto;

namespace ProjectUpdateApp.IRepository
{
    public interface ILoginRepository
    {
        public string UserLogin(LoginDto logindto);
    }
}
