using System.ComponentModel.DataAnnotations;

namespace ProjectUpdateApp.Models
{
    public class Role
    {
        public Guid RoleId { get; set; }
        [MaxLength(20)]
        public string RoleName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDelete { get; set;}

    }
}
