Imports System.Collections.Generic
Imports System.ComponentModel

Public Class MainMenuItem
    Public ReadOnly Property MenuItems() As MenuItem()
    Public Sub New()
        MenuItems = New MenuItem() {
            New MenuItem("Phieu kham", New ucKhamBenh),
            New MenuItem("Phieu kham cai tien", New ucKhamBenhCaiTIen)
            }
    End Sub
End Class
