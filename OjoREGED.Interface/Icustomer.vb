Imports OjoREGEDApp.BO

Public Interface Icustomer
    Inherits ICrud(Of Customer)

    Function InsertCustAddress(CustID As Integer, StreetAdrs As String, City As String, Province As String, Postalcode As String)
    Function InsertCustomer(FirstName As String, MiddleName As String, LastName As String, Telp As String, EmailAdr As String)
    Function UpdateSubscription(CustID As Integer, NewSubscription As Integer)
End Interface
