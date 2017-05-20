Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module LoaiThuocDAL
#Region "1. Insert & Update"
        Public Function InsertOrUpdateLoaiThuoc(ByRef loaiThuoc As LoaiThuocDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = loaiThuoc.MaThuoc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = loaiThuoc.TenThuoc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = loaiThuoc.DonGia})


            Return ExecuteNoneQuery("insertorupdateloaithuoc", param)
        End Function
#End Region
#Region "2. Delete"
        Public Function DeleteLoaiThuocByMa(ByVal maThuoc As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = maThuoc
            param.Add(parameter)

            Return ExecuteNoneQuery("deleteloaithuocbyma", param)
        End Function
#End Region
#Region "3. Get"
        Public Function GetMaThuoc() As String
            Return ExecuteScalar("getmathuoc")
        End Function

        Public Function GetAllLoaiThuoc() As DataTable
            Return ExecuteQuery("getallloaithuoc")

        End Function

        Public Function GetThuoc(ByVal maThuoc As String) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maThuoc})
            Return ExecuteQuery("getthuoc", param)
        End Function
#End Region
    End Module
End Namespace
