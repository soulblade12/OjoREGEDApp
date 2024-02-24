Imports System.Data
Imports System.Data.SqlClient
Imports OjoREGED.[Interface]
Imports OjoREGEDApp.BO


Public Class EmployeeSP
    Implements Iemployee

    Private strConn As String
    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader
    Public Sub New()
        strConn = "Server=.\BSISqlExpress;Database=OjoREGED;Trusted_Connection=True;"
        conn = New SqlConnection(strConn)
    End Sub

    Public Sub AddUser(firstName As String, middleName As String, lastName As String, telephone As String) Implements Iemployee.AddUser
        Try
            Dim strsp = "dbo.InsertEmployee"
            cmd = New SqlCommand(strsp, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@FirstName", firstName)
            cmd.Parameters.AddWithValue("@MiddleName", middleName)
            cmd.Parameters.AddWithValue("@LastName", lastName)
            cmd.Parameters.AddWithValue("@Telephone", telephone)

            conn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Function Create(obj As Employee) As Integer Implements ICrud(Of Employee).Create
        Throw New NotImplementedException()
    End Function

    Public Function GetAll() As List(Of Employee) Implements ICrud(Of Employee).GetAll
        Dim Employees As New List(Of Employee)
        Try
            Dim strSql = "SELECT * FROM Employee"

            cmd = New SqlCommand(strSql, conn)
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read
                    Dim Emp As New Employee
                    Emp.EmpId = CInt(dr("Employee_ID"))
                    Emp.EmpFirstName = dr("First_Name").ToString()
                    Emp.EmpMidName = dr("Middle_Name").ToString()
                    Emp.EmpLastName = dr("Last_Name").ToString()
                    Emp.EmpTelp = dr("Telephone").ToString()
                    Employees.Add(Emp)
                End While
            End If
            dr.Close()

            Return Employees
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Function

    Public Function GetById(id As Integer) As Employee Implements ICrud(Of Employee).GetById
        Throw New NotImplementedException()
    End Function

    Public Function Update(obj As Employee) As Integer Implements ICrud(Of Employee).Update
        Throw New NotImplementedException()
    End Function

    Public Function Delete(id As Integer) As Integer Implements ICrud(Of Employee).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Iemployee_GetByName(employeeID As Integer) Implements Iemployee.GetByName
        Try
            Dim Employe As New List(Of Employee)
            cmd = New SqlCommand("dbo.ReadEmployee", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@EmployeeID", employeeID)
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                Dim employ As New Employee
                employ.EmpId = CInt(dr("Employee_ID"))
                employ.EmpFirstName = dr("First_Name").ToString()
                employ.EmpMidName = dr("Middle_Name").ToString()
                employ.EmpLastName = dr("Last_Name").ToString()
                employ.EmpTelp = dr("Telephone").ToString()

                Return employ
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            conn.Close()


        End Try
    End Function

    Public Function AddEmployeeLoc(EmployeeID As Integer, EmployeeAddress As String, EmployeeCity As String, EmployeeProvince As String, EmployeePostal As String) As Integer Implements Iemployee.AddEmployeeLoc
        Try
            Dim Strstoreprod = "dbo.InsertLocationEmployee"
            cmd = New SqlCommand(Strstoreprod, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID)
            cmd.Parameters.AddWithValue("@LocationAddress", EmployeeAddress)
            cmd.Parameters.AddWithValue("@City", EmployeeCity)
            cmd.Parameters.AddWithValue("@Province", EmployeeProvince)
            cmd.Parameters.AddWithValue("@Postalcode", EmployeePostal)
            conn.Open()
            Dim result = cmd.ExecuteNonQuery()
            If result <> 1 Then
                Throw New ArgumentException("Customer not created")
            End If
            Return result
        Catch sqlex As SqlException
            Throw New ArgumentException(sqlex.Message & " " & sqlex.Number)
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Function

    Public Function CreateEmployeeSchedule(IdEmployee As Integer, Datebook As Date, MaxOrder As Integer) As Object Implements Iemployee.CreateEmployeeSchedule
        Try
            Dim Strstoreprod = "dbo.CreateEmployeeSchedule"
            cmd = New SqlCommand(Strstoreprod, conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@EmployeeID", IdEmployee)
            cmd.Parameters.AddWithValue("@Date", Datebook)
            cmd.Parameters.AddWithValue("@MaxOrder", MaxOrder)

            conn.Open()
            Dim result = cmd.ExecuteNonQuery()
            If result <> 1 Then
                Throw New ArgumentException("Schedule not created")
            End If
            Return result
        Catch sqlex As SqlException
            Throw New ArgumentException(sqlex.Message & " " & sqlex.Number)
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Function
End Class
