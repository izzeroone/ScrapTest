Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module ChiTietHoaDonDAL
#Region "Insert or update"
        ''' <summary>
        ''' Thực hiện hàm cập nhật chi tiết hóa đơn hoặc thêm mới nếu chưa có ở cơ sở dữ liệu
        ''' </summary>
        ''' <param name="chiTietHoaDon"></param>
        ''' <returns></returns>
        Public Function InsertChiTietHoaDon(ByVal chiTietHoaDon As ChiTietHoaDonDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = chiTietHoaDon.MaChiTietPhieuKham})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = chiTietHoaDon.DonGiaThucTe})
            Return ExecuteNoneQuery("insertchitiethoadon", param)
        End Function
#End Region
#Region "Get"
        ''' <summary>
        ''' Thực hiện hàm lấy tất cả chi tiết hóa đơn của mã khám bệnh tương ứng ở cơ sở dữ liệu
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetAllChiTietHoaDon(ByVal maKhamBenh As String) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteQuery("getallchitiethoadon", param)
        End Function
#End Region
#Region "Delete"
        ''' <summary>
        ''' Thực hiện hàm xóa tất cả chi tiết hóa đơn của mã khám bệnh tương ứng ở cơ sở dữ liệu
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function DeleteAllChiTietHoaDon(ByVal maKhamBenh As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteNoneQuery("deleteallchitiethoadon", param)
        End Function
#End Region

    End Module
End Namespace
