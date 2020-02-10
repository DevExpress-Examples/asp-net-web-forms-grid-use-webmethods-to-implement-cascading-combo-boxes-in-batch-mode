using DevExpress.Web;
using System;
using System.Collections;
using System.Web.Services;

public partial class _Default : System.Web.UI.Page {	
	protected void Page_Init(object sender, EventArgs e) {
		((GridViewDataComboBoxColumn)grid.Columns["CountryID"]).PropertiesComboBox.DataSource = DataProvider.GetCountries();
		((GridViewDataComboBoxColumn)grid.Columns["CityID"]).PropertiesComboBox.DataSource = DataProvider.GetCities();

		if(!IsPostBack)
			grid.DataBind();
	}
		
	protected void grid_DataBinding(object sender, EventArgs e) {
		grid.DataSource = DataProvider.GetCustomers();
	}

	protected void grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e) {
		foreach(var args in e.InsertValues)
			DataProvider.InsertCustomer((string)args.NewValues["CustomerName"], (int)args.NewValues["CountryID"], (int)args.NewValues["CityID"]);
		foreach(var args in e.UpdateValues)
			DataProvider.UpdateCustomer((int)args.Keys["CustomerID"], (string)args.NewValues["CustomerName"], (int)args.NewValues["CountryID"], (int)args.NewValues["CityID"]);
		foreach(var args in e.DeleteValues)
			DataProvider.DeleteCustomer((int)args.Keys["CustomerID"]);
		e.Handled = true;
	}

	[WebMethod]
	public static IEnumerable GetCities(int countryID) {
		return DataProvider.GetCities(countryID);
	}
}