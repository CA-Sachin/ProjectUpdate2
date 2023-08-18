using System.ComponentModel.DataAnnotations;

namespace ProjectUpdateApp.Dto
{
    public class UserUpdateDetailsDto
    {
        public Guid Id { get; set; }
       
      public string Username { get; set; }
       

        public Guid ProjectUpdateID { get; set; }
        public string ProjectName { get; set; }


        public string TaskDetails { get; set; }
        public string ProjectStatus { get; set; }
        public int Workinghrs { get; set; }
        
        public int Billinghrs { get; set; }
       
        public string NextPlan { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Reasonoflessbilling { get; set; }



    }
}
