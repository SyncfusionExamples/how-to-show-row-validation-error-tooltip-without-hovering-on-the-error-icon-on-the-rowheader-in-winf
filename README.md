# How to show row validation error tooltip without hovering on the error icon on the RowHeader in WinForms DataGrid (SfDataGrid)?

## About the sample

This example illustrates how to show row validation error tooltip without hovering on the error icon on the RowHeader in WinForms DataGrid (SfDataGrid).

By default, [WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDataGrid) displays validation error tooltip when hovering on the error icon in the row header cell. However, you can show tooltip immediately after the value is changed without hovering on the row header cell by using [SfToolTip](https://www.syncfusion.com/winforms-ui-controls/tooltip).

```C#

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

```

![Validation Error ToolTip](ValidationToolTip.gif)


## Requirements to run the demo

Visual Studio 2015 and above versions.
