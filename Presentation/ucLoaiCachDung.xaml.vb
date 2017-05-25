Imports System.Collections.ObjectModel
Imports Business.Business
Imports Entities.Entities
Public Class ucLoaiCachDung
    Private listLoaiCachDung As ObservableCollection(Of LoaiCachDungDTO)
    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgLoaiCachDung.SelectedIndex = -1
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        Dim result As Boolean
        For Each loaiCachDung As LoaiCachDungDTO In dgLoaiCachDung.SelectedItems
            result = LoaiCachDungBUS.DeleteCachDungByMa(loaiCachDung.MaCachDung)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Successful")
        Else
            Domain.Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        If dgLoaiCachDung.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
            Return
        End If
        Dim loaiCachDung As New LoaiCachDungDTO()
        loaiCachDung.MaCachDung = tbMaCachDung.Text
        loaiCachDung.TenCachDung = tbTenCachDung.Text
        Dim result As Boolean = LoaiCachDungBUS.InsertOrUpdateCachDung(loaiCachDung)
        If (result = True) Then
            Domain.Dialog.Show("Successful")
        Else
            Domain.Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        If Not listLoaiCachDung.Count = 0 Then
            If Not listLoaiCachDung.Last.MaCachDung = LoaiCachDungBUS.GetMaCachDung() Then
                Dim LoaiCachDung As New LoaiCachDungDTO(LoaiCachDungBUS.GetMaCachDung(), Nothing)
                listLoaiCachDung.Add(LoaiCachDung)
                dgLoaiCachDung.SelectedIndex = dgLoaiCachDung.Items.Count - 1
            End If
        Else
            Dim LoaiCachDung As New LoaiCachDungDTO(LoaiCachDungBUS.GetMaCachDung(), Nothing)
            listLoaiCachDung.Add(LoaiCachDung)
            dgLoaiCachDung.SelectedIndex = dgLoaiCachDung.Items.Count - 1
        End If
    End Sub
    Private Sub ReloadData()
        If dgLoaiCachDung IsNot Nothing And Me.IsVisible Then
            listLoaiCachDung = LoaiCachDungBUS.GetAllLoaiCachDung()
            dgLoaiCachDung.DataContext = listLoaiCachDung
        End If
    End Sub
End Class
