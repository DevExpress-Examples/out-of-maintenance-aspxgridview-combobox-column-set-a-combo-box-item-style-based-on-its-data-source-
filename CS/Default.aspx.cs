using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            ASPxGridView1.StartEdit(0);
    }

    protected void ASPxGridView1_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    {
        if (e.Column.FieldName != "ProductID") return;
        var cmb = (ASPxComboBox)e.Editor;
        cmb.ItemRowPrepared += Cmb_ItemRowPrepared;
    }

    private void Cmb_ItemRowPrepared(object sender, ListBoxItemRowPreparedEventArgs e)
    {
        string tooltip = String.Format("Price is ${0}", Convert.ToInt32(e.Item.GetFieldValue("UnitPrice")).ToString());
        e.Row.CssClass += " forHint";
        if (Convert.ToBoolean(e.Item.GetFieldValue("Discontinued")) == true)
        {
            e.Row.BackColor = System.Drawing.Color.Red;
            e.Row.ForeColor = System.Drawing.Color.White;
            e.Row.Font.Italic = true;
            tooltip += ", this product is discontinued";
        }
        e.Row.Attributes.Add("tooltip", tooltip);
    }

    protected void ASPxGridView1_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        e.RowError = "It's not possible to edit data in this example";
    }
}