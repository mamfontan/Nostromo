namespace Nostromo.Model
{
    public class Operation : BaseObject
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        #region Constructors
        public Operation()
        {
            Id = Guid.NewGuid();
            Code = string.Empty;
            Description = string.Empty;
        }
        #endregion
    }
}
