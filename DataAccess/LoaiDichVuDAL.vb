Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module LoaiDichVuDAL
#Region "1. Insert & Update"

        Public Function InsertOrUpdateLoaiDichVu(ByRef loaiDichVu As LoaiDichVuDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)

            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = loaiDichVu.MaDichVu})
            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = loaiDichVu.TenDichVu})
            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = loaiDichVu.MaDonVi})
            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = loaiDichVu.DonGia})

            Return ExecuteNoneQuery("insertorupdateloaidichvu", param)
        End Function
#End Region
#Region "2. Delete"

        Public Function DeleteLoaiDichVuByMa(ByVal maLoaiDichVu As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)

            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maLoaiDichVu})

            Return ExecuteNoneQuery("deleteloaidichvubyma", param)
        End Function
#End Region
#Region "3. Get"
        ''' <summary>
        ''' Phát sinh mã loại bệnh
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaLoaiDichVu() As String
            Return ExecuteScalar("getmadichvu")
        End Function


        ''' <summary>
        ''' Lấy danh sách tất cả loại bệnh
        ''' </summary>
        ''' <returns></returns>
        Public Function GetAllLoaiDichVu() As DataTable
            Return ExecuteQuery("getallloaidichvu")
        End Function

        Public Function GetDichVu(ByVal maDichVu As String) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maDichVu})
            Return ExecuteQuery("getdichvu", param)
        End Function
#End Region
    End Module
End Namespace
