Imports System.Collections.ObjectModel
Imports Entities.Entities
Imports DataAccess.DataAccess
Imports Xceed.Words.NET
Imports System.Windows.Threading
Imports System.Windows

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
                    'Process.Start("WINWORD.EXE", IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources\Invoice.docx"))
                    Process.Start("ms-word:ofv|u|file:///" + (IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources\Invoice.docx")))
                End If
            Catch ex As Exception
                Dispatcher.CurrentDispatcher.BeginInvoke(New Action(Sub() MessageBox.Show(IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources\TemplateInvoice.docx"))))
            End Try

        End Sub

        Private Function CreateInvoiceFromTemplate(ByVal template As DocX, ByVal maKhamBenh As String) As DocX
            Dim benhNhan As KhamBenhDTO = KhamBenhBUS.GetKhamBenhByMaKhamBenh(maKhamBenh)
            template.AddCustomProperty(New CustomProperty("ho_ten", benhNhan.HoTenBenhNhan))
            template.AddCustomProperty(New CustomProperty("nam_sinh", benhNhan.NamSinh))
            template.AddCustomProperty(New CustomProperty("gioi_tinh", benhNhan.GioiTinh))
            template.AddCustomProperty(New CustomProperty("trieu_chung", benhNhan.TrieuChung))
            template.AddCustomProperty(New CustomProperty("loai_benh", benhNhan.MaLoaiBenh))
            template.AddCustomProperty(New CustomProperty("ngay_ke", benhNhan.NgayKham.Day))
            template.AddCustomProperty(New CustomProperty("thang_ke", benhNhan.NgayKham.Month))
            template.AddCustomProperty(New CustomProperty("nam_ke", benhNhan.NgayKham.Year))
            'Nếu hưa thanh toán thì lấy thuốc sử dụng từ chi tiết phiếu khám
            'listThuocUnpaid = ChiTietPhieuKhamBUS.GetChiTietHoaDon(maKhamBenh)
            'dgChiTietThuoc.ItemsSource = listThuocUnpaid
            ''Hiển thị tiền thuốc và tiền khám
            'tbTienKham.Text = ThongSoDTO.TienKham
            'Dim tienThuoc As Integer = HoaDonBUS.CalcTienThuoc(listThuocUnpaid).ToString()
            'tbTienThuoc.Text = tienThuoc.ToString()
            'tbTongTien.Text = "Tổng tiền = " + (ThongSoDTO.TienKham + tienThuoc).ToString()
            ''Hiển thị tình trạng thanh toán
            'tbTinhTrang.BorderBrush = Brushes.OrangeRed
            'tbTinhTrang.Text = "Chưa thanh toán"
            ''Cho phép thanh toán và không cho phép thanh toán
            'btCheckout.IsEnabled = True
            'btDelete.IsEnabled = False
            Return template
        End Function
#End Region
    End Module
End Namespace

