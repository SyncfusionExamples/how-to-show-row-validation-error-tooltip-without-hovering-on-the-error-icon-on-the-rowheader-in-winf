using SfDataGrid_Demo;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Drawing;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.Data.Extensions;
using Syncfusion.Windows.Forms;

namespace SfDataGrid_Demo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        #region Constructor

        SfToolTip validationToolTip = new SfToolTip();
        ToolTipInfo toolTipInfo1 = new ToolTipInfo();
        ToolTipItem toolTipItem1 = new ToolTipItem();


        /// <summary>
        /// Initializes the new instance for the Form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            sfDataGrid1.DataSource = new OrderInfoCollection().OrdersListDetails;

            toolTipInfo1.RightToLeft = RightToLeft.Yes;
            toolTipItem1.Style.BackColor = Color.Red;
            toolTipItem1.Style.ForeColor = Color.White;
            toolTipInfo1.Items.AddRange(new ToolTipItem[] { toolTipItem1 });
            this.sfDataGrid1.RowValidating += SfDataGrid1_RowValidating;

            this.sfDataGrid1.CurrentCellEndEdit += SfDataGrid1_CurrentCellEndEdit;
        }

        private void SfDataGrid1_CurrentCellEndEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellEndEditEventArgs e)
        {
            validationToolTip.Hide();
        }

        private void SfDataGrid1_RowValidating(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatingEventArgs e)
        {
            if ((e.DataRow.RowData as OrderInfo).Quantity == 0)
            {
                e.IsValid = false;
                e.ErrorMessage = "Quantity is Zero";

                var X = sfDataGrid1.TableControl.GetCellRectangle(e.DataRow.RowIndex, 0, false).X;
                var Y = sfDataGrid1.TableControl.GetCellRectangle(e.DataRow.RowIndex, 0, false).Y;


                toolTipItem1.Text = e.ErrorMessage;


                validationToolTip.Show(toolTipInfo1, this.sfDataGrid1.PointToScreen(new Point(X, Y)));

            }
        }

        #endregion
    }
}
