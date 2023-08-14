using ProjectUpdateApp.Dto;

namespace ProjectUpdateApp.IService
{
    public interface ILoginService
    {
        public string UserLogin(LoginDto logindto);
    }
}
