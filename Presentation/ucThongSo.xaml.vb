Imports Business.Business
Imports Entities.Entities
Public Class ucThongSo

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        Dim soBenhNhanToiDa As Integer
        Dim tienKham As Integer
        If Not Integer.TryParse(tbSoBenhNhanToiDa.Text, soBenhNhanToiDa) Or Not Integer.TryParse(tbTienKham.Text, tienKham) Then
            Domain.Dialog.Show("Thông số phải là số")
        Else
            ThongSoBUS.UpdateSoBenhNhanToiDa(soBenhNhanToiDa)
            ThongSoBUS.UpdateTienKham(tienKham)
        End If
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        Reload()
    End Sub

    Private Sub DefaultButton_Click(sender As Object, e As RoutedEventArgs)
        ThongSoBUS.DefaultValue()
        Reload()
    End Sub

    Private Sub Reload()
        If Me.IsVisible Then
            ThongSoBUS.LoadThongSo()
            tbSoBenhNhanToiDa.Text = ThongSoDTO.SoBenhNhanKhamToiDa.ToString()
            tbTienKham.Text = ThongSoDTO.TienKham.ToString()
        End If
    End Sub


End Class
