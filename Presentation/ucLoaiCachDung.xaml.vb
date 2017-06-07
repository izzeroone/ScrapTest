Imports System.Collections.ObjectModel
Imports Business.Business
Imports Entities.Entities
Imports MaterialDesignThemes.Wpf

Public Class ucLoaiCachDung
    Private listLoaiCachDung As ObservableCollection(Of LoaiCachDungDTO)
    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgLoaiCachDung.SelectedIndex = -1
    End Sub

    Private Async Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng có muốn xóa hay không
        Dim dialog As New Domain.YesNoDialog
        dialog.Message.Text = "Bạn chắc chắn xóa " + dgLoaiCachDung.SelectedItems.Count.ToString() + " loại cách dùng được chọn"
        Await DialogHost.Show(dialog)
        If (dialog.DialogResult = MessageBoxResult.No) Then
            Exit Sub
        End If
        'Tiến hành xóa
        Dim result As Boolean
        For Each loaiCachDung As LoaiCachDungDTO In dgLoaiCachDung.SelectedItems
            result = LoaiCachDungBUS.DeleteCachDungByMa(loaiCachDung.MaCachDung)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Xóa thành công")
        Else
            Domain.Dialog.Show("Xóa thất bại")
        End If
        ReloadData()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng đã chọn loại cách dùng trong danh sách chưa
        If dgLoaiCachDung.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
            Return
        End If
        'Lấy thông tin người dùng nhập vào và kiểm tra
        Dim loaiCachDung As New LoaiCachDungDTO()
        loaiCachDung.MaCachDung = tbMaCachDung.Text
        If tbTenCachDung.Text.Trim() = "" Then
            Domain.Dialog.Show("Bạn chưa nhập tên cách dùng")
            Exit Sub
        End If
        loaiCachDung.TenCachDung = tbTenCachDung.Text
        'Tiến hành cập nhật
        Dim result As Boolean = LoaiCachDungBUS.InsertOrUpdateCachDung(loaiCachDung)
        If (result = True) Then
            Domain.Dialog.Show("Cập nhật thành công")
        Else
            Domain.Dialog.Show("Cập nhật thất bại")
        End If
        ReloadData()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra danh sách loại cách dùng có trống hay không
        If Not listLoaiCachDung.Count = 0 Then
            'Kiểm tra người dùng đã cập nhật loại cách dùng mới thêm vào chưa
            If Not listLoaiCachDung.Last.MaCachDung = LoaiCachDungBUS.GetMaCachDung() Then
                'Thêm loại cách dùng trống mới vào danh sách
                Dim LoaiCachDung As New LoaiCachDungDTO(LoaiCachDungBUS.GetMaCachDung(), Nothing)
                listLoaiCachDung.Add(LoaiCachDung)
                dgLoaiCachDung.SelectedIndex = dgLoaiCachDung.Items.Count - 1
            Else
                Domain.Dialog.Show("Bạn chưa cập nhật loại cách dùng bạn mới thêm vào trước đó")
                Exit Sub
            End If
        Else
            'Thêm loại cách dùng trống mới vào danh sách
            Dim LoaiCachDung As New LoaiCachDungDTO(LoaiCachDungBUS.GetMaCachDung(), Nothing)
            listLoaiCachDung.Add(LoaiCachDung)
            dgLoaiCachDung.SelectedIndex = dgLoaiCachDung.Items.Count - 1
        End If
    End Sub
    Private Sub ReloadData()
        'Cập nhật danh sách các loại cách dùng khi người dùng vào màn hình
        If dgLoaiCachDung IsNot Nothing And Me.IsVisible Then
            listLoaiCachDung = LoaiCachDungBUS.GetAllLoaiCachDung()
            dgLoaiCachDung.DataContext = listLoaiCachDung
        End If
    End Sub
End Class
