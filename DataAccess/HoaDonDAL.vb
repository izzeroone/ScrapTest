Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module HoaDonDAL
#Region "Insert"
        Public Function InsertOrUpdateHoaDon(ByVal hoaDon As HoaDonDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = hoaDon.MaKhamBenh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = hoaDon.TienKham})
            Return ExecuteNoneQuery("insertorupdatehoadon", param)
        End Function
#End Region
#Region "Check"
        Public Function IsHoaDonPay(ByVal maKhamBenh) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteScalar("ishoadonpay", param)
        End Function
#End Region
#Region "Get"

        Public Function GetHoaDon(ByVal maKhamBenh As String) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteQuery("gethoadon", param)
        End Function
#End Region
#Region "Delete"
        Public Function DeleteHoaDon(ByVal maKhamBenh As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteNoneQuery("deletehoadon", param)
        End Function
#End Region
    End Module
End Namespace
