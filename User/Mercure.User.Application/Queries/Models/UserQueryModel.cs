namespace Mercure.User.Application.Queries
{
    public class UserQueryModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public List<ProfileQueryModel> Profiles { get; set; }
    }
}