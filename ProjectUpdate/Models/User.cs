using System.ComponentModel.DataAnnotations;

namespace ProjectUpdateApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [MaxLength(30)]
        public string Username { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
       
        public DateTime CreatedDate { get; set; }
      
        public ICollection<UserProjectUpdate> UserProjectUpdates{ get; set; }
      
        
     

    }
}
