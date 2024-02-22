Imports System.Data
Imports System.Data.SqlClient
Imports OjoREGED.Interface
Imports OjoREGEDApp.BO



Public Class GetEmployeeSP
    Implements Iemployee

    Private strConn As String
    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader

    Public Sub New()
        strConn = "Server=.\BSISqlExpress;Database=OjoREGED;Trusted_Connection=True;"
        conn = New SqlConnection(strConn)
    End Sub
    Public Function GetByName(employeeID As Integer) As Employee Implements Iemployee.GetByName
        Dim employeee As New Employee

        Using conn As New SqlConnection(strConn)
            Dim employeee As New Employee
            conn.Open()

            Using cmd As New SqlCommand("dbo.ReadEmployee", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID)

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()

                        employeee.EmpId = CInt(reader("Employee_ID"))
                        employeee.EmpFirstName = reader("First_Name").ToString()
                        employeee.EmpMidName = reader("Middle_Name").ToString()
                        employeee.EmpLastName = reader("Last_Name").ToString()
                        employeee.EmpTelp = reader("Telephone").ToString()
                        'employeee.Add(Emp)
                        Return employeee
                    End If
                End Using
            End Using
        End Using


    End Function





    Public Function Create(obj As Employee) As Integer Implements ICrud(Of Employee).Create
        Throw New NotImplementedException()
    End Function

    Public Function GetAll() As List(Of Employee) Implements ICrud(Of Employee).GetAll
        Dim Employees As New List(Of Employee)
        Try
            Dim strSql = "SELECT * FROM Employee"

            conn = New SqlConnection(strConn)
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
End Class
