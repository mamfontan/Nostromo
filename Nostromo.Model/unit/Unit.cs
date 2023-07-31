namespace Nostromo.Model
{
    public class Unit : BaseObject
    {
        public Guid Id { get; set; }

        public Guid? IdParent { get; set; }

        public string TackMark { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        #region Constructors
        public Unit()
        {
            Id = Guid.NewGuid();
            IdParent = null;

            TackMark = string.Empty;
            Name = string.Empty;
            Active = true;
        }
        #endregion
    }
}
