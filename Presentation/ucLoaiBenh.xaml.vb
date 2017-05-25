Imports System.Collections.ObjectModel
Imports Business.Business
Imports Entities.Entities
Public Class ucLoaiBenh
    Private listLoaiBenh As ObservableCollection(Of LoaiBenhDTO)
    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgLoaiBenh.SelectedIndex = -1
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        Dim result As Boolean
        For Each loaiBenh As LoaiBenhDTO In dgLoaiBenh.SelectedItems
            result = LoaiBenhBUS.DeleteLoaiBenhByMa(loaiBenh.MaLoaiBenh)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Successful")
        Else
            Domain.Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        If dgLoaiBenh.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
            Return
        End If
        Dim loaiBenh As New LoaiBenhDTO()
        loaiBenh.MaLoaiBenh = tbMaLoaiBenh.Text
        loaiBenh.TenLoaiBenh = tbTenLoaiBenh.Text
        Dim result As Boolean = LoaiBenhBUS.InsertOrUpdateLoaiBenh(loaiBenh)
        If (result = True) Then
            Domain.Dialog.Show("Successful")
        Else
            Domain.Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)

        If Not listLoaiBenh.Count = 0 Then
            If Not listLoaiBenh.Last.MaLoaiBenh = LoaiBenhBUS.GetMaLoaiBenh() Then
                Dim loaiBenh As New LoaiBenhDTO(LoaiBenhBUS.GetMaLoaiBenh(), Nothing)
                listLoaiBenh.Add(loaiBenh)
                dgLoaiBenh.SelectedIndex = dgLoaiBenh.Items.Count - 1
            End If
        Else
            Dim loaiBenh As New LoaiBenhDTO(LoaiBenhBUS.GetMaLoaiBenh(), Nothing)
            listLoaiBenh.Add(loaiBenh)
            dgLoaiBenh.SelectedIndex = dgLoaiBenh.Items.Count - 1
        End If
    End Sub
    Private Sub ReloadData()
        If dgLoaiBenh IsNot Nothing And Me.IsVisible Then
            listLoaiBenh = LoaiBenhBUS.GetAllLoaiBenh()
            dgLoaiBenh.DataContext = listLoaiBenh
        End If
    End Sub
End Class
