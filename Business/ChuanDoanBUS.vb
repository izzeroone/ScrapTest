Imports System.ComponentModel
Imports System.Data
Imports Entities.Entities
Imports DataAccess.DataAccess
Imports System.Collections.ObjectModel

Namespace Business
    Public Module ChuanDoanBUS
#Region "1. Inserting"
        ''' <summary>
        ''' Thêm chi tiết phiếu khám
        ''' </summary>
        ''' <param name="ChiTietPhieuKham"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateChuanDoan(ByVal chuanDoan As ChuanDoanDTO) As Boolean
            Return ChuanDoanDAL.InsertOrUpdateChuanDoan(chuanDoan)
        End Function


#End Region
#Region "2. Delete"
        ''' <summary>
        ''' Xóa chi tiết phiếu khám theo mã chi tiết phiếu khám
        ''' </summary>
        ''' <param name="maChiTietPhieuKham"></param>
        ''' <returns></returns>
        Public Function DeleteChuanDoanByMa(ByVal maKhamBenh As String, ByVal maDichVu As String) As Boolean
            Return ChuanDoanDAL.DeleteChuanDoanByMa(maKhamBenh, maDichVu)
        End Function
#End Region
#Region "4. Get"

        ''' <summary>
        ''' Phát sinh chi tiết phiếu khám
        ''' </summary>
        ''' <returns></returns>

        ''' Lấy chi tiết hóa đơn (thuốc sử dụng) cửa bệnh nhân chưa thanh toán
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetChuanDoan(ByVal maKhamBenh As String) As ObservableCollection(Of ChuanDoanDTO)
            Dim dt As DataTable = ChuanDoanDAL.GetChuanDoanByMaKhamBenh(maKhamBenh)
            Dim list As New ObservableCollection(Of ChuanDoanDTO)
            For Each row As DataRow In dt.Rows
                list.Add(New ChuanDoanDTO(row))
            Next
            Return list
        End Function
#End Region

#Region "3.Valild"
        ''' <summary>
        ''' Kiểm tra số lượng có hợp lệ hay không
        ''' </summary>
        ''' <param name="soLuong"></param>
        ''' <param name="iSoLuong"></param>
        ''' <returns></returns>
        Public Function IsVaildSoLuong(ByVal soLuong As String, ByRef iSoLuong As Integer) As Boolean
            If (Integer.TryParse(soLuong, iSoLuong)) Then
                If (iSoLuong > 0) Then
                    Return True
                End If
            End If
            Return False
        End Function

#End Region
    End Module
End Namespace

