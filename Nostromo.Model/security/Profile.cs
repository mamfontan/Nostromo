namespace Nostromo.Model
{
    public class Profile : BaseObject
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public IEnumerable<Module> Modules { get; set; }

        #region Constructors
        public Profile()
        {
            Id = Guid.NewGuid();
            Code = string.Empty;
            Name = string.Empty;
            Active = true;

            Modules = new List<Module>();
        }
        #endregion
    }
}
