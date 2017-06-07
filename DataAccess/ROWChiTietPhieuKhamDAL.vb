Imports Entities.Entities
Imports System.Collections.ObjectModel
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module ROWChiTietPhieuKhamDAL
#Region "For get only"
        ''' <summary>
        ''' Thực hiện hàm lấy chi tiết phiếu khám hiển thị
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetChiTietPhieuKhamByMaKhamBenh(ByRef maKhamBenh As String) As DataTable
            Dim param As New List(Of NpgsqlParameter)

            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})

            Return ExecuteQuery("getchitietphieukhambymakhambenh", param)

        End Function
#End Region
    End Module
End Namespace