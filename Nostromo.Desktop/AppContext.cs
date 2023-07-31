using Nostromo.Model;
using System.Reflection;

namespace Nostromo.Desktop
{
    public class AppContext
    {
        public string MechineName {  get => System.Environment.MachineName; }

        public string AppVersion { get => Assembly.GetExecutingAssembly().GetName().Version.ToString(); }

        public User? User { get; set; }

        #region Constructors
        public AppContext()
        {
            User = null;
        }
        #endregion
    }
}
