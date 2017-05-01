Imports System.Text.RegularExpressions

Public Class ucKhamBenh
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MaTextBox.Text = GetMaKhamBenh()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim khamBenh As New KhamBenh
        khamBenh.HoTenBenhNhan = NameTextBox.Text
        khamBenh.NgayKham = DateTextBox.SelectedDate

        Try
            khamBenh.NamSinh = Integer.Parse(YearTextBox.Text)
        Catch ex As Exception
            Dialog.Show("Nam sinh khong hop le")
        End Try

        khamBenh.GioiTinh = GenderTextBox.Text
        khamBenh.DiaChi = AddressTextBox.Text
        Dim result As Boolean = InsertKhamBenhBus(khamBenh)
        If (result = True) Then
            Dialog.Show("Successful")
        Else
            Dialog.Show("False")
        End If
    End Sub

    Private Sub NumberValidationTextBox(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim regex As Regex = New Regex("[^0-9]+")
        e.Handled = regex.IsMatch(e.Text)
    End Sub
End Class
