Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module LoaiThuocBUS
#Region "1. Insert & Update"
        ''' <summary>
        ''' Cập nhật hoặc thêm loại thuốc nếu chưa có
        ''' </summary>
        ''' <param name="loaiThuoc"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateThuoc(ByVal loaiThuoc As LoaiThuocDTO) As Boolean
            Return LoaiThuocDAL.InsertOrUpdateLoaiThuoc(loaiThuoc)
        End Function
#End Region
#Region "2.Delete"
        ''' <summary>
        ''' Xóa loại thuốc dựa vào mã
        ''' </summary>
        ''' <param name="maThuoc"></param>
        ''' <returns></returns>
        Public Function DeleteThuocByMa(ByVal maThuoc As String) As Boolean
            Return LoaiThuocDAL.DeleteLoaiThuocByMa(maThuoc)
        End Function
#End Region
#Region "3.Get"
        ''' <summary>
        ''' Phát sinh mã thuốc
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaThuoc() As String
            Return LoaiThuocDAL.GetMaThuoc()
        End Function
        ''' <summary>
        ''' Lấy danh sách tất cả loại thuốc
        ''' </summary>
        ''' <returns></returns>
        Public Function GetAllLoaiThuoc() As ObservableCollection(Of LoaiThuocDTO)
            Dim dt As DataTable = LoaiThuocDAL.GetAllLoaiThuoc()
            Dim list As New ObservableCollection(Of LoaiThuocDTO)
            For Each row As DataRow In dt.Rows
                list.Add(New LoaiThuocDTO(row))
            Next
            Return list
        End Function
        ''' <summary>
        ''' Lấy tên thuốc, đơn giá dựa vào mã thuốc
        ''' </summary>
        ''' <param name="maThuoc"></param>
        ''' <returns></returns>
        Public Function GetThuoc(ByVal maThuoc As String) As LoaiThuocDTO
            Dim tb As DataTable = LoaiThuocDAL.GetThuoc(maThuoc)
            If tb.Rows.Count = 0 Then
                Return New LoaiThuocDTO
            Else
                Return New LoaiThuocDTO(tb.Rows.Item(0))
            End If
        End Function
#End Region
#Region "4.Vaild"
        ''' <summary>
        ''' Kiểm tra đơn giá có hợp lệ hay không và trả về
        ''' </summary>
        ''' <param name="donGia"></param>
        ''' <param name="iDonGia"></param>
        ''' <returns></returns>
        Public Function IsVaildDonGia(ByVal donGia As String, ByRef iDonGia As Integer) As Boolean
            If (Integer.TryParse(donGia, iDonGia)) Then
                If (iDonGia >= 0) Then
                    Return True
                End If
            End If
            Return False
        End Function
#End Region

    End Module
End Namespace