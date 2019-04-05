<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# OBSOLETE: How to change the style of a parent node's selection checkbox if some of its child nodes are selected


<p><strong>N</strong><strong>o</strong><strong>te:</strong> Starting with version v2011 vol 1, ASPxTreeList provides the option to automatically highlight a parent node if some of its child nodes are selected:<br />
<a href="http://community.devexpress.com/blogs/aspnet/archive/2011/04/26/asp-net-check-box-new-render-state-for-multiple-controls-coming-soon-in-2011-volume-1.aspx"><u>ASP.NET Check Box - New Render State For Multiple Controls (available now in v2011.1)</u></a></p><p>Set the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxTreeListTreeListSettingsSelection_Recursivetopic"><u>ASPxTreeList.SettingsSelection.Recursive</u></a> property to "True" to accomplish this task.</p>


<h3>Description</h3>

<p>This demo illustrates how to change the style of a parent node&#39;s selection checkbox if some of its child nodes are selected. If the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxTreeListTreeListSettingsBehavior_ProcessSelectionChangedOnServertopic"><u>TreeListSettingsBehavior.ProcessSelectionChangedOnServer</u></a> property is set to true, it indicates that the final processing of the event should be performed on the server side, and so a round trip to the server is required. During such a round trip, the corresponding server-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxTreeListASPxTreeList_SelectionChangedtopic"><u>ASPxTreeList.SelectionChanged</u></a> event is fired, which if handled, allows any desired server-side action to be performed. During handling this event, it&#39;s possible to obtain all nodes via the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxTreeListASPxTreeList_CreateNodeIteratortopic"><u>TreeListNodeIterator iterator = ASPxTreeList.CreateNodeIterator()</u></a> object. </p><p>When the server-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxTreeListASPxTreeList_HtmlRowPreparedtopic"><u>ASPxTreeList.HtmlRowPrepared</u></a> event is raised, for a parent node&#39;s selection checkbox, if some of its child nodes are selected, an additional CSS class is added. To obtain the parent node&#39;s selection checkbox, it&#39;s necessary to obtain the corresponding cell of the DevExpress.Web.ASPxTreeList.Internal.TreeListSelectionCell type from the data row&#39;s cells collection.</p>

<br/>


