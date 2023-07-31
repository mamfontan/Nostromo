namespace Nostromo.Model
{
    public class User : BaseObject
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public IEnumerable<Profile> Profiles { get; set; }

        public IEnumerable<Unit> Units { get; set; }

        #region Constructors
        public User()
        {
            Id = Guid.NewGuid();
            Login = string.Empty;
            Password = string.Empty;
            Active = true;

            Profiles = new List<Profile>();
            Units = new List<Unit>();
        }
        #endregion
    }
}
