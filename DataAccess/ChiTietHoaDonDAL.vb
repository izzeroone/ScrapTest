Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module ChiTietHoaDonDAL
#Region "Insert or update"
        Public Function InsertChiTietHoaDon(ByVal chiTietHoaDon As ChiTietHoaDonDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = chiTietHoaDon.MaHoaDon})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = chiTietHoaDon.TenThuoc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = chiTietHoaDon.TenDonVi})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Integer, .Value = chiTietHoaDon.SoLuong})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = chiTietHoaDon.DonGia})
            Return ExecuteNoneQuery("insertchitiethoadon", param)
        End Function
#End Region
#Region "Get"

        Public Function GetAllChiTietHoaDon(ByVal maHoaDon As String) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maHoaDon})
            Return ExecuteQuery("getallchitiethoadon", param)
        End Function
#End Region
#Region "Delete"
        Public Function DeleteAllChiTietHoaDon(ByVal maHoaDon As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maHoaDon})
            Return ExecuteNoneQuery("deleteallchitiethoadon", param)
        End Function
#End Region

    End Module
End Namespace
