Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module DangNhapBUS
#Region "1.Insert & Update"

        ''' <summary>
        ''' Thực hiện đăng nhập
        ''' </summary>
        ''' <param name="tenDangNhap"></param>
        ''' <param name="matKhau"></param>
        ''' <returns></returns>
        Public Function DangNhap(ByVal tenDangNhap As String, ByVal matKhau As String) As Boolean
            Return DangNhapDAL.DangNhap(tenDangNhap, matKhau)
        End Function
#End Region
    End Module
End Namespace