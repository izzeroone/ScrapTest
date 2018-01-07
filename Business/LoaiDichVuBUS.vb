Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module LoaiDichVuBUS
#Region "1. Insert & Update"

        Public Function InsertOrUpdateDichVu(ByVal loaiDichVu As LoaiDichVuDTO) As Boolean
            Return LoaiDichVuDAL.InsertOrUpdateLoaiDichVu(loaiDichVu)
        End Function
#End Region
#Region "2.Delete"


        Public Function DeleteDichVuByMa(ByVal maDichVu As String) As Boolean
            Return LoaiDichVuDAL.DeleteLoaiDichVuByMa(maDichVu)
        End Function
#End Region
#Region "3.Get"
        ''' <summary>
        ''' Phát sinh mã thuốc
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaDichVu() As String
            Return LoaiDichVuDAL.GetMaLoaiDichVu()
        End Function
        ''' <summary>
        ''' Lấy danh sách tất cả loại thuốc
        ''' </summary>
        ''' <returns></returns>
        Public Function GetAllLoaiDichVu() As ObservableCollection(Of LoaiDichVuDTO)
            Dim dt As DataTable = LoaiDichVuDAL.GetAllLoaiDichVu()
            Dim list As New ObservableCollection(Of LoaiDichVuDTO)
            For Each row As DataRow In dt.Rows
                list.Add(New LoaiDichVuDTO(row))
            Next
            Return list
        End Function

        Public Function GetDichVu(ByVal maDichVu As String) As LoaiDichVuDTO
            Dim tb As DataTable = LoaiDichVuDAL.GetDichVu(maDichVu)
            If tb.Rows.Count = 0 Then
                Return New LoaiDichVuDTO
            Else
                Return New LoaiDichVuDTO(tb.Rows.Item(0))
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