using System.ComponentModel.DataAnnotations;

namespace ProjectUpdateApp.Dto
{
    public class UserProjectUpdateDto
    {
        
        public string ProjectName { get; set; }
       

        public string TaskDetails { get; set; }
        public string ProjectStatus { get; set; }
        public string Workinghrs { get; set; }

        public string Billinghrs { get; set; }
        [MaxLength(1000)]
        public string NextPlan { get; set; }
      


    }
}
