Imports System.Data.SqlClient
Imports OjoREGED.Interface
Imports OjoREGEDApp.BO

Public Class CustomerSP
    Implements Icustomer
    Private strConn As String
    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader
    Public Sub New()
        strConn = "Server=.\BSISqlExpress;Database=OjoREGED;Trusted_Connection=True;"
        conn = New SqlConnection(strConn)
    End Sub

    Public Function InsertCustAddress(CustID As Integer, StreetAdrs As String, City As String, Province As String, Postalcode As String) As Object Implements Icustomer.InsertCustAddress
        Throw New NotImplementedException()
    End Function

    Public Function Create(obj As Customer) As Integer Implements ICrud(Of Customer).Create
        Throw New NotImplementedException()
    End Function

    Public Function GetAll() As List(Of Customer) Implements ICrud(Of Customer).GetAll
        Dim Customer As New List(Of Customer)
        Try
            Dim strSql = "SELECT * FROM Customer"

            cmd = New SqlCommand(strSql, conn)
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read
                    Dim Cust As New Customer
                    Cust.CustID = CInt(dr("Customer_ID"))
                    Cust.CustFirstName = dr("First_Name").ToString()
                    Cust.CustMiddleName = dr("Middle_Name").ToString()
                    Cust.CustLastName = dr("Last_Name").ToString()
                    Cust.CustTelephone = dr("Telephone").ToString()
                    Cust.CustSubcriptionID = CInt(dr("Subscription_ID"))
                    Cust.CustEmailAddress = dr("Email_Address").ToString()

                    Customer.Add(Cust)
                End While
            End If
            dr.Close()

            Return Customer
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Function

    Public Function GetById(id As Integer) As Customer Implements ICrud(Of Customer).GetById
        Throw New NotImplementedException()
    End Function

    Public Function Update(obj As Customer) As Integer Implements ICrud(Of Customer).Update
        Throw New NotImplementedException()
    End Function

    Public Function Delete(id As Integer) As Integer Implements ICrud(Of Customer).Delete
        Throw New NotImplementedException()
    End Function
End Class
