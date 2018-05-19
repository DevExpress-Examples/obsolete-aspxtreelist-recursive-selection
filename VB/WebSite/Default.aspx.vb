Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports DevExpress.Web.ASPxTreeList

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Property AutoSelectedNodeKeys() As List(Of String)
		Get
			If Session("AutoSelectedNodeKeys") Is Nothing Then
				Session("AutoSelectedNodeKeys") = New List(Of String)()
			End If
			Return CType(Session("AutoSelectedNodeKeys"), List(Of String))
		End Get
		Set(ByVal value As List(Of String))
			Session("AutoSelectedNodeKeys") = value
		End Set
	End Property
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsCallback) AndAlso (Not IsPostBack) Then
			AutoSelectedNodeKeys.Clear()
		End If
	End Sub

	Protected Sub ASPxTreeList1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
		Dim treeList As ASPxTreeList = CType(sender, ASPxTreeList)
		treeList.ExpandAll()
	End Sub
	Protected Sub ASPxTreeList1_HtmlRowPrepared(ByVal sender As Object, ByVal e As TreeListHtmlRowEventArgs)
		If e.RowKind = TreeListRowKind.Data Then
			If AutoSelectedNodeKeys.Contains(e.NodeKey) Then
				For index As Integer = 1 To e.Row.Cells.Count - 1
					If e.Row.Cells(index).GetType() Is GetType(DevExpress.Web.ASPxTreeList.Internal.TreeListSelectionCell) Then
						e.Row.Cells(index).CssClass &= " autoSelectedNodeStyle"
					End If
				Next index
			End If
		End If
	End Sub
	Protected Sub ASPxTreeList1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim treeList As ASPxTreeList = CType(sender, ASPxTreeList)
		Dim iterator As TreeListNodeIterator = treeList.CreateNodeIterator()
		AutoSelectedNodeKeys.Clear()
		Do While iterator.Current IsNot Nothing
			Dim node As TreeListNode = iterator.Current
			If node.Selected AndAlso node.ParentNode IsNot Nothing Then
				Dim parent As TreeListNode = node.ParentNode
				Do While parent IsNot Nothing
					If (Not AutoSelectedNodeKeys.Contains(parent.Key)) Then
						AutoSelectedNodeKeys.Add(parent.Key)
					End If
					parent = parent.ParentNode
				Loop
			End If
			iterator.GetNext()
		Loop
	End Sub
End Class