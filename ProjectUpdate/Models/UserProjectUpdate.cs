namespace ProjectUpdateApp.Models
{
    public class UserProjectUpdate
    {
        public Guid Id { get; set; }
        public Guid ProjectUpdateID { get; set; }

        public User User { get; set; }
        public ProjectUpdate ProjectUpdate { get; set; }
    }
}
