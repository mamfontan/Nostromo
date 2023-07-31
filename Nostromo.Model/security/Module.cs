namespace Nostromo.Model
{
    public class Module : BaseObject
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public IEnumerable<OperationGroup> OperationGroups { get; set; }

        #region Constructors
        public Module()
        {
            Id = Guid.NewGuid();
            Code = string.Empty;
            Name = string.Empty;
            Active = true;

            OperationGroups = new List<OperationGroup>();
        }
        #endregion
    }
}
