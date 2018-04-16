Option Infer On

Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            ASPxGridView1.StartEdit(0)
        End If
    End Sub

    Protected Sub ASPxGridView1_CellEditorInitialize(ByVal sender As Object, ByVal e As ASPxGridViewEditorEventArgs)
        If e.Column.FieldName <> "ProductID" Then
            Return
        End If
        Dim cmb = CType(e.Editor, ASPxComboBox)
        AddHandler cmb.ItemRowPrepared, AddressOf Cmb_ItemRowPrepared
    End Sub

    Private Sub Cmb_ItemRowPrepared(ByVal sender As Object, ByVal e As ListBoxItemRowPreparedEventArgs)
        Dim tooltip As String = String.Format("Price is ${0}", Convert.ToInt32(e.Item.GetFieldValue("UnitPrice")).ToString())
        e.Row.CssClass &= " forHint"
        If Convert.ToBoolean(e.Item.GetFieldValue("Discontinued")) = True Then
            e.Row.BackColor = System.Drawing.Color.Red
            e.Row.ForeColor = System.Drawing.Color.White
            e.Row.Font.Italic = True
            tooltip &= ", this product is discontinued"
        End If
        e.Row.Attributes.Add("tooltip", tooltip)
    End Sub

    Protected Sub ASPxGridView1_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs)
        e.RowError = "It's not possible to edit data in this example"
    End Sub
End Class