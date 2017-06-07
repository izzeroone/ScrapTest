Imports Business.Business
Imports Entities.Entities
Public Class ucThongSo

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        Dim soBenhNhanToiDa As Integer
        Dim tienKham As Integer
        'Lấy thông tin người dùng nhập vào và kiểm tra
        If Not Integer.TryParse(tbSoBenhNhanToiDa.Text, soBenhNhanToiDa) Or Not Integer.TryParse(tbTienKham.Text, tienKham) Then
            Domain.Dialog.Show("Thông số không hợp lệ")
        Else
            'Cập nhật thông số
            ThongSoBUS.UpdateSoBenhNhanToiDa(soBenhNhanToiDa)
            ThongSoBUS.UpdateTienKham(tienKham)
            Domain.Dialog.Show("Cập nhật thông số thành công")
        End If
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        Reload()
    End Sub

    Private Sub DefaultButton_Click(sender As Object, e As RoutedEventArgs)
        'Đặt cấu hình mặc định
        ThongSoBUS.SetDefaultValue()
        Reload()
        Domain.Dialog.Show("Cập nhật thông số thành công")
    End Sub

    Private Sub Reload()
        'Khi người dùng vào màn hình thì tải lại thông số từ cơ sở dữ liệu
        If Me.IsVisible Then
            'Tải thông số từ cơ sỡ dữ liệu
            ThongSoBUS.LoadThongSo()
            'Cập nhật hiển thị
            tbSoBenhNhanToiDa.Text = ThongSoDTO.SoBenhNhanKhamToiDa.ToString()
            tbTienKham.Text = ThongSoDTO.TienKham.ToString()
        End If
    End Sub


End Class
