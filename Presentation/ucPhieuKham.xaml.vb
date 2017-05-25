Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data
Imports System.Text.RegularExpressions
Imports Business.Business
Imports Entities.Entities
Public Class ucPhieuKham
    Dim listChiTietPhieuKham As ObservableCollection(Of ROWChiTietPhieuKhamDTO)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub NumberValidationTextBox(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim regex As Regex = New Regex("[^0-9]+")
        e.Handled = regex.IsMatch(e.Text)
    End Sub


    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        If Not listChiTietPhieuKham.Count = 0 Then
            If Not listChiTietPhieuKham.Last.MaChiTietPhieuKham = ChiTietPhieuKhamBUS.GetMaChiTietPhieuKham() Then
                Dim ChiTietPhieuKham As New ROWChiTietPhieuKhamDTO() With {.MaChiTietPhieuKham = ChiTietPhieuKhamBUS.GetMaChiTietPhieuKham(),
                                                                       .MaKhamBenh = cbMaKhamBenh.SelectedValue}
                listChiTietPhieuKham.Add(ChiTietPhieuKham)
                dgChiTietPhieuKham.SelectedIndex = dgChiTietPhieuKham.Items.Count - 1
            End If
        Else
            Dim ChiTietPhieuKham As New ROWChiTietPhieuKhamDTO() With {.MaChiTietPhieuKham = ChiTietPhieuKhamBUS.GetMaChiTietPhieuKham(),
                                                                       .MaKhamBenh = cbMaKhamBenh.SelectedValue}
            listChiTietPhieuKham.Add(ChiTietPhieuKham)
            dgChiTietPhieuKham.SelectedIndex = dgChiTietPhieuKham.Items.Count - 1
        End If
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        If dgChiTietPhieuKham.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
        End If
        Dim ChiTietPhieuKham As New ChiTietPhieuKhamDTO
        ChiTietPhieuKham.MaChiTietPhieuKham = tbMaChiTietPhieuKham.Text
        ChiTietPhieuKham.MaKhamBenh = cbMaKhamBenh.Text
        ChiTietPhieuKham.TrieuChung = tbTrieuChung.Text
        ChiTietPhieuKham.MaLoaiBenh = cbLoaiBenh.SelectedValue
        ChiTietPhieuKham.MaThuoc = cbThuoc.SelectedValue
        ChiTietPhieuKham.MaDonVi = cbDonVi.SelectedValue

        If Not ChiTietPhieuKhamBUS.IsVaildSoLuong(tbSoLuong.Text, ChiTietPhieuKham.SoLuong) Then
            Domain.Dialog.Show("Số lượng không hợp lệ")
            Return
        End If

        ChiTietPhieuKham.MaCachDung = cbCachDung.SelectedValue
        Dim result As Boolean = ChiTietPhieuKhamBUS.InsertOrUpdateChiTietPhieuKham(ChiTietPhieuKham)
        If (result = True) Then
            Domain.Dialog.Show("Successful")
        Else
            Domain.Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        Dim result As Boolean
        For Each ChiTietPhieuKham As ChiTietPhieuKhamDTO In dgChiTietPhieuKham.SelectedItems
            result = DeleteChiTietPhieuKhamByMa(ChiTietPhieuKham.MaChiTietPhieuKham)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Successful")
        Else
            Domain.Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgChiTietPhieuKham.SelectedIndex = -1
    End Sub

    Private Sub ReloadData()
        If dgChiTietPhieuKham IsNot Nothing Then
            listChiTietPhieuKham = ROWChiTietPhieuKhamBUS.GetChiTietPhieuKhamByMaKhamBenh(cbMaKhamBenh.SelectedValue.ToString())
            dgChiTietPhieuKham.DataContext = listChiTietPhieuKham
        End If
    End Sub

    Private Sub LoadComboBoxData()
        If Me.IsVisible = True Then
            cbLoaiBenh.ItemsSource = LoaiBenhBUS.GetAllLoaiBenh()
            cbDonVi.ItemsSource = LoaiDonViBUS.GetAllLoaiDonVi()
            cbCachDung.ItemsSource = LoaiCachDungBUS.GetAllLoaiCachDung()
            cbThuoc.ItemsSource = LoaiThuocBUS.GetAllLoaiThuoc()
        End If
    End Sub

    Private Sub cbMaKhamBenh_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cbMaKhamBenh IsNot Nothing Then
            ReloadData()
        End If
    End Sub

    Private Sub dpNgayKhamBenh_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs)
        If dpNgayKhamBenh IsNot Nothing And dpNgayKhamBenh.SelectedDate IsNot Nothing Then
            cbMaKhamBenh.SelectedValuePath = "MaKhamBenh"
            cbMaKhamBenh.DisplayMemberPath = "MaKhamBenh"
            cbMaKhamBenh.ItemsSource = KhamBenhBUS.GetKhamBenhByNgayKham(dpNgayKhamBenh.SelectedDate)
        End If
    End Sub

    Private Sub cbMaKhamBenh_MouseDown(sender As Object, e As MouseButtonEventArgs)
        If dpNgayKhamBenh.SelectedDate Is Nothing Then
            Domain.Dialog.Show("Ngày khám chưa được chọn")
        End If
    End Sub

    Private Sub DatePickerDateValidationError(sender As Object, e As DatePickerDateValidationErrorEventArgs)
        Dim dp As DatePicker = sender
        e.ThrowException = False
        Domain.Dialog.Show("Ngày không hợp lệ")
        dp.SelectedDate = Date.Now()
    End Sub
End Class
