var currentEditableVisibleIndex;
var lastCountryID;
var lastCityID;
function CountriesCombo_SelectedIndexChanged(s, e) {
	var currentCountryID = s.GetSelectedItem().value;
	lastCountryID = currentCountryID;
	lastCityID = -1;
	PageMethods.GetCities(lastCountryID, CitiesCombo_OnSuccessGetCities);
}
function IntializeGlobalVariables(grid) {
	lastCountryID = grid.cplastCountryID;
	currentEditableVisibleIndex = -1;
	lastCityID = -1;
}
function OnInit(s, e) {
	IntializeGlobalVariables(s);
}
function OnEndCallback(s, e) {
	IntializeGlobalVariables(s);
}
function CitiesCombo_OnSuccessGetCities(response) {
	CityID.ClearItems();
	for (var i in response) {
		CityID.AddItem(response[i].CityName, response[i].CityID);
	}

	if (lastCityID == -1)
		CityID.SetSelectedIndex(0);
	else if (lastCityID > -1) {
		CityID.SetSelectedItem(CityID.FindItemByValue(lastCityID));
		lastCityID = -1;
	}
}
function OnBatchEditStartEditing(s, e) {
	currentEditableVisibleIndex = e.visibleIndex;
	var currentCountryID = grid.batchEditApi.GetCellValue(currentEditableVisibleIndex, "CountryID");
	var currentCityID = grid.batchEditApi.GetCellValue(currentEditableVisibleIndex, "CityID")
	lastCityID = currentCityID;
	if (lastCountryID == currentCountryID)
		CityID.SetSelectedItem(CityID.FindItemByValue(lastCityID));
	else {
		if (currentCountryID == null) {
			CityID.SetSelectedIndex(-1);
			return;
		}
		lastCountryID = currentCountryID;
		PageMethods.GetCities(lastCountryID, CitiesCombo_OnSuccessGetCities);
	}
}
function OnBatchEditEndEditing(s, e) {
	currentEditableVisibleIndex = -1;
}