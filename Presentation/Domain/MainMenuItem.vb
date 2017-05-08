Imports System.Collections.Generic
Imports System.ComponentModel
Namespace Domain
    Public Class MainMenuItem
        Public ReadOnly Property MenuItems() As MenuItem()
        Public Sub New()
            MenuItems = New MenuItem() {
                New MenuItem("Phieu kham cai tien", New ucPhieuKhamBenh),
                New MenuItem("Danh sach loai benh", New ucLoaiBenh),
                New MenuItem("Danh sách cách dùng", New ucLoaiCachDung),
                New MenuItem("Danh sách đơn vị", New ucLoaiDonVi)
                }
        End Sub
    End Class
End Namespace
