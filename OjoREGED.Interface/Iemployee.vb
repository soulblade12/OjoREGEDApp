Imports OjoREGEDApp.BO


Public Interface Iemployee
    Inherits ICrud(Of Employee)

    Function GetByName(id As Integer)
    Sub AddUser(firstName As String, middleName As String, lastName As String, telephone As String)
End Interface
