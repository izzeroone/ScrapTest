Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data
Imports System.Text.RegularExpressions
Imports Business.Business
Imports Entities.Entities
Public Class ucPhieuKham
    Dim listChiTietPhieuKham As ObservableCollection(Of ChiTietPhieuKhamDTO)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        listChiTietPhieuKham = New ObservableCollection(Of ChiTietPhieuKhamDTO)
        cbMaKhamBenh.ItemsSource = KhamBenhBUS.GetAllMaKhamBenh()
        cbLoaiBenh.ItemsSource = LoaiBenhBUS.GetAllLoaiBenh()
        cbLoaiBenh.DisplayMemberPath = "TenLoaiBenh"
        cbLoaiBenh.SelectedValuePath = "MaLoaiBenh"
        cbDonVi.ItemsSource = LoaiDonViBUS.GetAllLoaiDonVi()
        cbDonVi.DisplayMemberPath = "TenDonVi"
        cbDonVi.SelectedValuePath = "MaDonVi"
        cbCachDung.ItemsSource = LoaiCachDungBUS.GetAllLoaiCachDung()
        cbCachDung.DisplayMemberPath = "TenCachDung"
        cbCachDung.SelectedValuePath = "MaCachDung"
        cbThuoc.ItemsSource = LoaiThuocBUS.GetAllLoaiThuoc()
        cbThuoc.DisplayMemberPath = "TenThuoc"
        cbThuoc.SelectedValuePath = "MaThuoc"
    End Sub

    Private Sub NumberValidationTextBox(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim regex As Regex = New Regex("[^0-9]+")
        e.Handled = regex.IsMatch(e.Text)
    End Sub


    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        If Not listChiTietPhieuKham.Count = 0 Then
            If Not listChiTietPhieuKham.Last.MaChiTietPhieuKham = ChiTietPhieuKhamBUS.GetMaChiTietPhieuKham() Then
                Dim ChiTietPhieuKham As New ChiTietPhieuKhamDTO(ChiTietPhieuKhamBUS.GetMaChiTietPhieuKham(), cbMaKhamBenh.SelectedValue, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                listChiTietPhieuKham.Add(ChiTietPhieuKham)
                dgChiTietPhieuKham.SelectedIndex = dgChiTietPhieuKham.Items.Count - 1
            End If
        Else
            Dim ChiTietPhieuKham As New ChiTietPhieuKhamDTO(ChiTietPhieuKhamBUS.GetMaChiTietPhieuKham(), cbMaKhamBenh.SelectedValue, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            listChiTietPhieuKham.Add(ChiTietPhieuKham)
            dgChiTietPhieuKham.SelectedIndex = dgChiTietPhieuKham.Items.Count - 1
        End If
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        Dim ChiTietPhieuKham As New ChiTietPhieuKhamDTO
        ChiTietPhieuKham.MaChiTietPhieuKham = tbMaChiTietPhieuKham.Text
        ChiTietPhieuKham.MaKhamBenh = cbMaKhamBenh.Text
        ChiTietPhieuKham.TrieuChung = tbTrieuChung.Text
        ChiTietPhieuKham.MaLoaiBenh = cbLoaiBenh.SelectedValue
        ChiTietPhieuKham.MaThuoc = cbThuoc.SelectedValue
        ChiTietPhieuKham.MaDonVi = cbDonVi.SelectedValue

        If Not ChiTietPhieuKhamBUS.IsVaildSoLuong(tbSoLuong.Text, ChiTietPhieuKham.SoLuong) Then
            Domain.Dialog.Show("Năm sinh không hợp lệ")
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
            listChiTietPhieuKham = GetChiTietPhieuKhamByMaNgayKham(cbMaKhamBenh.SelectedValue)
            dgChiTietPhieuKham.DataContext = listChiTietPhieuKham
        End If
    End Sub

    Private Sub cbMaKhamBenh_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cbMaKhamBenh IsNot Nothing Then
            ReloadData()
        End If
    End Sub
End Class
