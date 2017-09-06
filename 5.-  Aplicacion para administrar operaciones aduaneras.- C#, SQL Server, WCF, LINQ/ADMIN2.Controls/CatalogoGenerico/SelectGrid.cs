using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ADMIN2.Controls
{
    public class SelectGrid
    {
        public static void SelectRowByIndex(System.Windows.Controls.DataGrid dataGrid, int rowIndex)
        {
            if (!dataGrid.SelectionUnit.Equals(System.Windows.Controls.DataGridSelectionUnit.FullRow))
                throw new ArgumentException("The SelectionUnit of the DataGrid must be set to FullRow.");

            if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
                throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));

            dataGrid.SelectedItems.Clear();
            /* set the SelectedItem property */
            object item = dataGrid.Items[rowIndex]; // = Product X
            dataGrid.SelectedItem = item;

            System.Windows.Controls.DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as System.Windows.Controls.DataGridRow;
            if (row == null)
            {
                /* bring the data item (Product object) into view
                 * in case it has been virtualized away */
                dataGrid.ScrollIntoView(item);
                row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as System.Windows.Controls.DataGridRow;
            }
            //TODO: Retrieve and focus a DataGridCell object
        }

        public static void SelectCellsByIndexes(System.Windows.Controls.DataGrid dataGrid, IList<KeyValuePair<int, int>> cellIndexes)
        {
            if (!dataGrid.SelectionUnit.Equals(System.Windows.Controls.DataGridSelectionUnit.Cell))
                throw new ArgumentException("The SelectionUnit of the DataGrid must be set to Cell.");

            if (!dataGrid.SelectionMode.Equals(System.Windows.Controls.DataGridSelectionMode.Extended))
                throw new ArgumentException("The SelectionMode of the DataGrid must be set to Extended.");

            dataGrid.SelectedCells.Clear();
            foreach (KeyValuePair<int, int> cellIndex in cellIndexes)
            {
                int rowIndex = cellIndex.Key;
                int columnIndex = cellIndex.Value;

                if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
                    throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));

                if (columnIndex < 0 || columnIndex > (dataGrid.Columns.Count - 1))
                    throw new ArgumentException(string.Format("{0} is an invalid column index.", columnIndex));

                object item = dataGrid.Items[rowIndex]; //= Product X
                System.Windows.Controls.DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as System.Windows.Controls.DataGridRow;
                if (row == null)
                {
                    dataGrid.ScrollIntoView(item);
                    row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as System.Windows.Controls.DataGridRow;
                }
                if (row != null)
                {
                    System.Windows.Controls.DataGridCell cell = GetCell(dataGrid, row, columnIndex);
                    if (cell != null)
                    {
                        System.Windows.Controls.DataGridCellInfo dataGridCellInfo = new System.Windows.Controls.DataGridCellInfo(cell);
                        dataGrid.SelectedCells.Add(dataGridCellInfo);
                        cell.Focus();
                    }
                }
            }
        }

        public static System.Windows.Controls.DataGridCell GetCell(System.Windows.Controls.DataGrid dataGrid, System.Windows.Controls.DataGridRow rowContainer, int column)
        {
            if (rowContainer != null)
            {
                System.Windows.Controls.Primitives.DataGridCellsPresenter presenter = FindVisualChild<System.Windows.Controls.Primitives.DataGridCellsPresenter>(rowContainer);
                if (presenter == null)
                {
                    /* if the row has been virtualized away, call its ApplyTemplate() method
                     * to build its visual tree in order for the DataGridCellsPresenter
                     * and the DataGridCells to be created */
                    rowContainer.ApplyTemplate();
                    presenter = FindVisualChild<System.Windows.Controls.Primitives.DataGridCellsPresenter>(rowContainer);
                }
                if (presenter != null)
                {
                    System.Windows.Controls.DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as System.Windows.Controls.DataGridCell;
                    if (cell == null)
                    {
                        /* bring the column into view
                         * in case it has been virtualized away */
                        dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
                        cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as System.Windows.Controls.DataGridCell;
                    }
                    return cell;
                }
            }
            return null;
        }

        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
}
