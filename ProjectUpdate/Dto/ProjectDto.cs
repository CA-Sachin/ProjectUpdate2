using System.ComponentModel.DataAnnotations;

namespace ProjectUpdateApp.Dto
{
    public class ProjectDto
    {
        public Guid ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }

    }



}
