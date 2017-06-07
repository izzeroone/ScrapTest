Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module LoaiDonViDAL
#Region "1. Insert & Update"
        ''' <summary>
        ''' Thực hiện cập nhật hoặc thêm loại đơn vị nếu chưa có
        ''' </summary>
        ''' <param name="loaiDonVi"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateLoaiDonVi(ByRef loaiDonVi As LoaiDonViDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)

            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = loaiDonVi.MaDonVi})
            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = loaiDonVi.TenDonVi})

            Return ExecuteNoneQuery("insertorupdateloaidonvi", param)
        End Function
#End Region
#Region "2. Delete"
        ''' <summary>
        ''' Thực hiện hàm xóa loại đơn vị dựa vào mã
        ''' </summary>
        ''' <param name="maDonVi"></param>
        ''' <returns></returns>
        Public Function DeleteLoaiDonViByMa(ByVal maDonVi As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)

            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maDonVi})

            Return ExecuteNoneQuery("deleteloaidonvibyma", param)
        End Function
#End Region
#Region "3. Get"
        ''' <summary>
        ''' Phát sinh mã đơn vị
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaDonVi() As String
            Return ExecuteScalar("getmadonvi")
        End Function

        ''' <summary>
        ''' Thực hiện hàm lấy danh sách các loại đơn vị
        ''' </summary>
        ''' <returns></returns>
        Public Function GetAllLoaiDonVi() As DataTable
            Return ExecuteQuery("getallloaidonvi")
        End Function

        ''' <summary>
        ''' Thực hiện lấy tên đơn vị dựa vào mã đơn vị
        ''' </summary>
        ''' <param name="maDonVi"></param>
        ''' <returns></returns>
        Public Function GetDonVi(ByVal maDonVi As String) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maDonVi})
            Return ExecuteQuery("getdonvi", param)
        End Function
#End Region
    End Module
End Namespace
