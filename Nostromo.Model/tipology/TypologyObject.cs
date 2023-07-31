namespace Nostromo.Model
{
    public class TypologyObject : BaseObject
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        #region Constructors
        public TypologyObject()
        { 
            Id = Guid.Empty;

            Code = string.Empty;
            Description = string.Empty;
        }
        #endregion
    }
}
