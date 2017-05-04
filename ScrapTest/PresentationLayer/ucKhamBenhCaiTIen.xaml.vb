Imports System.Data

Public Class ucKhamBenhCaiTIen
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim data As DataTable = ExecuteQuery("getallkhambenh")
        dataView.DataContext = data
    End Sub
End Class
