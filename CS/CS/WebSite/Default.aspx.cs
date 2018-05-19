using System;
using System.Collections.Generic;
using DevExpress.Web.ASPxTreeList;

public partial class _Default : System.Web.UI.Page {
    protected List<string> AutoSelectedNodeKeys {
        get {
            if (Session["AutoSelectedNodeKeys"] == null)
                Session["AutoSelectedNodeKeys"] = new List<string>();
            return (List<string>)Session["AutoSelectedNodeKeys"];
        }
        set { Session["AutoSelectedNodeKeys"] = value; }
    }
    protected void Page_Init(object sender, EventArgs e) {
        if (!IsCallback && !IsPostBack)
            AutoSelectedNodeKeys.Clear();
    }

    protected void ASPxTreeList1_DataBound(object sender, EventArgs e) {
        ASPxTreeList treeList = (ASPxTreeList)sender;
        treeList.ExpandAll();
    }
    protected void ASPxTreeList1_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e) {
        if (e.RowKind == TreeListRowKind.Data) {
            if (AutoSelectedNodeKeys.Contains(e.NodeKey)) {
                for (int index = 1; index < e.Row.Cells.Count; index++) {
                    if (e.Row.Cells[index].GetType() == typeof(DevExpress.Web.ASPxTreeList.Internal.TreeListSelectionCell))
                        e.Row.Cells[index].CssClass += " autoSelectedNodeStyle";
                }
            }
        }
    }
    protected void ASPxTreeList1_SelectionChanged(object sender, EventArgs e) {
        ASPxTreeList treeList = (ASPxTreeList)sender;
        TreeListNodeIterator iterator = treeList.CreateNodeIterator();
        AutoSelectedNodeKeys.Clear();
        while (iterator.Current != null) {
            TreeListNode node = iterator.Current;
            if (node.Selected && node.ParentNode != null) {
                TreeListNode parent = node.ParentNode;
                while (parent != null) {
                    if (!AutoSelectedNodeKeys.Contains(parent.Key))
                        AutoSelectedNodeKeys.Add(parent.Key);
                    parent = parent.ParentNode;
                }
            }
            iterator.GetNext();
        }
    }
}