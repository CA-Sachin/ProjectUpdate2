
using System.ComponentModel.DataAnnotations;

namespace ProjectUpdateApp.Dto
{
    public class ProjectUpdateDto
    {
       
        public string ProjectName { get; set; }
       
        public string TaskDetails { get; set; }
        

        public int Workinghrs { get; set; }
        

        public int Billinghrs { get; set; }
        
        

        public  string ProjectStatus { get; set; }
        public string NextPlan { get; set; }
        
    }
}
