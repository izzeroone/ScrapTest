Imports System.Collections.ObjectModel
Imports Business.Business
Imports Entities.Entities
Imports MaterialDesignThemes.Wpf

Public Class ucLoaiBenh
    Private listLoaiBenh As ObservableCollection(Of LoaiBenhDTO)
    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgLoaiBenh.SelectedIndex = -1
    End Sub

    Private Async Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng có muốn xóa hay không
        Dim dialog As New Domain.YesNoDialog
        dialog.Message.Text = "Bạn có chắc chắn xóa " + dgLoaiBenh.SelectedItems.Count.ToString() + " loại bệnh được chọn"
        Await DialogHost.Show(dialog)
        If (dialog.DialogResult = MessageBoxResult.No) Then
            Exit Sub
        End If
        'Tiến hành xóa
        Dim result As Boolean
        For Each loaiBenh As LoaiBenhDTO In dgLoaiBenh.SelectedItems
            result = LoaiBenhBUS.DeleteLoaiBenhByMa(loaiBenh.MaLoaiBenh)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Xóa thành công")
        Else
            Domain.Dialog.Show("Xóa thất bại")
        End If
        ReloadData()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng đã chọn trong danh sách chưa
        If dgLoaiBenh.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
            Return
        End If
        'Lấy thông tin từ người dùng nhập vào
        Dim loaiBenh As New LoaiBenhDTO()
        loaiBenh.MaLoaiBenh = tbMaLoaiBenh.Text
        If tbTenLoaiBenh.Text.Trim() = "" Then
            Domain.Dialog.Show("Bạn chưa nhập tên loại bệnh")
            Exit Sub
        End If
        loaiBenh.TenLoaiBenh = tbTenLoaiBenh.Text
        'Tiến hành cập nhật
        Dim result As Boolean = LoaiBenhBUS.InsertOrUpdateLoaiBenh(loaiBenh)
        If (result = True) Then
            Domain.Dialog.Show("Cập nhật thành công")
        Else
            Domain.Dialog.Show("Cập nhật thất bại")
        End If
        ReloadData()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra danh sách loại bệnh có trống không
        If Not listLoaiBenh.Count = 0 Then
            'Kiểm tra người dùng đã cập nhật loại bệnh thêm vào trước đó hay chưa
            If Not listLoaiBenh.Last.MaLoaiBenh = LoaiBenhBUS.GetMaLoaiBenh() Then
                'Thêm loại bệnh trống mới vào danh sách
                Dim loaiBenh As New LoaiBenhDTO(LoaiBenhBUS.GetMaLoaiBenh(), Nothing)
                listLoaiBenh.Add(loaiBenh)
                dgLoaiBenh.SelectedIndex = dgLoaiBenh.Items.Count - 1
            Else
                Domain.Dialog.Show("Bạn chưa cập nhật loại bệnh bạn mới thêm vào trước đó")
                Exit Sub
            End If
        Else
            'Thêm loại bệnh trống mới vào danh sách
            Dim loaiBenh As New LoaiBenhDTO(LoaiBenhBUS.GetMaLoaiBenh(), Nothing)
            listLoaiBenh.Add(loaiBenh)
            dgLoaiBenh.SelectedIndex = dgLoaiBenh.Items.Count - 1
        End If
    End Sub
    Private Sub ReloadData()
        'Khi người dùng vào màn hình thì cập nhật lại danh sách loại bệnh
        If dgLoaiBenh IsNot Nothing And Me.IsVisible Then
            listLoaiBenh = LoaiBenhBUS.GetAllLoaiBenh()
            dgLoaiBenh.DataContext = listLoaiBenh
        End If
    End Sub
End Class
