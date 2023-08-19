namespace ProjectUpdateApp.Dto
{
    public class UserProjectDto
    {
        public Guid Userid { get; set; }
        public string UserName { get; set; }
        public List<Guid> Projectid { get; set; }
        public string ProjectName { get; set; }
    }
}
