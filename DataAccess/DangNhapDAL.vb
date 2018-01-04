Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module DangNhapDAL
#Region "1. Get"
        ''' <summary>
        ''' Thực hiện hàm đăng nhập
        ''' </summary>
        ''' <param name="tenDangnhap"></param>
        ''' <param name="matKhau"></param>
        ''' <returns></returns>
        Public Function DangNhap(ByVal tenDangnhap As String, ByVal matKhau As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = tenDangnhap})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = matKhau})
            Return Boolean.Parse(ExecuteScalar("dangnhap", param))
        End Function
#End Region
    End Module
End Namespace
