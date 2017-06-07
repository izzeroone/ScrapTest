Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module ChiTietThuocDAL
#Region "1. Get"
        ''' <summary>
        ''' Thực hiện hàm lấy chi tiêt thuốc của mã khám bệnh tương ứng
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetChiTietThuoc(ByVal maKhamBenh As String) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteQuery("getallthuocbymakhambenh", param)
        End Function
#End Region
    End Module
End Namespace
