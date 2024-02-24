Imports OjoREGEDApp.BO

Module Module1
    Sub GetAllEmployee()

        Dim empDAL As New OjoREGEDApp.DAL.EmployeeSP

        Dim Employees = empDAL.GetAll()
        For Each employe As Employee In Employees
            Console.WriteLine("{0}-{1}-{2}-{3}-{4}", employe.EmpId, employe.EmpFirstName, employe.EmpMidName, employe.EmpLastName, employe.EmpTelp)
        Next
    End Sub

    Sub GetOneEmployee(id As Integer)
        Dim empDAL As New OjoREGEDApp.DAL.EmployeeSP
        'GetDB()
        Dim singleEmp = empDAL.Iemployee_GetByName(id)
        If singleEmp IsNot Nothing Then
            Console.WriteLine("{0}-{1}-{2}-{3}-{4}", singleEmp.EmpId, singleEmp.EmpFirstName, singleEmp.EmpMidName, singleEmp.EmpLastName, singleEmp.EmpTelp)
        Else
            Console.WriteLine("Customer not found")
        End If
    End Sub

    Sub AddEmployee(name_First As String, name_Mid As String, name_Last As String, Telp As String)
        Dim empDAL As New OjoREGEDApp.DAL.EmployeeSP
        empDAL.AddUser(name_First, name_Mid, name_Last, Telp)
    End Sub


    Sub Main()



    End Sub

End Module