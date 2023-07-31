using Nostromo.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Nostromo.Desktop.controls
{
    /// <summary>
    /// Interaction logic for ucUnitTree.xaml
    /// </summary>
    public partial class ucUnitTree : UserControl
    {
        private AppContext? _appContext;

        #region Constructors
        public ucUnitTree()
        {
            InitializeComponent();

            _appContext = null;
        }

        public ucUnitTree(AppContext appContext)
        {
            InitializeComponent();

            _appContext = appContext;
        }
        #endregion

        #region Private methods
        private void ClearTreeNodes()
        {
            treeUnits.Items.Clear();
        }

        private void CreateNoEmptyTree(string data)
        {
            ClearTreeNodes();

            TreeViewItem rootNode = new TreeViewItem();
            rootNode.Header = data;

            treeUnits.Items.Add(rootNode);
        }

        private List<TreeViewItem> CreateUnitTree(IEnumerable<Unit> units, Guid? idParent)
        {
            List<TreeViewItem> result = new List<TreeViewItem>();

            if (units != null && units.Any())
            {
                List<Unit> actualList = new List<Unit>();
                if (idParent == null)
                    actualList = units.Where(x => x.IdParent == null).ToList();
                else
                    actualList = units.Where(x => x.IdParent == idParent).ToList();

                foreach (var actualUnit in actualList)
                {
                    TreeViewItem newItem = new TreeViewItem();
                    newItem.Header = actualUnit.TackMark + Constants.SEPARATOR + actualUnit.Name;

                    newItem.ItemsSource = CreateUnitTree(units, actualUnit.Id);
                    result.Add(newItem);
                }
            }

            return result;
        }

        private List<TreeViewItem> CreateUnitsTree(IEnumerable<Unit> units, Guid? idParent)
        {
            ClearTreeNodes();

            List<TreeViewItem> result = new List<TreeViewItem>();

            if (units != null && units.Any())
            {
                var basesList = units.Where(x => x.IdParent == null);
                foreach (var actualBase in basesList)
                {
                    TreeViewItem newItem = new TreeViewItem();
                    newItem.Header = actualBase.TackMark + Constants.SEPARATOR + actualBase.Name;

                    var childs = CreateUnitsTree(units, actualBase.Id);
                    if (childs != null)
                    {
                        newItem.Items.Add(childs);
                    }
                    result.Add(newItem);
                }
            }
            else
            {
                CreateNoEmptyTree("No units available");
            }

            return result;
        }
        #endregion

        #region Event response methods
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_appContext == null || _appContext.User == null)
            {
                CreateNoEmptyTree("No user available");
            }
            else
            {
                var tree = CreateUnitTree(_appContext.User.Units, null);

                treeUnits.ItemsSource = tree;
            }
        }
        #endregion
    }
}
