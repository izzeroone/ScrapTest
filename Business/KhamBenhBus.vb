﻿Imports System.ComponentModel
Imports System.Data
Imports Entities.Entities
Imports DataAccess.DataAccess
Imports System.Collections.ObjectModel

Namespace Business
    Public Module KhamBenhBUS
#Region "1. Inserting"
        Public Function InsertOrUpdateKhamBenh(ByVal khamBenh As KhamBenhDTO) As Boolean
            Return KhamBenhDAL.InsertOrUpdateKhamBenh(khamBenh)
        End Function

#End Region
#Region "3. Delete"
        Public Function DeleteKhamBenhByMa(ByVal maKhamBenh As String) As Boolean
            Return KhamBenhDAL.DeleteKhamBenhByMa(maKhamBenh)
        End Function
#End Region
#Region "4. Get"
        Public Function GetKhamBenhByNgayKham(ByVal ngayKham As Date) As ObservableCollection(Of KhamBenhDTO)
            Dim list As New ObservableCollection(Of KhamBenhDTO)
            Dim tb As DataTable = KhamBenhDAL.GetKhamBenhByNgayKham(ngayKham)
            Dim khamBenh As KhamBenhDTO
            For Each row As DataRow In tb.Rows
                khamBenh = New KhamBenhDTO(row)
                khamBenh.GetAdditionData(row)
                khamBenh.TinhTrang = GetTinhTrangKhamBenh(khamBenh.MaKhamBenh)
                list.Add(khamBenh)
            Next
            Return list

        End Function

        Public Function GetMaKhamBenh() As String
            Return KhamBenhDAL.GetMaKhamBenh()
        End Function

        Public Function GetAllMaKhamBenh() As ObservableCollection(Of String)
            Return KhamBenhDAL.GetAllMaKhamBenh()
        End Function

        Public Function GetAllKhamBenh() As ObservableCollection(Of KhamBenhDTO)
            Return KhamBenhDAL.GetAllKhamBenh()
        End Function

        Public Function GetKhamBenhByMaKhamBenh(ByVal maKhamBenh As String) As KhamBenhDTO
            Return KhamBenhDAL.GetKhamBenhByMaKhamBenh(maKhamBenh)
        End Function

        Public Function GetTinhTrangKhamBenh(ByVal maKhamBenh As String) As String
            Dim i As Integer = Integer.Parse(KhamBenhDAL.GetTinhTrangKhamBenh(maKhamBenh))
            Select Case i
                Case 0
                    Return "Chưa khám"
                Case 1
                    Return "Đã khám, chưa thanh toán"
                Case 2
                    Return "Đã khám, đã thanh toán"
                Case Else
                    Return "Không biết"
            End Select
        End Function
#End Region

#Region "5.Valild"
        Public Function IsVaildNamSinh(ByVal namSinh As String, ByRef iNamSinh As Integer)
            If (Integer.TryParse(namSinh, iNamSinh)) Then
                If (iNamSinh > 0) Then
                    Return True
                End If
            End If
            Return False
        End Function

        Public Function IsKhamBenhInsertable(ByVal khamBenh As KhamBenhDTO) As Boolean
            Dim result As Boolean
            Try
                Boolean.TryParse(KhamBenhDAL.IsKhamBenhInsertable(khamBenh).ToString(), result)
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
#End Region
    End Module
End Namespace

