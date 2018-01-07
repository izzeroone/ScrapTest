Imports System.Collections.ObjectModel
Imports System.Text.RegularExpressions
Imports Business.Business
Imports Entities.Entities
Imports MaterialDesignThemes.Wpf

Public Class ucLoaiDichVu
    Private listLoaiDichVu As ObservableCollection(Of LoaiDichVuDTO)
    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgDichVu.SelectedIndex = -1
    End Sub

    Private Sub NumberValidationTextBox(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim regex As Regex = New Regex("[^0-9]+")
        e.Handled = regex.IsMatch(e.Text)
    End Sub

    Private Async Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng có muốn xóa hay không
        Dim dialog As New Domain.YesNoDialog
        dialog.Message.Text = "Bạn chắc chắn xóa " + dgDichVu.SelectedItems.Count.ToString() + " loại dịch vụ được chọn"
        Await DialogHost.Show(dialog)
        If (dialog.DialogResult = MessageBoxResult.No) Then
            Exit Sub
        End If
        'Tiến hành xóa  
        Dim result As Boolean
        For Each loaiDichVu As LoaiDichVuDTO In dgDichVu.SelectedItems
            result = LoaiDichVuBUS.DeleteDichVuByMa(loaiDichVu.MaDichVu)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Xóa thành công")
        Else
            Domain.Dialog.Show("Xóa thất bại")
        End If
        ReloadData()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng đã chọn loại thuốc trong danh sách chưa
        If dgDichVu.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
            Exit Sub
        End If
        'Lấy thông tin từ người dùng và kiểm tra
        Dim loaiDichVu As New LoaiDichVuDTO()
        loaiDichVu.MaDichVu = tbMaDichVu.Text
        If tbTenDichVu.Text.Trim() = "" Then
            Domain.Dialog.Show("Bạn chưa nhập tên dịch vụ")
            Exit Sub
        End If
        loaiDichVu.TenDichVu = tbTenDichVu.Text
        If Not LoaiDichVuBUS.IsVaildDonGia(tbDonGia.Text, loaiDichVu.DonGia) Then
            Domain.Dialog.Show("Đơn giá không hợp lệ")
            Exit Sub
        End If

        If cbDonVi.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa chọn đơn vị")
            Exit Sub
        End If
        loaiDichVu.MaDonVi = cbDonVi.SelectedValue

        'Tiến hành cập nhật
        Dim result As Boolean = LoaiDichVuBUS.InsertOrUpdateDichVu(loaiDichVu)
        If (result = True) Then
            Domain.Dialog.Show("Cập nhật thành công")
        Else
            Domain.Dialog.Show("Cập nhật thất bại")
        End If
        ReloadData()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra danh sách loại thuốc có trống hay không
        If Not listLoaiDichVu.Count = 0 Then
            'Kiểm tra người dùng đã cập nhật loại thuốc mới thêm vào trước đó
            If Not listLoaiDichVu.Last.MaDichVu = LoaiDichVuBUS.GetMaDichVu() Then
                'Thêm loại thuốc trống mới vào danh sách
                Dim LoaiDichVu As New LoaiDichVuDTO() With {.MaDichVu = LoaiDichVuBUS.GetMaDichVu()}
                listLoaiDichVu.Add(LoaiDichVu)
                dgDichVu.SelectedIndex = dgDichVu.Items.Count - 1
            Else
                Domain.Dialog.Show("Bạn chưa cập nhật loại dịch vụ bạn mới thêm vào trước đó")
                Exit Sub
            End If
        Else
            'Thêm loại thuốc trống mới vào danh sách
            Dim LoaiDichVu As New LoaiDichVuDTO() With {.MaDichVu = LoaiDichVuBUS.GetMaDichVu()}
            listLoaiDichVu.Add(LoaiDichVu)
            dgDichVu.SelectedIndex = dgDichVu.Items.Count - 1
        End If
    End Sub
    Private Sub ReloadData()
        'Cập nhật lại danh sách loại thuốc khi người dùng vào màn hình
        If dgDichVu IsNot Nothing And Me.IsVisible Then
            listLoaiDichVu = LoaiDichVuBUS.GetAllLoaiDichVu()
            dgDichVu.DataContext = listLoaiDichVu
        End If
    End Sub

    Private Sub LoadComboBoxData()
        If Me.IsVisible = True Then
            cbDonVi.ItemsSource = LoaiDonViBUS.GetAllLoaiDonVi()
            ReloadData()
        End If
    End Sub
End Class
