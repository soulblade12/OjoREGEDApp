Imports OjoREGEDApp.BO


Public Interface Iemployee
    Inherits ICrud(Of Employee)

    Function GetByName(id As Integer)
    Sub AddUser(firstName As String, middleName As String, lastName As String, telephone As String)
    Function AddEmployeeLoc(EmployeeID As Integer, EmployeeAddress As String, EmployeeCity As String, EmployeeProvince As String, EmployeePostal As String) As Integer
    Function CreateEmployeeSchedule(IdEmployee As Integer, Datebook As Date, MaxOrder As Integer)
End Interface
