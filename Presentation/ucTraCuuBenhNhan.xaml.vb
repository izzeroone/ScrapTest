Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data
Imports System.Text.RegularExpressions
Imports Business.Business
Imports Entities.Entities
Public Class ucTraCuuBenhNhan
    Private Sub GetRange(ByVal tbBatDau As TextBox, ByVal tbKetThuc As TextBox, ByRef batDau As Integer, ByRef ketThuc As Integer)
        If tbBatDau.Text = "" Then
            If tbKetThuc.Text = "" Then
                batDau = Integer.MinValue
                ketThuc = Integer.MaxValue
            Else
                batDau = Integer.MinValue
                ketThuc = Integer.Parse(tbKetThuc.Text)
            End If
        Else
            If tbKetThuc.Text = "" Then
                batDau = Integer.Parse(tbBatDau.Text)
                ketThuc = Integer.MaxValue
            Else
                batDau = Integer.Parse(tbBatDau.Text)
                ketThuc = Integer.Parse(tbKetThuc.Text)
                If (batDau > ketThuc) Then
                    Throw New DataException("Invaild Range")
                End If
            End If
        End If
    End Sub

    Private Sub GetRange(ByVal dpBatDau As DatePicker, ByVal dpKetThuc As DatePicker, ByRef batDau As Date, ByRef ketThuc As Date)
        If dpBatDau.SelectedDate Is Nothing Then
            If dpKetThuc.SelectedDate Is Nothing Then
                batDau = New Date(1, 1, 1)
                ketThuc = New Date(9999, 1, 1)
            Else
                batDau = New Date(1, 1, 1)
                ketThuc = dpKetThuc.SelectedDate
            End If
        Else
            If Me.dpKetThuc.SelectedDate Is Nothing Then
                batDau = dpBatDau.SelectedDate
                ketThuc = New Date(9999, 1, 1)
            Else
                batDau = dpBatDau.SelectedDate
                ketThuc = dpKetThuc.SelectedDate
                If (batDau > ketThuc) Then
                    Throw New DataException("Invaild Range")
                End If
            End If
        End If
    End Sub

    Private Sub LoadComboBoxData()
        If Me.IsVisible = True Then
            tbLoaiBenh.ItemsSource = LoaiBenhBUS.GetAllLoaiBenh()
            tbDonVi.ItemsSource = LoaiDonViBUS.GetAllLoaiDonVi()
            tbCachDung.ItemsSource = LoaiCachDungBUS.GetAllLoaiCachDung()
            tbThuoc.ItemsSource = LoaiThuocBUS.GetAllLoaiThuoc()
        End If
    End Sub

    Private Sub FindButton_Click(sender As Object, e As RoutedEventArgs)
        Dim ngayKhamBatDau As Date
        Dim ngayKhamKetThuc As Date
        Dim namSinhBatDau As Integer
        Dim namSinhKetThuc As Integer
        Dim soLuongBatDau As Integer
        Dim soLuongKetThuc As Integer
        Dim tienKhamBatDau As Integer
        Dim tienKhamKetThuc As Integer
        Dim tienThuocBatDau As Integer
        Dim tienThuocKetThuc As Integer
        Dim mode As Integer = 0
        If (tbMaKhamBenh.Text <> "" Or dpBatDau.SelectedDate IsNot Nothing Or
            dpKetThuc.SelectedDate IsNot Nothing Or tbHoTen.Text <> "" Or
            cbGioiTinh.SelectedIndex <> -1 Or tbNamSinhBatDau.Text <> "" Or
            tbNamSinhKetThuc.Text <> "" Or tbDiaChi.Text <> "" Or
            tbTrieuChung.Text <> "" Or tbLoaiBenh.Text <> "") Then
            mode += 1
        End If
        If (tbMaChiTietPhieuKham.Text <> "" Or tbThuoc.Text <> "" Or
            tbDonVi.Text <> "" Or tbCachDung.Text <> "" Or
            tbSoLuongBatDau.Text <> "" Or tbSoLuongKetThuc.Text <> "") Then
            mode += 2
        End If
        If (tbTienKhamBatDau.Text <> "" Or tbTienKhamKetTHuc.Text <> "" Or
            tbTienThuocBatDau.Text <> "" Or tbTienThuocKetThuc.Text <> "") Then
            mode += 4
        End If


        Try
            GetRange(dpBatDau, dpKetThuc, ngayKhamBatDau, ngayKhamKetThuc)
            GetRange(tbNamSinhBatDau, tbNamSinhKetThuc, namSinhBatDau, namSinhKetThuc)
            GetRange(tbSoLuongBatDau, tbSoLuongKetThuc, soLuongBatDau, soLuongKetThuc)
            GetRange(tbTienKhamBatDau, tbTienKhamKetTHuc, tienKhamBatDau, tienKhamKetThuc)
            GetRange(tbTienThuocBatDau, tbTienThuocKetThuc, tienThuocBatDau, tienThuocKetThuc)
        Catch ex As Exception
            Domain.Dialog.Show("Không hợp lệ")
            Exit Sub
        End Try

        dgBenhNhan.ItemsSource = BenhNhanBUS.FindBenhNhan(mode,
                                                            tbMaKhamBenh.Text,
                                                            ngayKhamBatDau,
                                                            ngayKhamKetThuc,
                                                            tbHoTen.Text,
                                                            cbGioiTinh.Text,
                                                            namSinhBatDau,
                                                            namSinhKetThuc,
                                                            tbDiaChi.Text,
                                                            tbMaChiTietPhieuKham.Text,
                                                            tbTrieuChung.Text,
                                                            tbLoaiBenh.Text,
                                                            tbThuoc.Text,
                                                            tbDonVi.Text,
                                                            tbCachDung.Text,
                                                            soLuongBatDau,
                                                            soLuongKetThuc,
                                                            tienKhamBatDau,
                                                            tienKhamKetThuc,
                                                            tienThuocBatDau,
                                                            tienThuocKetThuc)
        If (dgBenhNhan.Items.IsEmpty) Then
            Domain.Dialog.Show("Không tìm thấy bệnh nhân")
        End If


    End Sub

    Private Sub ResetButton_Click(sender As Object, e As RoutedEventArgs)
        dpBatDau.SelectedDate = Nothing
        dpBatDau.DisplayDate = Date.Now()
        dpKetThuc.SelectedDate = Nothing
        dpKetThuc.DisplayDate = Date.Now()
        tbMaKhamBenh.Clear()
        tbHoTen.Clear()
        cbGioiTinh.SelectedIndex = -1
        tbNamSinhBatDau.Clear()
        tbNamSinhKetThuc.Clear()
        tbDiaChi.Clear()
        tbTrieuChung.Clear()
        tbLoaiBenh.Text = ""
        tbMaChiTietPhieuKham.Clear()
        tbThuoc.Text = ""
        tbDonVi.Text = ""
        tbSoLuongBatDau.Clear()
        tbSoLuongKetThuc.Clear()
        tbCachDung.Text = ""
        tbTienKhamBatDau.Clear()
        tbTienKhamKetThuc.Clear()
        tbTienThuocBatDau.Clear()
        tbTienThuocKetThuc.Clear()
        dgBenhNhan.ItemsSource = Nothing
    End Sub

    Public Sub NumberValidationTextBox(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim regex As Regex = New Regex("[^0-9]+")
        e.Handled = regex.IsMatch(e.Text)
    End Sub

    Private Sub DatePickerDateValidationError(sender As Object, e As DatePickerDateValidationErrorEventArgs)
        Dim dp As DatePicker = sender
        e.ThrowException = False
        Domain.Dialog.Show("Ngày không hợp lệ")
        dp.SelectedDate = Date.Now()
    End Sub


End Class
