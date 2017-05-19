Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module HoaDonDAL
#Region "Insert"
        Public Function InsertOrUpdateHoaDon(ByRef hoaDon As HoaDonDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = hoaDon.MaKhamBenh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = hoaDon.TienKham})
            Return ExecuteNoneQuery("insertorupdatehoadon")
        End Function
#End Region
#Region "Check"
        Public Function IsHoaDonPay(ByVal maKhamBenh) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteScalar("ishoadonpay", param)
        End Function
#End Region

    End Module
End Namespace
