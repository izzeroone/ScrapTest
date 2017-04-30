Public Class ucKhamBenh
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim khamBenh As New KhamBenh
        khamBenh.HoTenBenhNhan = NameTextBox.Text
        khamBenh.NgayKham = DateTextBox.DisplayDate
        khamBenh.NamSinh = Integer.Parse(YearTextBox.Text)
        khamBenh.GioiTinh = GenderTextBox.Text
        khamBenh.DiaChi = AddressTextBox.Text
        Dim result As Boolean = InsertKhamBenhBus(khamBenh)
        If (result = True) Then
            Dialog.Show("Successful")
        Else
            Dialog.Show("False")
        End If
    End Sub
End Class
