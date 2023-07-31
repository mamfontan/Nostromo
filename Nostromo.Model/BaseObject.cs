namespace Nostromo.Model
{
    public class BaseObject
    {
        #region Audit fields
        public Guid cUser { get; set; }

        public DateTime cDate { get; set; }

        public Guid? mUser { get; set; }

        public DateTime? mDate { get; set; }
        #endregion
    }
}