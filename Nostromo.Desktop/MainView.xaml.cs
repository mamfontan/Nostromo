using System;
using System.Windows;
using System.Windows.Controls;

using Nostromo.Desktop.controls;
using Nostromo.Desktop.helpers;

namespace Nostromo.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : BaseView
    {
        #region Constructors
        public MainView()
        {
            InitializeComponent();

            ApplicationContext = null;
            LanguageHelper = new LanguageHelper(LANGUAGE.ENGLISH);
        }

        public MainView(AppContext appContext)
        {
            InitializeComponent();

            ApplicationContext = appContext;
            LanguageHelper = new LanguageHelper(LANGUAGE.ENGLISH);
        }

        public MainView(AppContext appContext, LanguageHelper langHelper)
        {
            InitializeComponent();

            ApplicationContext = appContext;
            LanguageHelper = langHelper;
        }
        #endregion

        #region Private methods

        private void SetTitle()
        {
            this.Title = "Nostromo";
        }

        private void HookEvents()
        {
        }

        private void LoadComponents()
        {
            LoadUnitTree();
            LoadComponentTree();
        }

        private void LoadUnitTree()
        {
            ucUnitTree unitTree = new ucUnitTree(ApplicationContext);
            Grid.SetRow(unitTree, 0);
            Grid.SetColumn(unitTree, 0);
            gridLeft.Children.Add(unitTree);
        }

        private void LoadComponentTree()
        {
            ucConfigurationItemsTree configurationItemsTree = new ucConfigurationItemsTree();

            Grid.SetRow(configurationItemsTree, 2);
            Grid.SetColumn(configurationItemsTree, 0);
            gridLeft.Children.Add(configurationItemsTree);
        }
        #endregion

        #region Event response methods
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetTitle();
            HookEvents();

            LoadComponents();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            WServiceHelper wsHlerper = new WServiceHelper("https://localhost:7139/api/");
            if (ApplicationContext != null && ApplicationContext.User != null)
            {
                wsHlerper.Logout(ApplicationContext.User.Id);
            }

            Application.Current.Shutdown();
        }
        #endregion
    }
}
