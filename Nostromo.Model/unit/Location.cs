namespace Nostromo.Model
{
    public class Location : BaseObject
    {
        public Guid IdParent { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        #region Constructors
        public Location()
        {
            Code = string.Empty;
            Description = string.Empty;
        }
        #endregion
    }
}
