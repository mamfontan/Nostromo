namespace Nostromo.Model
{
    public class OperationGroup : BaseObject
    {
        public Guid Id { get; set; }

        public Guid IdModule { get; set; }

        public string Description { get; set; }

        public IEnumerable<Operation> Operations { get; set; }

        #region Constructors
        public OperationGroup()
        {
            Id = Guid.NewGuid();
            Description = string.Empty;

            Operations = new List<Operation>();
        }
        #endregion
    }
}
