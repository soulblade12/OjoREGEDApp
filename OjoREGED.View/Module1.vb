Imports OjoREGEDApp.BO

Module Module1

    'EMPLOYEE
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
    Sub AddEmployeeLocation(EmployeeID As Integer, EmployeeAddress As String, EmployeeCity As String, EmployeeProvince As String, EmployeePostal As String)
        Dim empDAL As New OjoREGEDApp.DAL.EmployeeSP
        empDAL.AddEmployeeLoc(EmployeeID, EmployeeAddress, EmployeeCity, EmployeeProvince, EmployeePostal)
    End Sub

    Sub AddSchedule(employeeID As Integer, specificDate As Date, maxOrder As Integer)

        Dim empDAL As New OjoREGEDApp.DAL.EmployeeSP
        empDAL.CreateEmployeeSchedule(employeeID, specificDate, maxOrder)
    End Sub
    'CUSTOMER
    Sub GetAllCustomer()

        Dim custDAL As New OjoREGEDApp.DAL.CustomerSP

        Dim customer = custDAL.GetAll()
        For Each cust As Customer In customer
            Console.WriteLine("{0}-{1}-{2}-{3}-{4}-{5}-{6}", cust.CustID, cust.CustFirstName, cust.CustMiddleName, cust.CustLastName, cust.CustSubcriptionID, cust.CustEmailAddress, cust.CustTelephone)
        Next
    End Sub


    Sub Main()

        'insert new location for employee
        'AddEmployeeLocation(15, "Jalan Kenangan", "Wakatobi", "Lampung", "55162")
        'AddSchedule(5, #2/24/2024#, 5)
        GetAllCustomer()

    End Sub

End Module