Imports System.Collections.ObjectModel
Imports Business.Business
Imports Entities.Entities
Imports MaterialDesignThemes.Wpf

Public Class ucLoaiDonVi
    Private listLoaiDonVi As ObservableCollection(Of LoaiDonViDTO)
    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgLoaiDonVi.SelectedIndex = -1
    End Sub

    Private Async Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng có muốn xóa hay không
        Dim dialog As New Domain.YesNoDialog
        dialog.Message.Text = "Bạn chắc chắn xóa " + dgLoaiDonVi.SelectedItems.Count.ToString() + " loại đơn vị được chọn"
        Await DialogHost.Show(dialog)
        If (dialog.DialogResult = MessageBoxResult.No) Then
            Exit Sub
        End If
        'Tiến hành xóa
        Dim result As Boolean
        For Each loaiDonVi As LoaiDonViDTO In dgLoaiDonVi.SelectedItems
            result = LoaiDonViBUS.DeleteDonViByMa(loaiDonVi.MaDonVi)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Xóa thành công")
        Else
            Domain.Dialog.Show("Xóa thất bại")
        End If
        ReloadData()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng đã chọn loại đơn vị trong danh sách chưa
        If dgLoaiDonVi.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
            Exit Sub
        End If
        'Lấy thông tin người dùng nhập vào và kiểm tra
        Dim loaiDonVi As New LoaiDonViDTO()
        loaiDonVi.MaDonVi = tbMaDonVi.Text
        If tbTenDonVi.Text.Trim() = "" Then
            Domain.Dialog.Show("Bạn chưa nhập tên đơn vị")
            Exit Sub
        End If
        loaiDonVi.TenDonVi = tbTenDonVi.Text
        'Tiến hành cập nhật
        Dim result As Boolean = LoaiDonViBUS.InsertOrUpdateDonVi(loaiDonVi)
        If (result = True) Then
            Domain.Dialog.Show("Cập nhật thành công")
        Else
            Domain.Dialog.Show("Cập nhật thất bại")
        End If
        ReloadData()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra danh sách loại đơn vị có trống hay không
        If Not listLoaiDonVi.Count = 0 Then
            'Kiểm tra người dùng đã cập nhật loại đơn vị thêm vào trước đó hay chưa
            If Not listLoaiDonVi.Last.MaDonVi = LoaiDonViBUS.GetMaDonVi() Then
                'Thêm loại đơn vị trống mới vào danh sách
                Dim LoaiDonVi As New LoaiDonViDTO(LoaiDonViBUS.GetMaDonVi(), Nothing)
                listLoaiDonVi.Add(LoaiDonVi)
                dgLoaiDonVi.SelectedIndex = dgLoaiDonVi.Items.Count - 1
            Else
                Domain.Dialog.Show("Bạn chưa cập nhật loại đơn vị bạn mới thêm vào trước đó")
                Exit Sub
            End If
        Else
            'Thêm loại đơn vị trống mới vào danh sách
            Dim LoaiDonVi As New LoaiDonViDTO(LoaiDonViBUS.GetMaDonVi(), Nothing)
            listLoaiDonVi.Add(LoaiDonVi)
            dgLoaiDonVi.SelectedIndex = dgLoaiDonVi.Items.Count - 1
        End If
    End Sub
    Private Sub ReloadData()
        'Cập nhật lại danh sách loại đơn vị khi người dùng vào màn hình
        If dgLoaiDonVi IsNot Nothing And Me.IsVisible Then
            listLoaiDonVi = LoaiDonViBUS.GetAllLoaiDonVi()
            dgLoaiDonVi.DataContext = listLoaiDonVi
        End If
    End Sub
End Class
