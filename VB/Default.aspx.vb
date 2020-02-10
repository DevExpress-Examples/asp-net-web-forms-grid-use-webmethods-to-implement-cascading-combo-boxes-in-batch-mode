Option Infer On

Imports DevExpress.Web
Imports System
Imports System.Collections
Imports System.Web.Services

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		CType(grid.Columns("CountryID"), GridViewDataComboBoxColumn).PropertiesComboBox.DataSource = DataProvider.GetCountries()
		CType(grid.Columns("CityID"), GridViewDataComboBoxColumn).PropertiesComboBox.DataSource = DataProvider.GetCities()

		If Not IsPostBack Then
			grid.DataBind()
		End If
	End Sub

	Protected Sub grid_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
		grid.DataSource = DataProvider.GetCustomers()
	End Sub

	Protected Sub grid_BatchUpdate(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs)
		For Each args In e.InsertValues
			DataProvider.InsertCustomer(CStr(args.NewValues("CustomerName")), CInt(Math.Truncate(args.NewValues("CountryID"))), CInt(Math.Truncate(args.NewValues("CityID"))))
		Next args
		For Each args In e.UpdateValues
			DataProvider.UpdateCustomer(CInt(Math.Truncate(args.Keys("CustomerID"))), CStr(args.NewValues("CustomerName")), CInt(Math.Truncate(args.NewValues("CountryID"))), CInt(Math.Truncate(args.NewValues("CityID"))))
		Next args
		For Each args In e.DeleteValues
			DataProvider.DeleteCustomer(CInt(Math.Truncate(args.Keys("CustomerID"))))
		Next args
		e.Handled = True
	End Sub

	<WebMethod>
	Public Shared Function GetCities(ByVal countryID As Integer) As IEnumerable
		Return DataProvider.GetCities(countryID)
	End Function
End Class