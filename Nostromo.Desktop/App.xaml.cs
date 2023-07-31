using System.Windows;

using Nostromo.Desktop.helpers;

namespace Nostromo.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            AppContext applicationContext = new AppContext();
            AppSettings appSettings = new AppSettings();
            LanguageHelper langHelper = new LanguageHelper(appSettings.General.Language);

            var loginView = new LoginView(applicationContext, appSettings, langHelper);
            loginView.Show();
        }
    }
}
