Imports System.ComponentModel
Imports System.Data
Imports Entities.Entities
Imports DataAccess.DataAccess
Imports System.Collections.ObjectModel

Namespace Business
    Public Module ChiTietPhieuKhamBUS
#Region "1. Inserting"
        Public Function InsertOrUpdateChiTietPhieuKham(ByVal ChiTietPhieuKham As ChiTietPhieuKhamDTO) As Boolean
            Return ChiTietPhieuKhamDAL.InsertOrUpdateChiTietPhieuKham(ChiTietPhieuKham)
        End Function

#End Region
#Region "3. Delete"
        Public Function DeleteChiTietPhieuKhamByMa(ByVal maChiTietPhieuKham As String) As Boolean
            Return ChiTietPhieuKhamDAL.DeleteChiTietPhieuKhamByMa(maChiTietPhieuKham)
        End Function
#End Region
#Region "4. Get"
        Public Function GetChiTietPhieuKhamByMaKhamBenh(ByVal maKhamBenh As String) As ObservableCollection(Of ChiTietPhieuKhamDTO)
            Return ChiTietPhieuKhamDAL.GetChiTietPhieuKhamByMaKhamBenh(maKhamBenh)
        End Function

        Public Function GetMaChiTietPhieuKham() As String
            Return ChiTietPhieuKhamDAL.GetMaChiTietPhieuKham()
        End Function

        Public Function GetChiTietHoaDon(ByVal maKhamBenh As String) As ObservableCollection(Of ChiTietHoaDonDTO)
            Dim listCTHD As New ObservableCollection(Of ChiTietHoaDonDTO)
            Dim listCTPK As ObservableCollection(Of ChiTietPhieuKhamDTO) = ChiTietPhieuKhamBUS.GetChiTietPhieuKhamByMaKhamBenh(maKhamBenh)
            For Each ctpk As ChiTietPhieuKhamDTO In listCTPK
                listCTHD.Add(New ChiTietHoaDonDTO() With {.MaKhamBenh = ctpk.MaKhamBenh,
                                                             .MaChiTietPhieuKham = ctpk.MaChiTietPhieuKham,
                                                            .TenThuoc = GetThuoc(ctpk.MaThuoc).TenThuoc,
                                                           .TenDonVi = GetDonVi(ctpk.MaDonVi).TenDonVi,
                                                           .SoLuong = ctpk.SoLuong,
                                                           .DonGiaThucTe = GetThuoc(ctpk.MaThuoc).DonGia,
                                                           .ThanhTien = .SoLuong * .DonGiaThucTe}
                                                           )
            Next
            Return listCTHD
        End Function
#End Region

#Region "5.Valild"
        Public Function IsVaildSoLuong(ByVal soLuong As String, ByRef iSoLuong As Integer)
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

