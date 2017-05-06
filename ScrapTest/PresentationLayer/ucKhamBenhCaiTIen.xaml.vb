Imports System.Data
Imports System.Text.RegularExpressions

Public Class ucKhamBenhCaiTIen
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim data As DataTable = GetKhamBenhByDate(DateTextBox.SelectedDate)
        dataView.DataContext = data
    End Sub

    Private Sub NumberValidationTextBox(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim regex As Regex = New Regex("[^0-9]+")
        e.Handled = regex.IsMatch(e.Text)
    End Sub

    Private Sub DateTextBox_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs)
        ReloadData()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        dataView.SelectedIndex = -1
        MaTextBox.Text = GetMaKhamBenhBus()
        NameTextBox.Clear()
        DateTextBox.SelectedDate = Date.Now
        AddressTextBox.Clear()
        GenderTextBox.SelectedIndex = 0
        YearTextBox.Clear()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        Dim khamBenh As New KhamBenh
        khamBenh.MaKhamBenh = MaTextBox.Text
        MessageBox.Show(MaTextBox.Text)
        khamBenh.HoTenBenhNhan = NameTextBox.Text
        khamBenh.NgayKham = DateTextBox.SelectedDate

        Try
            khamBenh.NamSinh = Integer.Parse(YearTextBox.Text)
        Catch ex As Exception
            Dialog.Show("Nam sinh khong hop le")
        End Try

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

    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub ReloadData()
        If dataView IsNot Nothing And DateTextBox.SelectedDate IsNot Nothing Then
            Dim data As DataTable = GetKhamBenhByDate(DateTextBox.SelectedDate)
            dataView.DataContext = data
        End If
    End Sub
End Class
