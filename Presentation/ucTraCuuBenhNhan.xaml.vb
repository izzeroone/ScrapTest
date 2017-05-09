Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data
Imports System.Text.RegularExpressions
Imports Business.Business
Imports Entities.Entities
Public Class ucTraCuuBenhNhan
    Dim listLoaiBenh As New ObservableCollection(Of LoaiBenhDTO)
    Dim listDonVi As New ObservableCollection(Of LoaiDonViDTO)
    Dim listCachDung As New ObservableCollection(Of LoaiCachDungDTO)
    Dim listThuoc As New ObservableCollection(Of LoaiThuocDTO)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cbLoaiBenh.ItemsSource = listLoaiBenh
        cbLoaiBenh.DisplayMemberPath = "TenLoaiBenh"
        cbLoaiBenh.SelectedValuePath = "MaLoaiBenh"
        cbDonVi.ItemsSource = listDonVi
        cbDonVi.DisplayMemberPath = "TenDonVi"
        cbDonVi.SelectedValuePath = "MaDonVi"
        cbCachDung.ItemsSource = listCachDung
        cbCachDung.DisplayMemberPath = "TenCachDung"
        cbCachDung.SelectedValuePath = "MaCachDung"
        cbThuoc.ItemsSource = listThuoc
        cbThuoc.DisplayMemberPath = "TenThuoc"
        cbThuoc.SelectedValuePath = "MaThuoc"
    End Sub


    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dpNgayKhamBatDau.SelectedDate = Nothing
        dpNgayKhamBatDau.DisplayDate = Date.Now()
        dpNgayKhamKetThuc.SelectedDate = Nothing
        dpNgayKhamKetThuc.DisplayDate = Date.Now()
    End Sub


    Private Sub LoadComboBoxData()
        If Me.IsVisible = True Then
            listLoaiBenh = LoaiBenhBUS.GetAllLoaiBenh()
            listLoaiBenh.Insert(0, New LoaiBenhDTO With {.MaLoaiBenh = "", .TenLoaiBenh = "Trống"})
            listDonVi = LoaiDonViBUS.GetAllLoaiDonVi()
            listDonVi.Insert(0, New LoaiDonViDTO With {.MaDonVi = "", .TenDonVi = "Trống"})
            listCachDung = LoaiCachDungBUS.GetAllLoaiCachDung()
            listCachDung.Insert(0, New LoaiCachDungDTO With {.MaCachDung = "", .TenCachDung = "Trống"})
            listThuoc = LoaiThuocBUS.GetAllLoaiThuoc()
            listThuoc.Insert(0, New LoaiThuocDTO With {.MaThuoc = "", .TenThuoc = "Trống"})
            cbLoaiBenh.ItemsSource = listLoaiBenh
            cbDonVi.ItemsSource = listDonVi
            cbCachDung.ItemsSource = listCachDung
            cbThuoc.ItemsSource = listThuoc
        End If
    End Sub

    Private Sub FindButton_Click(sender As Object, e As RoutedEventArgs)
        Dim ngayKhamBatDau As Date
        Dim ngayKhamKetThuc As Date
        'Dim hoTen As String
        Dim gioiTinh As String
        Dim namSinh As String = String.Empty
        Dim iNamSinh As Integer
        'Dim diaChi As String
        'Dim trieuChung As String
        Dim maLoaiBenh As String
        Dim maThuoc As String
        Dim maDonVi As String

        If dpNgayKhamBatDau.SelectedDate Is Nothing Then
            If dpNgayKhamKetThuc.SelectedDate Is Nothing Then
                ngayKhamBatDau = New Date(1, 1, 1)
                ngayKhamKetThuc = New Date(9999, 1, 1)
            Else
                ngayKhamBatDau = New Date(1, 1, 1)
                ngayKhamKetThuc = dpNgayKhamKetThuc.SelectedDate
            End If
        Else
            If dpNgayKhamKetThuc.SelectedDate Is Nothing Then
                ngayKhamBatDau = dpNgayKhamBatDau.SelectedDate
                ngayKhamKetThuc = New Date(9999, 1, 1)
            Else
                ngayKhamBatDau = dpNgayKhamBatDau.SelectedDate
                ngayKhamKetThuc = dpNgayKhamKetThuc.SelectedDate
            End If
        End If

        If cbGioiTinh.SelectedIndex < 0 Then
            gioiTinh = ""
        Else
            gioiTinh = cbGioiTinh.SelectedValue.ToString()
        End If

        If cbLoaiBenh.SelectedIndex < 0 Then
            maLoaiBenh = ""
        Else
            maLoaiBenh = cbLoaiBenh.SelectedValue
        End If

        If cbThuoc.SelectedIndex < 0 Then
            maThuoc = ""
        Else
            maThuoc = cbThuoc.SelectedValue
        End If

        If cbDonVi.SelectedIndex < 0 Then
            maDonVi = ""
        Else
            maDonVi = cbDonVi.SelectedValue
        End If

        'If Not String.IsNullOrWhiteSpace(tbNamSinh.Text) Then
        '    If Not (BenhNhanBUS.IsVaildNamSinh(tbNamSinh.Text, iNamSinh)) Then
        '        Domain.Dialog.Show("Năm sinh không hợp lệ")
        '    End If
        'Else
        '    namSinh = iNamSinh.ToString()
        'End If
        dgBenhNhan.ItemsSource = BenhNhanBUS.FindKhamBenh(ngayKhamBatDau,
                                                          ngayKhamKetThuc,
                                                          tbHoTen.Text,
                                                          gioiTinh,
                                                          namSinh,
                                                          tbDiaChi.Text,
                                                          tbTrieuChung.Text,
                                                          maLoaiBenh,
                                                          maThuoc,
                                                          maDonVi)
    End Sub
End Class
