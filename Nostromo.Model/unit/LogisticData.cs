namespace Nostromo.Model
{
    public class LogisticData
    {
        public Guid IdParent { get; set; }

        public string CosmalIdentifier { get; set; }

        #region Constructors
        public LogisticData()
        {
            CosmalIdentifier = string.Empty;
        }
        #endregion
    }
}
