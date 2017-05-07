Imports System.Collections.Generic
Imports System.ComponentModel
Namespace Domain
    Public Class MainMenuItem
        Public ReadOnly Property MenuItems() As MenuItem()
        Public Sub New()
            'MenuItems = New MenuItem() {
            '    New MenuItem("Phieu kham cai tien", New ucKhamBenh)
            '    }
        End Sub
    End Class
End Namespace
