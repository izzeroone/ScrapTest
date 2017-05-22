Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Text.RegularExpressions
Imports Business.Business
Imports Entities.Entities
Public Class ucPhieuKhamBenh
    Dim listKhamBenh As ObservableCollection(Of KhamBenhDTO)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ReloadData()
    End Sub

    Private Sub NumberValidationTextBox(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim regex As Regex = New Regex("[^0-9]+")
        e.Handled = regex.IsMatch(e.Text)
    End Sub

    Private Sub DateTextBox_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs)
        ReloadData()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        If Not listKhamBenh.Count = 0 Then
            If Not listKhamBenh.Last.MaKhamBenh = KhamBenhBUS.GetMaKhamBenh() Then
                Dim khamBenh As New KhamBenhDTO(KhamBenhBUS.GetMaKhamBenh(), dpNgayKham.SelectedDate, Nothing, Nothing, dpNgayKham.SelectedDate.Value.Year - 18, Nothing)
                listKhamBenh.Add(khamBenh)
                dgKhamBenh.SelectedIndex = dgKhamBenh.Items.Count - 1
            End If
        Else
            Dim khamBenh As New KhamBenhDTO(KhamBenhBUS.GetMaKhamBenh(), dpNgayKham.SelectedDate, Nothing, Nothing, dpNgayKham.SelectedDate.Value.Year - 18, Nothing)
            listKhamBenh.Add(khamBenh)
            dgKhamBenh.SelectedIndex = dgKhamBenh.Items.Count - 1
        End If
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        If (dgKhamBenh.SelectedIndex = -1) Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
            Return
        End If
        Dim khamBenh As New KhamBenhDTO
        khamBenh.MaKhamBenh = tbMaKhamBenh.Text
        khamBenh.HoTenBenhNhan = tbHoTen.Text
        khamBenh.NgayKham = dpNgayKham.SelectedDate

        If Not KhamBenhBUS.IsVaildNamSinh(tbNamSinh.Text, khamBenh.NamSinh) Then
            Domain.Dialog.Show("Năm sinh không hợp lệ")
            Return
        End If

        khamBenh.GioiTinh = tbGioiTinh.Text
        khamBenh.DiaChi = tbDiaChi.Text
        If KhamBenhBUS.IsKhamBenhInsertable(khamBenh) Then
            Dim result As Boolean = KhamBenhBUS.InsertOrUpdateKhamBenh(khamBenh)
            If (result = True) Then
                Domain.Dialog.Show("Successful")
            Else
                Domain.Dialog.Show("False")
            End If
        Else
            Domain.Dialog.Show("Vượt qua số bệnh nhân khám tối đa trong ngày")
        End If

        ReloadData()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        Dim result As Boolean
        For Each khamBenh As KhamBenhDTO In dgKhamBenh.SelectedItems
            result = DeleteKhamBenhByMa(khamBenh.MaKhamBenh)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Successful")
        Else
            Domain.Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgKhamBenh.SelectedIndex = -1
    End Sub

    Private Sub ReloadData()
        If dgKhamBenh IsNot Nothing And dpNgayKham.SelectedDate IsNot Nothing Then
            listKhamBenh = GetKhamBenhByNgayKham(dpNgayKham.SelectedDate)
            dgKhamBenh.DataContext = listKhamBenh
        End If
        If tbSoBenhNhan IsNot Nothing Then
            tbSoBenhNhan.Text = String.Format("Số bệnh nhân {0}/{1}", listKhamBenh.Count.ToString(), ThongSoDTO.SoBenhNhanKhamToiDa)
        End If
    End Sub

    Private Sub DatePickerDateValidationError(sender As Object, e As DatePickerDateValidationErrorEventArgs)
        Dim dp As DatePicker = sender
        e.ThrowException = False
        Domain.Dialog.Show("Ngày không hợp lệ")
        dp.SelectedDate = Date.Now()
    End Sub
End Class
