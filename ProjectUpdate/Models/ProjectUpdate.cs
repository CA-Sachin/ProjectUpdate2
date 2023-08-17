using ProjectUpdateApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectUpdateApp.Models
{
    public class ProjectUpdate
    {
        public Guid ProjectUpdateID { get; set; }
            
       
        
        [MaxLength(50)]
        public string ProjectName { get; set; }
        [MaxLength(500)]

        public string TaskDetails { get; set; }
         public string ProjectStatus { get; set; }
        public int Workinghrs { get; set; }

        public int Billinghrs { get; set; }
        [MaxLength(1000)]
        public string NextPlan { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(100)]
        public string Reasonoflessbilling { get; set; }


       public ICollection<UserProjectUpdate> UserProjectUpdates { get; set; }









    }
}
