Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Text.RegularExpressions
Imports Business.Business
Imports Entities.Entities
Imports MaterialDesignThemes.Wpf

Public Class ucDanhSachKhamBenh
    Dim listKhamBenh As ObservableCollection(Of KhamBenhDTO)
    Dim firstLoad As Boolean = True 'Có phải làn đầu tiền vào màn hình hay không

    Private Sub NumberValidationTextBox(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim regex As Regex = New Regex("[^0-9]+")
        e.Handled = regex.IsMatch(e.Text)
    End Sub

    Private Sub DateTextBox_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs)
        ReloadData()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng đã chọn ngày hay chưa và trong danh sách có bệnh nhân chưa
        If Not listKhamBenh.Count = 0 And dpNgayKham.SelectedDate IsNot Nothing Then
            'Kiểm tra người dùng có cập nhật bệnh nhân trước đó hay chưa
            If Not listKhamBenh.Last.MaKhamBenh = KhamBenhBUS.GetMaKhamBenh() Then
                'Thêm khám bệnh mới
                Dim khamBenh As New KhamBenhDTO(KhamBenhBUS.GetMaKhamBenh(), dpNgayKham.SelectedDate, Nothing, Nothing, dpNgayKham.SelectedDate.Value.Year - 18, Nothing)
                listKhamBenh.Add(khamBenh)
                dgKhamBenh.SelectedIndex = dgKhamBenh.Items.Count - 1
            Else
                Domain.Dialog.Show("Bạn chưa cập nhật bệnh nhân bạn mới thêm vào trước đó")
                Exit Sub
            End If
        Else
            'Thêm khám bệnh mới
            Dim khamBenh As New KhamBenhDTO(KhamBenhBUS.GetMaKhamBenh(), dpNgayKham.SelectedDate, Nothing, Nothing, dpNgayKham.SelectedDate.Value.Year - 18, Nothing)
            listKhamBenh.Add(khamBenh)
            dgKhamBenh.SelectedIndex = dgKhamBenh.Items.Count - 1
        End If
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra đã có bệnh nhân được chọn chưa
        If (dgKhamBenh.SelectedIndex = -1) Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
            Exit Sub
        End If
        'Lấy dữ liệu vào kiểm tra dữ liệu người dùng nhập vào
        Dim khamBenh As New KhamBenhDTO
        khamBenh.MaKhamBenh = tbMaKhamBenh.Text
        khamBenh.HoTenBenhNhan = tbHoTen.Text
        khamBenh.NgayKham = dpNgayKham.SelectedDate
        If Not KhamBenhBUS.IsVaildNamSinh(tbNamSinh.Text, khamBenh.NamSinh) Then
            Domain.Dialog.Show("Năm sinh không hợp lệ")
            Exit Sub
        End If
        khamBenh.GioiTinh = tbGioiTinh.Text
        khamBenh.DiaChi = tbDiaChi.Text
        If Not KhamBenhBUS.IsVaildKhamBenh(khamBenh) Then
            Domain.Dialog.Show("Thông tin bệnh nhân không hợp lệ")
            Exit Sub
        End If
        'Kiểm tra có thỏa mãn thông số số bệnh nhân tối đa hay không
        If KhamBenhBUS.IsKhamBenhInsertable(khamBenh) Then
            'Thực hiện việc thêm hoặc cập nhật
            Dim result As Boolean = KhamBenhBUS.InsertOrUpdateKhamBenh(khamBenh)
            If (result = True) Then
                Domain.Dialog.Show("Cập nhật thành công")
            Else
                Domain.Dialog.Show("Cập nhật thất bại")
            End If
        Else
            Domain.Dialog.Show("Vượt qua số bệnh nhân khám tối đa trong ngày")
        End If

        ReloadData()
    End Sub

    Private Async Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        'Cảnh bảo người dùng về việc xóa
        Dim dialog As New Domain.YesNoDialog
        dialog.Message.Text = "Bạn chắc chắn xóa " + dgKhamBenh.SelectedItems.Count.ToString() + " bệnh nhân được chọn"
        Await DialogHost.Show(dialog)
        If (dialog.DialogResult = MessageBoxResult.No) Then
            Exit Sub
        End If
        'Thực hiện xóa
        Dim result As Boolean
        For Each khamBenh As KhamBenhDTO In dgKhamBenh.SelectedItems
            result = DeleteKhamBenhByMa(khamBenh.MaKhamBenh)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Xóa thành công")
        Else
            Domain.Dialog.Show("Xóa thất bại")
        End If
        ReloadData()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgKhamBenh.SelectedIndex = -1
    End Sub

    ''' <summary>
    ''' Tải lại danh sách bệnh nhân và đếm số bệnh nhân
    ''' </summary>
    Private Sub ReloadData()
        If dgKhamBenh IsNot Nothing And dpNgayKham.SelectedDate IsNot Nothing Then
            listKhamBenh = GetKhamBenhByNgayKham(dpNgayKham.SelectedDate)
            dgKhamBenh.DataContext = listKhamBenh
        End If
        If tbSoBenhNhan IsNot Nothing Then
            tbSoBenhNhan.Text = String.Format("Số bệnh nhân {0}/{1}", listKhamBenh.Count.ToString(), ThongSoDTO.SoBenhNhanKhamToiDa)
        End If
    End Sub

    Private Sub DatePickerDateValidationError(sender As Object, e As DatePickerDateValidationErrorEventArgs)
        Dim dp As DatePicker = sender
        e.ThrowException = False
        Domain.Dialog.Show("Ngày không hợp lệ")
        dp.SelectedDate = Date.Now()
    End Sub

    Private Sub UserControl_IsVisibleChanged(sender As Object, e As DependencyPropertyChangedEventArgs)
        If firstLoad And IsVisible = True Then
            'Khi người dùng màn hình đầu tiên thì cập nhật ngày bằng ngày hiện tại
            dpNgayKham.SelectedDate = Date.Now
            firstLoad = False
            ThongSoBUS.LoadThongSo()
        End If
    End Sub
End Class
