Imports System.ComponentModel
Imports System.Data
Imports Entities.Entities
Imports DataAccess.DataAccess
Imports System.Collections.ObjectModel

Namespace Business
    Public Module ChiTietPhieuKhamBUS
#Region "1. Inserting"
        ''' <summary>
        ''' Thêm chi tiết phiếu khám
        ''' </summary>
        ''' <param name="ChiTietPhieuKham"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateChiTietPhieuKham(ByVal ChiTietPhieuKham As ChiTietPhieuKhamDTO) As Boolean
            Return ChiTietPhieuKhamDAL.InsertOrUpdateChiTietPhieuKham(ChiTietPhieuKham)
        End Function

#End Region
#Region "2. Delete"
        ''' <summary>
        ''' Xóa chi tiết phiếu khám theo mã chi tiết phiếu khám
        ''' </summary>
        ''' <param name="maChiTietPhieuKham"></param>
        ''' <returns></returns>
        Public Function DeleteChiTietPhieuKhamByMa(ByVal maChiTietPhieuKham As String) As Boolean
            Return ChiTietPhieuKhamDAL.DeleteChiTietPhieuKhamByMa(maChiTietPhieuKham)
        End Function
#End Region
#Region "4. Get"
        ''' <summary>
        ''' Lấy tất cả các chi tiêt phiếu khám theo mã khám bệnh
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetChiTietPhieuKhamByMaKhamBenh(ByVal maKhamBenh As String) As ObservableCollection(Of ChiTietPhieuKhamDTO)
            Dim tb As DataTable = ChiTietPhieuKhamDAL.GetChiTietPhieuKhamByMaKhamBenh(maKhamBenh)
            Dim list As New ObservableCollection(Of ChiTietPhieuKhamDTO)
            For Each row As DataRow In tb.Rows
                list.Add(New ChiTietPhieuKhamDTO(row))
            Next
            Return list
        End Function
        ''' <summary>
        ''' Phát sinh chi tiết phiếu khám
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaChiTietPhieuKham() As String
            Return ChiTietPhieuKhamDAL.GetMaChiTietPhieuKham()
        End Function
        ''' <summary>
        ''' Lấy chi tiết hóa đơn (thuốc sử dụng) cửa bệnh nhân chưa thanh toán
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetChiTietHoaDon(ByVal maKhamBenh As String) As ObservableCollection(Of ChiTietHoaDonDTO)
            Dim listCTHD As New ObservableCollection(Of ChiTietHoaDonDTO)
            'Lấy chi tiết phiếu khám của bệnh nhân
            Dim listCTPK As ObservableCollection(Of ChiTietPhieuKhamDTO) = ChiTietPhieuKhamBUS.GetChiTietPhieuKhamByMaKhamBenh(maKhamBenh)
            'Chuyển chi tiết phiếu khám thành chi tiết hóa đơn
            For Each ctpk As ChiTietPhieuKhamDTO In listCTPK
                listCTHD.Add(New ChiTietHoaDonDTO() With {.MaKhamBenh = ctpk.MaKhamBenh,
                                                          .MaChiTietPhieuKham = ctpk.MaChiTietPhieuKham,
                                                          .TenMatHang = GetThuoc(ctpk.MaThuoc).TenThuoc,
                                                          .TenDonVi = GetDonVi(ctpk.MaDonVi).TenDonVi,
                                                          .SoLuong = ctpk.SoLuong,
                                                          .DonGiaThucTe = GetThuoc(ctpk.MaThuoc).DonGia,
                                                          .ThanhTien = .SoLuong * .DonGiaThucTe})
            Next
            Return listCTHD
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
        ''' <summary>
        ''' Kiểm tra xem chi tiết phiếu khám có hợp lệ hay không 
        ''' </summary>
        ''' <param name="ctpk"></param>
        ''' <returns></returns>
        Public Function IsVaildChiTietPhieuKham(ByRef ctpk As ChiTietPhieuKhamDTO) As Boolean
            'Trim các khoảng trắng
            ctpk.TrieuChung.Trim()
            If (ctpk.MaCachDung = "" Or
            ctpk.MaDonVi = "" Or
            ctpk.MaThuoc = "") Then
                Return False
            End If
            Return True
        End Function
#End Region
    End Module
End Namespace

