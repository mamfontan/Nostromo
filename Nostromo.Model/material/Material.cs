namespace Nostromo.Model
{
    internal class Material : BaseObject
    {
        public Guid Id { get; set; }

        public TypologyObject MaterialType { get; set; }

        public TypologyObject MaterialSubtype { get; set; }

        public string NatoCode { get; set; }

        public string Description { get; set; }

        public bool SpecialCare { get; set; }

        #region Constructors
        public Material()
        {
            Id = new Guid();

            MaterialType = new TypologyObject();
            MaterialSubtype = new TypologyObject();

            NatoCode = string.Empty;
            Description = string.Empty;
            SpecialCare = false;
        }
        #endregion
    }
}
