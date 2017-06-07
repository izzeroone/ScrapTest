Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module ThongSoDAL
#Region "1. Get"
        ''' <summary>
        ''' Thực hiện hàm lấy thông số từ cở sơ dữ liệu
        ''' </summary>
        ''' <param name="tenThongSo"></param>
        ''' <returns></returns>
        Public Function GetThongSo(ByVal tenThongSo As String) As String
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = tenThongSo})
            Return ExecuteScalar("getthongso", param)
        End Function
#End Region
#Region "2. Update"
        ''' <summary>
        ''' Thực hiện hàm cập nhật thông số 
        ''' </summary>
        ''' <param name="tenThongSo"></param>
        ''' <param name="giaTri"></param>
        ''' <returns></returns>
        Public Function UpdateThongSo(ByVal tenThongSo As String, ByVal giaTri As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = tenThongSo})
            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = giaTri})
            Return ExecuteNoneQuery("updatethongso", param)
        End Function
#End Region
    End Module
End Namespace