Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module LoaiCachDungDAL
#Region "1. Insert & Update"
        ''' <summary>
        ''' Thực hiện hàm thêm hoặc cập nhật loại cách dùng nếu chưa có
        ''' </summary>
        ''' <param name="loaiCachDung"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateLoaiCachDung(ByRef loaiCachDung As LoaiCachDungDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)

            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = loaiCachDung.MaCachDung})
            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = loaiCachDung.TenCachDung})

            Return ExecuteNoneQuery("insertorupdateloaicachdung", param)
        End Function
#End Region
#Region "2. Delete"
        ''' <summary>
        ''' Thực hiện hàm xóa loại cách dùng dựa vào mã
        ''' </summary>
        ''' <param name="maCachDung"></param>
        ''' <returns></returns>
        Public Function DeleteLoaiCachDungByMa(ByVal maCachDung As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)

            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maCachDung})

            Return ExecuteNoneQuery("deleteloaicachdungbyma", param)
        End Function
#End Region
#Region "3. Get"
        ''' <summary>
        ''' Phát sinh mã cách dùng
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaCachDung() As String
            Return ExecuteScalar("getmacachdung")
        End Function

        ''' <summary>
        ''' Thực hiện hàm lấy danh sách loại cách dùng
        ''' </summary>
        ''' <returns></returns>
        Public Function GetAllLoaiCachDung() As DataTable
            Return ExecuteQuery("getallloaicachdung")
        End Function
#End Region
    End Module
End Namespace
