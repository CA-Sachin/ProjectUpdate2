using System.ComponentModel.DataAnnotations;

namespace ProjectUpdateApp.Dto
{
    public class UserProjectUpdateDto
    {
        [Required]   
        public string ProjectName { get; set; }

        [Required]

        public string TaskDetails { get; set; }
        [Required]

        public string ProjectStatus { get; set; }
        [Required]

        public int Workinghrs { get; set; }


        [Required]
        public int Billinghrs { get; set; }
        

        
        [Required]

        public string NextPlan { get; set; }
      


    }
}
