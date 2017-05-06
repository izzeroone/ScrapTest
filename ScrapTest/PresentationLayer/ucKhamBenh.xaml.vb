Imports System.ComponentModel
Imports System.Data
Imports System.Text.RegularExpressions

Public Class ucKhamBenh
    Dim listKhamBenh As BindingList(Of KhamBenh)
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
        If Not listKhamBenh.Last.MaKhamBenh = GetMaKhamBenhBus() Then
            Dim khamBenh As New KhamBenh(GetMaKhamBenhBus(), DateTextBox.SelectedDate, Nothing, Nothing, DateTextBox.SelectedDate.Value.Year - 18, Nothing)
            listKhamBenh.Add(khamBenh)
            dataView.SelectedIndex = dataView.Items.Count - 1
        End If
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        Dim khamBenh As New KhamBenh
        khamBenh.MaKhamBenh = MaTextBox.Text
        khamBenh.HoTenBenhNhan = NameTextBox.Text
        khamBenh.NgayKham = DateTextBox.SelectedDate

        If Not IsVaildNamSinhBus(YearTextBox.Text, khamBenh.NamSinh) Then
            Dialog.Show("Năm sinh không hợp lệ")
            Return
        End If

        khamBenh.GioiTinh = GenderTextBox.Text
        khamBenh.DiaChi = AddressTextBox.Text
        Dim result As Boolean = InsertOrUpdateKhamBenhBus(khamBenh)
        If (result = True) Then
            Dialog.Show("Successful")
        Else
            Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        Dim result As Boolean
        For Each khamBenh As KhamBenh In DataView.SelectedItems
            result = DeleteKhamBenhById(khamBenh.MaKhamBenh)
        Next
        If (result = True) Then
            Dialog.Show("Successful")
        Else
            Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        DataView.SelectedIndex = -1
    End Sub

    Private Sub ReloadData()
        If dataView IsNot Nothing And DateTextBox.SelectedDate IsNot Nothing Then
            listKhamBenh = GetKhamBenhByDate(DateTextBox.SelectedDate)
            dataView.DataContext = listKhamBenh
        End If
    End Sub
End Class
