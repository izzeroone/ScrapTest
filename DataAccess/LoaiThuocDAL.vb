Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module LoaiThuocDAL
#Region "1. Insert & Update"
        ''' <summary>
        ''' Thực hiện hàm thêm hoặc cập nhật loại thuốc nếu chưa có
        ''' </summary>
        ''' <param name="loaiThuoc"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateLoaiThuoc(ByRef loaiThuoc As LoaiThuocDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)

            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = loaiThuoc.MaThuoc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = loaiThuoc.TenThuoc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = loaiThuoc.DonGia})

            Return ExecuteNoneQuery("insertorupdateloaithuoc", param)
        End Function
#End Region
#Region "2. Delete"
        ''' <summary>
        ''' Thực hiện hàm xóa loại thuốc dựa vào mã
        ''' </summary>
        ''' <param name="maThuoc"></param>
        ''' <returns></returns>
        Public Function DeleteLoaiThuocByMa(ByVal maThuoc As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)

            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maThuoc})

            Return ExecuteNoneQuery("deleteloaithuocbyma", param)
        End Function
#End Region
#Region "3. Get"
        ''' <summary>
        ''' Phát sinh mã loại thuốc
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaThuoc() As String
            Return ExecuteScalar("getmathuoc")
        End Function

        ''' <summary>
        ''' Thực hiện hàm lấy danh sách các loại thuốc
        ''' </summary>
        ''' <returns></returns>
        Public Function GetAllLoaiThuoc() As DataTable
            Return ExecuteQuery("getallloaithuoc")
        End Function

        ''' <summary>
        ''' Thực hiện hàm lấy thông tin thuốc dựa vào mã thuốc
        ''' </summary>
        ''' <param name="maThuoc"></param>
        ''' <returns></returns>
        Public Function GetThuoc(ByVal maThuoc As String) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maThuoc})
            Return ExecuteQuery("getthuoc", param)
        End Function
#End Region
    End Module
End Namespace
