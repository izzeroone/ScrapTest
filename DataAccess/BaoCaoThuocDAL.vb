Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module BaoCaoThuocDAL
#Region "For get only"
        Public Function GetBaoCaoThuoc(ByVal thang As Date) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Date, .Value = thang})
            Return ExecuteQuery("getbaocaothuoc", param)
        End Function
#End Region
    End Module
End Namespace

