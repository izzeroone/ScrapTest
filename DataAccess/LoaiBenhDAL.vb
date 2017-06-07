Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module LoaiBenhDAL
#Region "1. Insert & Update"
        ''' <summary>
        ''' Thực hiện hàm cập nhật hoặc thêm loại bênh nếu chưa có
        ''' </summary>
        ''' <param name="loaiBenh"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateLoaiBenh(ByRef loaiBenh As LoaiBenhDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)

            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = loaiBenh.MaLoaiBenh})
            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = loaiBenh.TenLoaiBenh})

            Return ExecuteNoneQuery("insertorupdateloaibenh", param)
        End Function
#End Region
#Region "2. Delete"
        ''' <summary>
        ''' Thực hiện hàm xóa loại bệnh dựa vào mã
        ''' </summary>
        ''' <param name="maLoaiBenh"></param>
        ''' <returns></returns>
        Public Function DeleteLoaiBenhByMa(ByVal maLoaiBenh As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)

            param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maLoaiBenh})

            Return ExecuteNoneQuery("deleteloaibenhbyma", param)
        End Function
#End Region
#Region "3. Get"
        ''' <summary>
        ''' Phát sinh mã loại bệnh
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaLoaiBenh() As String
            Return ExecuteScalar("getmaloaibenh")
        End Function

        ''' <summary>
        ''' Lấy danh sách tất cả loại bệnh
        ''' </summary>
        ''' <returns></returns>
        Public Function GetAllLoaiBenh() As DataTable
            Return ExecuteQuery("getallloaibenh")
        End Function
#End Region
    End Module
End Namespace
