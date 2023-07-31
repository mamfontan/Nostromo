using Nostromo.Desktop.helpers;
using System.Windows;

namespace Nostromo.Desktop
{
    public class BaseView : Window
    {
        public AppContext? ApplicationContext { get; set; }

        public AppSettings AppSettings { get; set; }

        public LanguageHelper LanguageHelper { get; set; }
    }
}
