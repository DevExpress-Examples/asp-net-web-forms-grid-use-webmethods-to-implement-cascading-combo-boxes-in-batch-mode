<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v19.2, Version=19.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<script src="JavaScript.js"></script>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
			 <dx:ASPxGridView runat="server" OnDataBinding="grid_DataBinding" OnBatchUpdate="grid_BatchUpdate" KeyFieldName="CustomerID" ClientInstanceName="grid" ID="grid">
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="true" ShowNewButtonInHeader="true" ShowDeleteButton="true"></dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn FieldName="CustomerID">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataTextColumn FieldName="CustomerName">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"  Display="None"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Country" FieldName="CountryID" >
                        <PropertiesComboBox ValueField="CountryID" ClientInstanceName="CountryID" TextField="CountryName" ValueType="System.Int32">
                            <ValidationSettings RequiredField-IsRequired="true"  Display="None"></ValidationSettings>
                            <ClientSideEvents SelectedIndexChanged="CountriesCombo_SelectedIndexChanged" />
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="CityID" Width="100px" Caption="City">
                        <PropertiesComboBox ValueType="System.Int32"  TextField="CityName" ValueField="CityID"
							ClientInstanceName="CityID">
							<ValidationSettings RequiredField-IsRequired="true"  Display="None"></ValidationSettings>
                        </PropertiesComboBox>                        
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
                <ClientSideEvents Init="OnInit" EndCallback="OnEndCallback" BatchEditStartEditing="OnBatchEditStartEditing" BatchEditEndEditing="OnBatchEditEndEditing" />
                <SettingsEditing Mode="Batch">
                    <BatchEditSettings ShowConfirmOnLosingChanges="true" EditMode="Row" />
                </SettingsEditing>
            </dx:ASPxGridView>
		</div>
	</form>
</body>
</html>
