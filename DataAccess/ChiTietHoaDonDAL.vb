Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module ChiTietHoaDonDAL
#Region "Insert or update"
        Public Function InsertChiTietHoaDon(ByVal chiTietHoaDon As ChiTietHoaDonDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = chiTietHoaDon.MaChiTietPhieuKham})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = chiTietHoaDon.DonGiaThucTe})
            Return ExecuteNoneQuery("insertchitiethoadon", param)
        End Function
#End Region
#Region "Get"

        Public Function GetAllChiTietHoaDon(ByVal maKhamBenh As String) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteQuery("getallchitiethoadon", param)
        End Function
#End Region
#Region "Delete"
        Public Function DeleteAllChiTietHoaDon(ByVal maKhamBenh As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteNoneQuery("deleteallchitiethoadon", param)
        End Function
#End Region

    End Module
End Namespace
