Imports System.Collections.ObjectModel
Imports Entities.Entities
Imports DataAccess.DataAccess
Namespace Business
    Public Module HoaDonBUS
#Region "1.Insert"
        'Cập nhật hoặc thêm hóa đơn thanh toán
        Public Function InsertOrUpdateHoaDon(ByVal hoaDon As HoaDonDTO) As Boolean
            Return HoaDonDAL.InsertOrUpdateHoaDon(hoaDon)
        End Function
#End Region
#Region "2.Check"
        'Kiểm tra bệnh nhân đã thanh toán hóa đơn chưa
        Public Function IsHoaDonPay(ByVal maKhamBenh) As Boolean
            Dim result As Boolean
            Try
                Boolean.TryParse(HoaDonDAL.IsHoaDonPay(maKhamBenh), result)
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
#End Region
#Region "Get"
        'Lấy hóa đơn chính của bệnh nhân 
        Public Function GetHoaDon(ByVal maKhamBenh As String) As HoaDonDTO
            Dim tb As DataTable = HoaDonDAL.GetHoaDon(maKhamBenh)
            Return New HoaDonDTO(tb.Rows.Item(0))
        End Function
#End Region
#Region "Delete"
        'Xóa hóa đơn chính của bệnh nhân 
        Public Function DeleteHoaDon(ByVal maKhamBenh As String) As Boolean
            Dim hoaDon As HoaDonDTO = GetHoaDon(maKhamBenh)
            'Xóa chi tiết hóa đơn của bệnh nhân
            ChiTietHoaDonBUS.DeleteAllChiTietHoaDon(maKhamBenh)
            'Xóa hóa đơn chính
            Return HoaDonDAL.DeleteHoaDon(maKhamBenh)
        End Function
#End Region
#Region "Calculator"
        'Tính tổng tiền thuốc của hóa đơn
        Public Function CalcTienThuoc(ByVal list As ObservableCollection(Of ChiTietHoaDonDTO)) As Integer
            Dim tienThuoc As Integer = 0
            For Each chiTietHoaDon As ChiTietHoaDonDTO In list
                tienThuoc += chiTietHoaDon.SoLuong * chiTietHoaDon.DonGiaThucTe
            Next
            Return tienThuoc
        End Function
#End Region

    End Module
End Namespace

