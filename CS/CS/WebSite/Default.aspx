<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v9.3, Version=9.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        td.autoSelectedNodeStyle { background-color: #ff0000; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxTreeList ID="ASPxTreeList1" runat="server" 
            ClientInstanceName="treeList" AutoGenerateColumns="False"
            DataSourceID="AccessDataSource1" KeyFieldName="EmployeeID" 
            ParentFieldName="ReportsTo" OnDataBound="ASPxTreeList1_DataBound"
            OnHtmlRowPrepared="ASPxTreeList1_HtmlRowPrepared" OnSelectionChanged="ASPxTreeList1_SelectionChanged">
            <SettingsSelection Enabled="True" />
            <SettingsBehavior ProcessSelectionChangedOnServer="true" />
            <Columns>
                <dx:TreeListTextColumn FieldName="LastName" VisibleIndex="0">
                </dx:TreeListTextColumn>
                <dx:TreeListTextColumn FieldName="FirstName" VisibleIndex="1">
                </dx:TreeListTextColumn>
                <dx:TreeListTextColumn FieldName="Title" VisibleIndex="2">
                </dx:TreeListTextColumn>
                <dx:TreeListTextColumn FieldName="Country" VisibleIndex="3">
                </dx:TreeListTextColumn>
                <dx:TreeListTextColumn FieldName="HomePhone" VisibleIndex="4">
                </dx:TreeListTextColumn>
                <dx:TreeListTextColumn FieldName="ReportsTo" VisibleIndex="5">
                </dx:TreeListTextColumn>
            </Columns>
        </dx:ASPxTreeList>
    </div>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
        SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [Title], [Country], [HomePhone], [ReportsTo] FROM [Employees]">
    </asp:AccessDataSource>
    </form>
</body>
</html>