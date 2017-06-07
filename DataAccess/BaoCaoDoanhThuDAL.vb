Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module BaoCaoDoanhThuDAL
#Region "For get only"
        ''' <summary>
        ''' Thực hiện hàm lấy báo cáo doanh thu từ cơ sở dữ liệu
        ''' </summary>
        ''' <param name="thang"></param>
        ''' <returns></returns>
        Public Function getBaoCaoDoanhThu(ByVal thang As Date) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Date, .Value = thang})
            Return ExecuteQuery("getbaocaodoanhthu", param)
        End Function
#End Region
    End Module
End Namespace
