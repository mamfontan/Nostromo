namespace Nostromo.Model
{
    public class ConfItem : BaseObject
    {
        public Guid Id { get; set; }

        public Guid IdUnit { get; set; }

        public Guid? IdParent { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        #region Constructors
        public ConfItem()
        {
            Id = Guid.NewGuid();
            IdParent = null;
            Code = string.Empty;
            Description = string.Empty;
        }
        #endregion
    }
}
