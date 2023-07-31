using Nostromo.Desktop.helpers;
using Nostromo.Model;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Documents;

namespace Nostromo.Desktop
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : BaseView
    {
        private List<KeyValuePair<LANGUAGE, string>> _languageList = new List<KeyValuePair<LANGUAGE, string>>();

        #region Constructors
        public LoginView()
        {
            InitializeComponent();

            ApplicationContext = null;
            AppSettings = new AppSettings();
            LanguageHelper = new LanguageHelper(LANGUAGE.ENGLISH);
        }

        public LoginView(AppContext appContext)
        {
            InitializeComponent();

            ApplicationContext = appContext;
            AppSettings = new AppSettings();
            LanguageHelper = new LanguageHelper(LANGUAGE.ENGLISH);
        }

        public LoginView(AppContext appContext, AppSettings appSettings, LanguageHelper langHelper)
        {
            InitializeComponent();

            ApplicationContext = appContext;
            AppSettings = appSettings;
            LanguageHelper = langHelper;
        }
        #endregion

        #region Private methods
        private void LoadLanguageList()
        {
            _languageList = new List<KeyValuePair<LANGUAGE, string>>()
            {
                new KeyValuePair<LANGUAGE, string>(LANGUAGE.ENGLISH, LanguageHelper.Translate("liEnglish")),
                new KeyValuePair<LANGUAGE, string>(LANGUAGE.SPANISH, LanguageHelper.Translate("liSpanish")),
            };

            cmbLanguage.ItemsSource = _languageList;
            cmbLanguage.DisplayMemberPath = "Value";
            cmbLanguage.SelectedValuePath = "Key";
            cmbLanguage.SelectedIndex = 0;
        }

        private void HookEvents()
        {
            btnLogin.Click += btnLogin_Click;

            cmbLanguage.SelectionChanged += cmbLanguage_SelectionChanged;
        }

        private bool ValidateForm()
        {
            var result = true;

            var strUser = txtUser.Text.Trim();
            var strPassword = txtPassword.Password.Trim();

            if (string.IsNullOrEmpty(strUser) || string.IsNullOrEmpty(strPassword))
                result = false;

            return result;
        }

        private void ShowMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                lblInfo.Content = string.Empty;
            }
            else
            {
                lblInfo.Content = message;
            }
        }
        #endregion

        #region Event response methods
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = string.Format("{0}{1}", LanguageHelper.Translate("lblVersion"), ApplicationContext?.AppVersion);

            LoadLanguageList();
            HookEvents();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationContext == null)
                return;

            if (ValidateForm())
            {
                var strUser = txtUser.Text.Trim();
                var strPassword = txtPassword.Password.Trim();

                WServiceHelper wsHlerper = new WServiceHelper("https://localhost:7139/api/");
                ApplicationContext.User = wsHlerper.Login(strUser, strPassword, ApplicationContext.MechineName);

                if (ApplicationContext.User != null && ApplicationContext.User.Active)
                {
                    MainView mView = new MainView(ApplicationContext, LanguageHelper);
                    mView.Show();

                    this.Hide();
                }
                else
                {
                    ShowMessage("User or password incorrect, or the user is not active");
                }
            }
        }

        private void cmbLanguage_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cmbLanguage.SelectedItem != null)
            {
                var selectedLanguage = ((KeyValuePair<LANGUAGE, string>)cmbLanguage.SelectedItem).Key;
                AppSettings.General.Language = selectedLanguage;
                AppSettings.Save();

                LanguageHelper = new LanguageHelper(selectedLanguage);

                this.Title = string.Format("{0}{1}", LanguageHelper.Translate("lblVersion"), ApplicationContext?.AppVersion);
                gbUserIdentification.Header = LanguageHelper.Translate("gbUserIdentification");
                lblUser.Content = LanguageHelper.Translate("lblUser");
                lblPassword.Content = LanguageHelper.Translate("lblPassword");
                lblLanguage.Content = LanguageHelper.Translate("lblLanguage");
                btnLogin.Content = LanguageHelper.Translate("btnLogin");
            }
        }
        #endregion
    }
}
