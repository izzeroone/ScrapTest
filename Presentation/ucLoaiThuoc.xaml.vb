Imports System.Collections.ObjectModel
Imports System.Text.RegularExpressions
Imports Business.Business
Imports Entities.Entities
Public Class ucLoaiThuoc
    Private listLoaiThuoc As ObservableCollection(Of LoaiThuocDTO)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ReloadData()
    End Sub
    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgLoaiThuoc.SelectedIndex = -1
    End Sub

    Private Sub NumberValidationTextBox(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim regex As Regex = New Regex("[^0-9]+")
        e.Handled = regex.IsMatch(e.Text)
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        Dim result As Boolean
        For Each loaiThuoc As LoaiThuocDTO In dgLoaiThuoc.SelectedItems
            result = LoaiThuocBUS.DeleteThuocByMa(loaiThuoc.MaThuoc)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Successful")
        Else
            Domain.Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        If dgLoaiThuoc.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
        End If
        Dim loaiThuoc As New LoaiThuocDTO()
        loaiThuoc.MaThuoc = tbMaThuoc.Text
        loaiThuoc.TenThuoc = tbTenThuoc.Text
        If Not Integer.TryParse(tbDonGia.Text, loaiThuoc.DonGia) Then
            loaiThuoc.DonGia = 0
        End If
        Dim result As Boolean = LoaiThuocBUS.InsertOrUpdateThuoc(loaiThuoc)
        If (result = True) Then
            Domain.Dialog.Show("Successful")
        Else
            Domain.Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        If Not listLoaiThuoc.Count = 0 Then
            If Not listLoaiThuoc.Last.MaThuoc = LoaiThuocBUS.GetMaThuoc() Then
                Dim LoaiThuoc As New LoaiThuocDTO(LoaiThuocBUS.GetMaThuoc(), Nothing)
                listLoaiThuoc.Add(LoaiThuoc)
                dgLoaiThuoc.SelectedIndex = dgLoaiThuoc.Items.Count - 1
            End If
        Else
            Dim LoaiThuoc As New LoaiThuocDTO(LoaiThuocBUS.GetMaThuoc(), Nothing)
            listLoaiThuoc.Add(LoaiThuoc)
            dgLoaiThuoc.SelectedIndex = dgLoaiThuoc.Items.Count - 1
        End If
    End Sub
    Private Sub ReloadData()
        If dgLoaiThuoc IsNot Nothing Then
            listLoaiThuoc = LoaiThuocBUS.GetAllLoaiThuoc()
            dgLoaiThuoc.DataContext = listLoaiThuoc
        End If
    End Sub
End Class
