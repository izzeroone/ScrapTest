Imports System.Collections.ObjectModel
Imports Entities.Entities
Imports DataAccess.DataAccess
Imports Xceed.Words.NET
Imports System.Windows.Threading
Imports System.Windows
Imports System.Globalization

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
#Region "Export"
        Public Sub ExportInvoice(ByVal maKhamBenh As String)
            Try
                Dim templateDoc As DocX = DocX.Load(IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources\TemplateInvoice.docx"))
                If templateDoc IsNot Nothing Then
                    Dim invoice = CreateInvoiceFromTemplate(templateDoc, maKhamBenh)
                    invoice.SaveAs(IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources\Invoice.docx"))
                    Process.Start("ms-word:ofv|u|file:///" + (IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources\Invoice.docx")))
                End If
            Catch ex As Exception
                Dispatcher.CurrentDispatcher.BeginInvoke(New Action(Sub() MessageBox.Show(IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources\TemplateInvoice.docx"))))
            End Try

        End Sub

        Private Function CreateInvoiceFromTemplate(ByVal template As DocX, ByVal maKhamBenh As String) As DocX
            'Declare format
            Dim tableFormat = New Formatting With {
                .Size = 9
            }
            Dim benhNhan As KhamBenhDTO = KhamBenhBUS.GetKhamBenhByMaKhamBenh(maKhamBenh)
            template.AddCustomProperty(New CustomProperty("ho_ten", benhNhan.HoTenBenhNhan))
            template.AddCustomProperty(New CustomProperty("dien_thoai", benhNhan.DienThoai))
            template.AddCustomProperty(New CustomProperty("ngay_xuat", benhNhan.NgayKham.Day))
            template.AddCustomProperty(New CustomProperty("thang_xuat", benhNhan.NgayKham.Month))
            template.AddCustomProperty(New CustomProperty("nam_xuat", benhNhan.NgayKham.Year))
            'Lấy thông tin thuốc
            Dim hoaDon As HoaDonDTO = HoaDonBUS.GetHoaDon(maKhamBenh)
            Dim listThuocPaid = ChiTietHoaDonBUS.GetAllChiTietThuoc(maKhamBenh)
            Dim listDichVu = ChiTietHoaDonBUS.GetAllChiTietDichVu(maKhamBenh)
            Dim detailsTable = template.Tables.LastOrDefault()
            If detailsTable Is Nothing Then
                Return template
            End If

            While detailsTable.Rows.Count > 1
                detailsTable.RemoveRow()
            End While

            ''Thêm khám bệnh
            'Dim khamRow = detailsTable.InsertRow()
            'khamRow.Cells.Item(0).InsertParagraph("Khám bệnh", False, tableFormat)
            'khamRow.Cells.Item(1).InsertParagraph("Lần", False, tableFormat)
            'khamRow.Cells.Item(2).InsertParagraph("1", False, tableFormat)
            'khamRow.Cells.Item(3).InsertParagraph(String.Format(CultureInfo.InvariantCulture,
            '                          "{0:#,0₫}", Int32.Parse(ThongSoDAL.GetThongSo("tienkham"))), False, tableFormat)
            'khamRow.Cells.Item(4).InsertParagraph(String.Format(CultureInfo.InvariantCulture,
            '                          "{0:#,0₫}", Int32.Parse(ThongSoDAL.GetThongSo("tienkham"))), False, tableFormat)
            Dim stt = 1
            For Each chiTietHoaDon As ChiTietHoaDonDTO In listDichVu
                Dim newRow = detailsTable.InsertRow()
                newRow.Cells.Item(0).InsertParagraph(stt, False, tableFormat)
                newRow.Cells.Item(1).InsertParagraph(chiTietHoaDon.TenMatHang, False, tableFormat)
                newRow.Cells.Item(2).InsertParagraph(chiTietHoaDon.TenDonVi, False, tableFormat)
                newRow.Cells.Item(3).InsertParagraph(chiTietHoaDon.SoLuong, False, tableFormat)
                newRow.Cells.Item(4).InsertParagraph(String.Format(CultureInfo.InvariantCulture,
                                      "{0:#,0₫}", chiTietHoaDon.DonGiaThucTe), False, tableFormat)
                newRow.Cells.Item(5).InsertParagraph(String.Format(CultureInfo.InvariantCulture,
                                      "{0:#,0₫}", chiTietHoaDon.ThanhTien), False, tableFormat)
                stt = stt + 1
            Next

            For Each chiTietHoaDon As ChiTietHoaDonDTO In listThuocPaid
                Dim newRow = detailsTable.InsertRow()
                newRow.Cells.Item(0).InsertParagraph(stt, False, tableFormat)
                newRow.Cells.Item(1).InsertParagraph(chiTietHoaDon.TenMatHang, False, tableFormat)
                newRow.Cells.Item(2).InsertParagraph(chiTietHoaDon.TenDonVi, False, tableFormat)
                newRow.Cells.Item(3).InsertParagraph(chiTietHoaDon.SoLuong, False, tableFormat)
                newRow.Cells.Item(4).InsertParagraph(String.Format(CultureInfo.InvariantCulture,
                                      "{0:#,0₫}", chiTietHoaDon.DonGiaThucTe), False, tableFormat)
                newRow.Cells.Item(5).InsertParagraph(String.Format(CultureInfo.InvariantCulture,
                                      "{0:#,0₫}", chiTietHoaDon.ThanhTien), False, tableFormat)
                stt = stt + 1
            Next

            Dim tongTien = CalcTienThuoc(listThuocPaid) + Int32.Parse(ThongSoDAL.GetThongSo("tienkham"))
            template.AddCustomProperty(New CustomProperty("tong_tien", String.Format(CultureInfo.InvariantCulture,
                                      "{0:#,0₫}", tongTien)))
            template.AddCustomProperty(New CustomProperty("bang_chu", DocTien.TienBangChu(tongTien.ToString()) + "đồng"))
            template.AddCustomProperty(New CustomProperty("nguoi_xuat", ThongSoDAL.GetThongSo("nguoikham")))


            Return template
        End Function
#End Region
    End Module
End Namespace

