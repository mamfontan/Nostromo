namespace Nostromo.Model
{
    public class AccessLog
    {
        public Guid IdUser { get; set; }

        public DateTime Login { get; set; }

        public DateTime? Logout { get; set; }

        public string MechineName { get; set; }
    }
}
