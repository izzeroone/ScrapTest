Imports System.Collections.ObjectModel
Imports Business.Business
Imports Entities.Entities
Public Class ucLoaiDonVi
    Private listLoaiDonVi As ObservableCollection(Of LoaiDonViDTO)
    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgLoaiDonVi.SelectedIndex = -1
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        Dim result As Boolean
        For Each loaiDonVi As LoaiDonViDTO In dgLoaiDonVi.SelectedItems
            result = LoaiDonViBUS.DeleteDonViByMa(loaiDonVi.MaDonVi)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Successful")
        Else
            Domain.Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        If dgLoaiDonVi.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
            Return
        End If
        Dim loaiDonVi As New LoaiDonViDTO()
        loaiDonVi.MaDonVi = tbMaDonVi.Text
        loaiDonVi.TenDonVi = tbTenDonVi.Text
        Dim result As Boolean = LoaiDonViBUS.InsertOrUpdateDonVi(loaiDonVi)
        If (result = True) Then
            Domain.Dialog.Show("Successful")
        Else
            Domain.Dialog.Show("False")
        End If
        ReloadData()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        If Not listLoaiDonVi.Count = 0 Then
            If Not listLoaiDonVi.Last.MaDonVi = LoaiDonViBUS.GetMaDonVi() Then
                Dim LoaiDonVi As New LoaiDonViDTO(LoaiDonViBUS.GetMaDonVi(), Nothing)
                listLoaiDonVi.Add(LoaiDonVi)
                dgLoaiDonVi.SelectedIndex = dgLoaiDonVi.Items.Count - 1
            End If
        Else
            Dim LoaiDonVi As New LoaiDonViDTO(LoaiDonViBUS.GetMaDonVi(), Nothing)
            listLoaiDonVi.Add(LoaiDonVi)
            dgLoaiDonVi.SelectedIndex = dgLoaiDonVi.Items.Count - 1
        End If
    End Sub
    Private Sub ReloadData()
        If dgLoaiDonVi IsNot Nothing And Me.IsVisible Then
            listLoaiDonVi = LoaiDonViBUS.GetAllLoaiDonVi()
            dgLoaiDonVi.DataContext = listLoaiDonVi
        End If
    End Sub
End Class
