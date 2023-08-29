using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectUpdateApp.Data;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext Context)
        {
            _context = Context;
        }
        public bool CreateUser(User register)
        {  
            if(_context.User.Any(u=>u.Email == register.Email))
            {
                return false;
            }
            _context.User.Add(register);
            return Save();
        }

        public bool DeleteUser(User register)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(Guid id, User register)
        {
            var x = _context.User.Where(x => x.Id == id).FirstOrDefault();
            x.Username = register.Username;
            x.Email = register.Email;
            x.Password = register.Password;
            x.CreatedDate = register.CreatedDate;
            x.IsActive = true;
            x.IsDelete = false;
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UserExists(Guid userId)
        {
            return _context.User.Any(x => x.Id == userId);
        }

        public ICollection<User> GetRegistration()
        {
            return _context.User.ToList();
        }

        public UserDto GetDetils(string email)
        {
           var u=_context.User.Where(x=>x.Email==email).FirstOrDefault();
            var k = new UserDto()
            {
                Username = u.Username,
                Email = email,
                Password = u.Password,
                Id = u.Id,
                Repeat_Password = "";
                
            };
            return (k);
        }

        public User GetUserbyId(Guid id)
        {
            return _context.User.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
