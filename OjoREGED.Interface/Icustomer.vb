Imports OjoREGEDApp.BO

Public Interface Icustomer
    Inherits ICrud(Of Customer)

    Function InsertCustAddress(CustID As Integer, StreetAdrs As String, City As String, Province As String, Postalcode As String)
End Interface
