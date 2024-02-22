Imports OjoREGEDApp.BO

Public Interface Iemployee(Of T)
    Inherits ICrud(Of Employee)

    Function GetByName(ByVal id As Integer) As T
End Interface
