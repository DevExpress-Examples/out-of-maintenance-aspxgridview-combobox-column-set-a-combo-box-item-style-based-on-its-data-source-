<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.17.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function onShowing(s, e) {
            e.contentElement.innerHTML = '<div>' + e.targetElement.getAttribute("tooltip") + '</div>';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource1" 
                KeyFieldName="OrderID;ProductID" OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize" 
                OnRowValidating="ASPxGridView1_RowValidating">
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="OrderID" ReadOnly="True" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="ProductID" VisibleIndex="2">
                        <PropertiesComboBox DataSourceID="AccessDataSource2" TextField="ProductName" ValueField="ProductID" 
                            ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
                <ClientSideEvents EndCallback="function(s, e) { ASPxClientHint.Update(); }" />
            </dx:ASPxGridView>
            <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb" 
                SelectCommand="SELECT [OrderID], [ProductID] FROM [Order Details]"></asp:AccessDataSource>
            <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/nwind.mdb" 
                SelectCommand="SELECT [ProductID], [ProductName], [Discontinued], [UnitPrice] FROM [Products]"></asp:AccessDataSource>
            <dx:ASPxHint ID="ASPxHint1" runat="server" TargetSelector=".forHint" TriggerAction="Hover" Position="Right" Offset="-4">
                <ClientSideEvents Showing="onShowing" />
            </dx:ASPxHint>
        </div>
    </form>
</body>
</html>
