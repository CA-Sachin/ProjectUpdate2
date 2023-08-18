using System.ComponentModel.DataAnnotations;

namespace ProjectUpdateApp.Dto
{
    public class RoleDto
    {   public Guid Roleid { get; set; }
        [Required]
        public string RoleName { get; set;}


    }
}
