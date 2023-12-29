<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128534636/15.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T356740)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DataProvider.cs](./CS/App_Code/DataProvider.cs) (VB: [DataProvider.vb](./VB/App_Code/DataProvider.vb))
* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
* [JavaScript.js](./CS/JavaScript.js) (VB: [JavaScript.js](./VB/JavaScript.js))
<!-- default file list end -->
# ASPxGridView - How to implement cascading combo boxes in Batch Edit mode by using WebMethods


<p>This example shows how to implement cascading combo boxes in <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewEditingSettings_Modetopic">EditingSettings</a> "Batch" mode by using <a href="https://msdn.microsoft.com/en-us/library/byxd99hx(v=vs.90).aspx">WebMethods</a>. The example is based on <a href="https://www.devexpress.com/Support/Center/p/T124512">ASPxGridView - How to implement cascading comboboxes in Batch Edit mode</a> and <a href="https://www.devexpress.com/Support/Center/p/T356687">How to populate a cascading ASPxComboBox by using WebMethods</a> examples. The main idea is to remove EditTemplate from <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxGridViewtopic">ASPxGridView</a> and replace the <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxComboBoxtopic">ASPxComboBox</a> <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxAutoCompleteBoxBase_Callbacktopic">Callback</a> by <a href="https://msdn.microsoft.com/en-us/library/byxd99hx(v=vs.90).aspx">WebMethods</a> to refresh the child's combo box item collection. This will improve the server's response time and reduce the server's load.<br><br><strong>See also: <br></strong><a href="https://www.devexpress.com/Support/Center/p/T124512">ASPxGridView - How to implement cascading comboboxes in Batch Edit mode</a><strong><br></strong></p>

<br/>


