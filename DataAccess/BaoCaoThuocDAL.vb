Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module BaoCaoThuocDAL
#Region "For get only"
        ''' <summary>
        ''' Thực hiện hàm lấy báo cáo thuốc từ cơ sở dữ liệu
        ''' </summary>
        ''' <param name="thang"></param>
        ''' <returns></returns>
        Public Function GetBaoCaoThuoc(ByVal thang As Date) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Date, .Value = thang})
            Return ExecuteQuery("getbaocaothuoc", param)
        End Function
#End Region
    End Module
End Namespace

