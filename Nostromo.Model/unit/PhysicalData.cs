namespace Nostromo.Model
{
    public class PhysicalData
    {
        public Guid IdParent { get; set; }

        public double Beam { get; set; }

        public double Depth { get; set; }

        public double Displacement { get; set; }

        public int Engines { get; set; }

        public double Power { get; set; }

        public int Crew { get; set; }

        #region Constructors
        public PhysicalData()
        {

        }
        #endregion
    }
}
