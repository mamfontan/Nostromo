using Nostromo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Nostromo.Security
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Profile> _profileList = new ObservableCollection<Profile>();
        private ObservableCollection<Module> _moduleList = new ObservableCollection<Module>();

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Private methods
        private void HideAuditFields()
        {
            List<string> columnsToHide = new List<string>() { "Id", "cUser", "cDate", "mUser", "mDate", "Operations", "Modules" };
            HideAuditFields(dgModules, columnsToHide);
            HideAuditFields(dgProfiles, columnsToHide);
        }

        private void HideAuditFields(DataGrid dataGrid, List<string> columnsToHide)
        {
            foreach (DataGridColumn column in dataGrid.Columns)
            {
                if (column != null && column.Header != null)
                {
                    if (columnsToHide.Contains(column.Header.ToString()))
                    {
                        column.Visibility = Visibility.Hidden;
                    }
                }
            }
        }
        #endregion

        #region Event response methods
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "NOSTROMO - Security Application";

            dgProfiles.ItemsSource = _profileList;
            dgModules.ItemsSource = _moduleList;

            HideAuditFields();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion
    }
}
