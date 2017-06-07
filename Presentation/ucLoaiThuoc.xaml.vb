Imports System.Collections.ObjectModel
Imports System.Text.RegularExpressions
Imports Business.Business
Imports Entities.Entities
Imports MaterialDesignThemes.Wpf

Public Class ucLoaiThuoc
    Private listLoaiThuoc As ObservableCollection(Of LoaiThuocDTO)
    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgLoaiThuoc.SelectedIndex = -1
    End Sub

    Private Sub NumberValidationTextBox(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim regex As Regex = New Regex("[^0-9]+")
        e.Handled = regex.IsMatch(e.Text)
    End Sub

    Private Async Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng có muốn xóa hay không
        Dim dialog As New Domain.YesNoDialog
        dialog.Message.Text = "Bạn chắc chắn xóa " + dgLoaiThuoc.SelectedItems.Count.ToString() + " loại thuốc được chọn"
        Await DialogHost.Show(dialog)
        If (dialog.DialogResult = MessageBoxResult.No) Then
            Exit Sub
        End If
        'Tiến hành xóa  
        Dim result As Boolean
        For Each loaiThuoc As LoaiThuocDTO In dgLoaiThuoc.SelectedItems
            result = LoaiThuocBUS.DeleteThuocByMa(loaiThuoc.MaThuoc)
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
        If dgLoaiThuoc.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
            Exit Sub
        End If
        'Lấy thông tin từ người dùng và kiểm tra
        Dim loaiThuoc As New LoaiThuocDTO()
        loaiThuoc.MaThuoc = tbMaThuoc.Text
        If tbTenThuoc.Text.Trim() = "" Then
            Domain.Dialog.Show("Bạn chưa nhập tên thuốc")
            Exit Sub
        End If
        loaiThuoc.TenThuoc = tbTenThuoc.Text
        If Not LoaiThuocBUS.IsVaildDonGia(tbDonGia.Text, loaiThuoc.DonGia) Then
            Domain.Dialog.Show("Đơn giá không hợp lệ")
            Exit Sub
        End If
        'Tiến hành cập nhật
        Dim result As Boolean = LoaiThuocBUS.InsertOrUpdateThuoc(loaiThuoc)
        If (result = True) Then
            Domain.Dialog.Show("Cập nhật thành công")
        Else
            Domain.Dialog.Show("Cập nhật thất bại")
        End If
        ReloadData()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra danh sách loại thuốc có trống hay không
        If Not listLoaiThuoc.Count = 0 Then
            'Kiểm tra người dùng đã cập nhật loại thuốc mới thêm vào trước đó
            If Not listLoaiThuoc.Last.MaThuoc = LoaiThuocBUS.GetMaThuoc() Then
                'Thêm loại thuốc trống mới vào danh sách
                Dim LoaiThuoc As New LoaiThuocDTO(LoaiThuocBUS.GetMaThuoc(), Nothing)
                listLoaiThuoc.Add(LoaiThuoc)
                dgLoaiThuoc.SelectedIndex = dgLoaiThuoc.Items.Count - 1
            Else
                Domain.Dialog.Show("Bạn chưa cập nhật loại thuốc bạn mới thêm vào trước đó")
                Exit Sub
            End If
        Else
            'Thêm loại thuốc trống mới vào danh sách
            Dim LoaiThuoc As New LoaiThuocDTO(LoaiThuocBUS.GetMaThuoc(), Nothing)
            listLoaiThuoc.Add(LoaiThuoc)
            dgLoaiThuoc.SelectedIndex = dgLoaiThuoc.Items.Count - 1
        End If
    End Sub
    Private Sub ReloadData()
        'Cập nhật lại danh sách loại thuốc khi người dùng vào màn hình
        If dgLoaiThuoc IsNot Nothing And Me.IsVisible Then
            listLoaiThuoc = LoaiThuocBUS.GetAllLoaiThuoc()
            dgLoaiThuoc.DataContext = listLoaiThuoc
        End If
    End Sub
End Class
