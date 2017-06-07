Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module LoaiDonViBUS
#Region "1.Insert & Update"
        ''' <summary>
        ''' Cập nhật hoặc thêm loại đơn vị nếu chưa có
        ''' </summary>
        ''' <param name="loaiDonVi"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateDonVi(ByVal loaiDonVi As LoaiDonViDTO) As Boolean
            Return LoaiDonViDAL.InsertOrUpdateLoaiDonVi(loaiDonVi)
        End Function
#End Region
#Region "2.Delete"
        ''' <summary>
        ''' Xóa loại đơn vị dựa vào mã
        ''' </summary>
        ''' <param name="maDonVi"></param>
        ''' <returns></returns>
        Public Function DeleteDonViByMa(ByVal maDonVi As String) As Boolean
            Return LoaiDonViDAL.DeleteLoaiDonViByMa(maDonVi)
        End Function
#End Region
#Region "3.Get"
        ''' <summary>
        ''' Phát sinh mã đơn vị
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaDonVi() As String
            Return LoaiDonViDAL.GetMaDonVi()
        End Function
        ''' <summary>
        ''' Lấy tất cả các loại đơn vị
        ''' </summary>
        ''' <returns></returns>
        Public Function GetAllLoaiDonVi() As ObservableCollection(Of LoaiDonViDTO)
            Dim tb As DataTable = LoaiDonViDAL.GetAllLoaiDonVi()
            Dim list As New ObservableCollection(Of LoaiDonViDTO)
            'Thêm từng hàng trong bảng vào danh sách
            For Each row As DataRow In tb.Rows
                list.Add(New LoaiDonViDTO(row))
            Next
            Return list
        End Function
        ''' <summary>
        ''' Lấy tên đơn vị dựa vào mã đơn vị
        ''' </summary>
        ''' <param name="maDonVi"></param>
        ''' <returns></returns>
        Public Function GetDonVi(ByVal maDonVi) As LoaiDonViDTO
            Dim tb As DataTable = LoaiDonViDAL.GetDonVi(maDonVi)
            If tb.Rows.Count = 0 Then
                Return New LoaiDonViDTO
            Else
                Return New LoaiDonViDTO(tb.Rows.Item(0))
            End If
        End Function
#End Region
    End Module
End Namespace