Imports System.Web
Imports System.Linq
Imports System.Collections
Imports System.Web.SessionState
Imports System.Collections.Generic

Public NotInheritable Class DataProvider

    Private Sub New()
    End Sub

    Private Shared ReadOnly Property Session() As HttpSessionState
        Get
            Return HttpContext.Current.Session
        End Get
    End Property

    Private Shared ReadOnly Property DemoData() As DemoDataObject
        Get
            Const key As String = "DemoDataFB1EB35F-86F5-4FFE-BB23-CBAAF1514C49"
            If Session(key) Is Nothing Then
                Dim obj = New DemoDataObject()
                obj.FillObj()
                Session(key) = obj
            End If
            Return DirectCast(Session(key), DemoDataObject)
        End Get
    End Property

    Public Shared Function GetCustomers() As IEnumerable
        Return DemoData.Customers
    End Function

    Public Shared Sub InsertCustomer(ByVal customerInfo As Customer)
        DemoData.Customers.Add(customerInfo)
    End Sub

    Public Shared Sub InsertCustomer(ByVal customerName As String, ByVal countryID As Integer, ByVal cityID As Integer)
        Dim c = New Customer() With {.CustomerID = DemoData.Customers.Count, .CustomerName = customerName, .CountryID = countryID, .CityID = cityID}

        DemoData.Customers.Add(c)
    End Sub

    Public Shared Sub UpdateCustomer(ByVal customerInfo As Customer)
        Dim c = DemoData.Customers.First(Function(i) i.CustomerID = customerInfo.CustomerID)

        c.CustomerName = customerInfo.CustomerName
        c.CountryID = customerInfo.CountryID
        c.CityID = customerInfo.CityID
    End Sub

    Public Shared Sub UpdateCustomer(ByVal customerID As Integer, ByVal customerName As String, ByVal countryID As Integer, ByVal cityID As Integer)
        Dim c = DemoData.Customers.First(Function(i) i.CustomerID = customerID)

        c.CustomerName = customerName
        c.CountryID = countryID
        c.CityID = cityID
    End Sub

    Public Shared Sub DeleteCustomer(ByVal customerID As Integer)
        Dim c = DemoData.Customers.First(Function(i) i.CustomerID = customerID)
        DemoData.Customers.Remove(c)
    End Sub

    Public Shared Function GetCountries() As IEnumerable
        Return DemoData.Countries
    End Function

    Public Shared Function GetCities() As IEnumerable
        Return DemoData.Cities
    End Function

    Public Shared Function GetCities(ByVal countryID As Integer) As IEnumerable
        Return From c In DemoData.Cities _
               Where c.CountryID = countryID _
               Select c
    End Function
End Class

Public Class DemoDataObject
    Public Property Customers() As List(Of Customer)
    Public Property Countries() As List(Of Country)
    Public Property Cities() As List(Of City)

    Public Sub FillObj()
        Customers = New List(Of Customer)()
        Countries = New List(Of Country)()
        Cities = New List(Of City)()

        Dim uk = CreateCountry("UK")
        Dim usa = CreateCountry("USA")

        CreateCustomer("Jacob", CreateCity("Brighton", uk.CountryID))
        CreateCustomer("Michael", CreateCity("Glasgow", uk.CountryID))
        CreateCustomer("Emily", CreateCity("London", uk.CountryID))
        CreateCustomer("Joshua", CreateCity("Bath", uk.CountryID))
        CreateCustomer("Emma", CreateCity("Manchester", uk.CountryID))
        CreateCustomer("Madison", CreateCity("Wells", uk.CountryID))
        CreateCustomer("Matthew", CreateCity("York", uk.CountryID))
        CreateCustomer("Olivia", CreateCity("Dallas", usa.CountryID))
        CreateCustomer("Ethan", CreateCity("Las Vegas", usa.CountryID))
        CreateCustomer("Hannah", CreateCity("Los Angeles", usa.CountryID))
        CreateCustomer("Abigail", CreateCity("New York City", usa.CountryID))
        CreateCustomer("Isabella", CreateCity("San Francisco", usa.CountryID))
        CreateCustomer("Andrew", CreateCity("Washington D.C.", usa.CountryID))
        CreateCustomer("Daniel", CreateCity("Miami", usa.CountryID))

        CreateCity("Cardiff", uk.CountryID)
        CreateCity("Liverpool", uk.CountryID)
        CreateCity("Oxford", uk.CountryID)
        CreateCity("Atlanta", usa.CountryID)
        CreateCity("Houston", usa.CountryID)
        CreateCity("Phoenix", usa.CountryID)
    End Sub

    Private Function CreateCustomer(ByVal name As String, ByVal city As City) As Customer
        Dim c = New Customer() With {.CustomerName = name, .CityID = city.CityID, .CountryID = city.CountryID, .CustomerID = Customers.Count}

        Customers.Add(c)

        Return c
    End Function

    Private Function CreateCountry(ByVal name As String) As Country
        Dim c = New Country() With {.CountryName = name}
        c.CountryID = Countries.Count
        Countries.Add(c)
        Return c
    End Function

    Private Function CreateCity(ByVal name As String, ByVal countryID As Integer) As City
        Dim c = New City() With {.CityName = name, .CountryID = countryID, .CityID = Cities.Count}

        Cities.Add(c)

        Return c
    End Function
End Class

Public Class Customer
    Public Property CustomerID() As Integer
    Public Property CustomerName() As String
    Public Property CountryID() As Integer
    Public Property CityID() As Integer
End Class

Public Class Country
    Public Property CountryID() As Integer
    Public Property CountryName() As String
End Class

Public Class City
    Public Property CityID() As Integer
    Public Property CityName() As String
    Public Property CountryID() As Integer
End Class