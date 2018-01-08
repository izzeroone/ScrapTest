Imports System.Globalization
Imports System.Windows
Imports System.Windows.Threading
Imports DataAccess.DataAccess
Imports Entities.Entities
Imports Xceed.Words.NET

Namespace Business
    Public Module PhieuKhamBUS
        Public Sub ExportInvoice(ByVal maKhamBenh As String)
            Try
                Dim templateDoc As DocX = DocX.Load(IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources\TemplateDrug.docx"))
                If templateDoc IsNot Nothing Then
                    Dim invoice = CreateInvoiceFromTemplate(templateDoc, maKhamBenh)
                    invoice.SaveAs(IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources\Drug.docx"))
                    Process.Start("ms-word:ofv|u|file:///" + (IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources\Drug.docx")))
                End If
            Catch ex As Exception
                Dispatcher.CurrentDispatcher.BeginInvoke(New Action(Sub() MessageBox.Show(ex.ToString)))
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
            template.AddCustomProperty(New CustomProperty("nam_sinh", benhNhan.NamSinh))
            template.AddCustomProperty(New CustomProperty("gioi_tinh", benhNhan.GioiTinh))
            template.AddCustomProperty(New CustomProperty("dia_chi", benhNhan.DiaChi))
            template.AddCustomProperty(New CustomProperty("ngay_xuat", benhNhan.NgayKham.Day))
            template.AddCustomProperty(New CustomProperty("thang_xuat", benhNhan.NgayKham.Month))
            template.AddCustomProperty(New CustomProperty("nam_xuat", benhNhan.NgayKham.Year))
            'Lấy thông tin thuốc
            Dim listThuoc = ChiTietPhieuKhamBUS.GetChiTietPhieuKhamByMaKhamBenh(maKhamBenh)
            Dim detailsTable = template.Tables.LastOrDefault()
            If detailsTable Is Nothing Then
                Return template
            End If

            While detailsTable.Rows.Count > 1
                detailsTable.RemoveRow()
            End While

            If listThuoc Is Nothing Then
                Return template
            End If
            'Lời dặn, loại bệnh, triệu chứng
            template.AddCustomProperty(New CustomProperty("trieu_chung", listThuoc.Item(0).TrieuChung))
            template.AddCustomProperty(New CustomProperty("chuan_doan", listThuoc.Item(0).TenLoaiBenh))
            template.AddCustomProperty(New CustomProperty("loi_dan", listThuoc.Item(0).LoiDan))


            'Thêm chi tiết thuốc
            Dim stt As Integer = 1
            For Each chiTietPhieuKham As ChiTietPhieuKhamDTO In listThuoc
                Dim newRow = detailsTable.InsertRow()
                newRow.Cells.Item(0).InsertParagraph(stt.ToString(), False, tableFormat)
                newRow.Cells.Item(1).InsertParagraph(chiTietPhieuKham.TenThuoc, False, tableFormat)
                newRow.Cells.Item(1).InsertParagraph("Số lượng :" + chiTietPhieuKham.SoLuong.ToString() + " x " + chiTietPhieuKham.TenDonVi, False, tableFormat)
                newRow.Cells.Item(1).InsertParagraph("Cách dùng : " + chiTietPhieuKham.TenCachDung, False, tableFormat)
                stt = stt + 1
            Next

            template.AddCustomProperty(New CustomProperty("nguoi_ke", ThongSoDAL.GetThongSo("nguoikham")))


            Return template
        End Function
    End Module
End Namespace

