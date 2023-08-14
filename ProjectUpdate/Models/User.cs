using System.ComponentModel.DataAnnotations;

namespace ProjectUpdateApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Username { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
       // public ICollection<UserProject> UserProjects{ get; set; }
        public ICollection<UserProjectUpdate> UserProjectUpdates{ get; set; }
       // public ICollection<ProjectUpdate> ProjectUpdates{ get; set; }
        
     

    }
}
