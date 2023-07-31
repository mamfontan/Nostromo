using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nostromo.Desktop.controls
{
    /// <summary>
    /// Lógica de interacción para ucModules.xaml
    /// </summary>
    public partial class ucModules : UserControl
    {
        private AppContext? _appContext;

        #region Constructors
        public ucModules()
        {
            InitializeComponent();
        }

        public ucModules(AppContext appContext)
        {
            InitializeComponent();

            _appContext = appContext;
        }
        #endregion

        #region Event response methods
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_appContext == null || _appContext.User == null)
            {
                // TODO No modules
            }
            else
            {
                foreach (var actualProfile in _appContext.User.Profiles)
                {
                    foreach (var actualModule in actualProfile.Modules)
                    {

                    }
                }
            }
        }
        #endregion
    }
}
