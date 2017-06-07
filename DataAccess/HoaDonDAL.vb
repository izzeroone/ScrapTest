Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module HoaDonDAL
#Region "Insert"
        ''' <summary>
        ''' Thực hiện hàm thêm hoặc cập nhật hóa đơn
        ''' </summary>
        ''' <param name="hoaDon"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateHoaDon(ByVal hoaDon As HoaDonDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = hoaDon.MaKhamBenh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = hoaDon.TienKham})
            Return ExecuteNoneQuery("insertorupdatehoadon", param)
        End Function
#End Region
#Region "Check"
        ''' <summary>
        ''' Thực hiện hàm kiểm tra hóa đơn của mã khám bệnh tương ứng đã trả chưa
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function IsHoaDonPay(ByVal maKhamBenh) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteScalar("ishoadonpay", param)
        End Function
#End Region
#Region "Get"
        ''' <summary>
        ''' Thực hiện hàm lấy hóa đơn của mã bệnh nhân tương ứng
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetHoaDon(ByVal maKhamBenh As String) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteQuery("gethoadon", param)
        End Function
#End Region
#Region "Delete"
        ''' <summary>
        ''' Thực hiện hàm xóa hóa đơn của mã bệnh nhân tương ứng
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function DeleteHoaDon(ByVal maKhamBenh As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteNoneQuery("deletehoadon", param)
        End Function
#End Region
    End Module
End Namespace
