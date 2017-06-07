Imports DataAccess.DataAccess
Imports Entities.Entities
Imports System.Collections.ObjectModel
Namespace Business
    Public Module BenhNhanBUS
        ''' <summary>
        ''' Hàm tìm bệnh nhân đa dụng
        ''' </summary>
        ''' <param name="mode"></param>
        ''' <param name="maKhamBenh"></param>
        ''' <param name="ngayKhamBatDau"></param>
        ''' <param name="ngayKhamKetThuc"></param>
        ''' <param name="hoTen"></param>
        ''' <param name="gioiTinh"></param>
        ''' <param name="namSinhBatDau"></param>
        ''' <param name="namSinhKetThuc"></param>
        ''' <param name="diaChi"></param>
        ''' <param name="trieuChung"></param>
        ''' <param name="tenLoaiBenh"></param>
        ''' <param name="maChiTietPhieuKham"></param>
        ''' <param name="tenThuoc"></param>
        ''' <param name="tenDonVi"></param>
        ''' <param name="tenCachDung"></param>
        ''' <param name="soLuongBatDau"></param>
        ''' <param name="soLuongKetThuc"></param>
        ''' <param name="tienKhamBatDau"></param>
        ''' <param name="tienKhamKetThuc"></param>
        ''' <param name="tienThuocBatDau"></param>
        ''' <param name="tienThuocKetThuc"></param>
        ''' <returns></returns>
        Public Function FindBenhNhan(ByVal mode As Integer,
                                     ByVal maKhamBenh As String,
                                     ByVal ngayKhamBatDau As Date,
                                     ByVal ngayKhamKetThuc As Date,
                                     ByVal hoTen As String,
                                     ByVal gioiTinh As String,
                                     ByVal namSinhBatDau As Integer,
                                     ByVal namSinhKetThuc As Integer,
                                     ByVal diaChi As String,
                                     ByVal trieuChung As String,
                                     ByVal tenLoaiBenh As String,
                                     ByVal maChiTietPhieuKham As String,
                                     ByVal tenThuoc As String,
                                     ByVal tenDonVi As String,
                                     ByVal tenCachDung As String,
                                     ByVal soLuongBatDau As Integer,
                                     ByVal soLuongKetThuc As Integer,
                                     ByVal tienKhamBatDau As Integer,
                                     ByVal tienKhamKetThuc As Integer,
                                     ByVal tienThuocBatDau As Integer,
                                     ByVal tienThuocKetThuc As Integer
                                     ) As ObservableCollection(Of BenhNhanDTO)
            'Lấy dữ liệu từ bảng 
            Dim tb As DataTable = BenhNhanDAL.FindBenhNhan(mode,
                                     maKhamBenh,
                                      ngayKhamBatDau,
                                      ngayKhamKetThuc,
                                      hoTen,
                                      gioiTinh,
                                      namSinhBatDau,
                                      namSinhKetThuc,
                                      diaChi,
                                      trieuChung,
                                      tenLoaiBenh,
                                      maChiTietPhieuKham,
                                      tenThuoc,
                                      tenDonVi,
                                      tenCachDung,
                                      soLuongBatDau,
                                      soLuongKetThuc,
                                      tienKhamBatDau,
                                      tienKhamKetThuc,
                                      tienThuocBatDau,
                                      tienThuocKetThuc)
            Dim list As New ObservableCollection(Of BenhNhanDTO)
            'Thêm dữ liệu từ bảng vào dan sách
            For Each row As DataRow In tb.Rows
                list.Add(New BenhNhanDTO(row))
            Next
            Return list
        End Function
        ''' <summary>
        ''' Kiểm tra xem năm sinh có hợp lệ hay không và gán vào iNamSinh
        ''' </summary>
        ''' <param name="namSinh"></param>
        ''' <param name="iNamSinh"></param>
        ''' <returns></returns>
        Public Function IsVaildNamSinh(ByVal namSinh As String, ByRef iNamSinh As Integer) As Boolean
            If (Integer.TryParse(namSinh, iNamSinh)) Then
                If (namSinh > 0) Then
                    Return True
                End If
            End If
            Return False
        End Function
    End Module
End Namespace
