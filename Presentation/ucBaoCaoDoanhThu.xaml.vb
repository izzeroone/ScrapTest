﻿Imports Entities.Entities
Imports Business.Business
Imports System.Collections.ObjectModel
Public Class ucBaoCaoDoanhThu
    Dim list As ObservableCollection(Of BaoCaoDoanhThuDTO)
    Private Sub tbNgayKham_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim tong As Long
        list = BaoCaoDoanhThuBUS.GetBaoCaoDoanhThu(tbNgayKham.SelectedDate, tong)
        If dgChiTietDoanhThu IsNot Nothing Then
            If (list.Count <> 0) Then
                dgChiTietDoanhThu.ItemsSource = list
            Else
                dgChiTietDoanhThu.ItemsSource = New ObservableCollection(Of BaoCaoDoanhThuDTO)
            End If
        End If
    End Sub
End Class