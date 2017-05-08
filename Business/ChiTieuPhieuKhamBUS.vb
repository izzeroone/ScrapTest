Imports System.ComponentModel
Imports System.Data
Imports Entities.Entities
Imports DataAccess.DataAccess
Imports System.Collections.ObjectModel

Namespace Business
    Public Module ChiTietPhieuKhamBUS
#Region "1. Inserting"
        Public Function InsertOrUpdateChiTietPhieuKham(ByVal ChiTietPhieuKham As ChiTietPhieuKhamDTO) As Boolean
            Return ChiTietPhieuKhamDAL.InsertOrUpdateChiTietPhieuKham(ChiTietPhieuKham)
        End Function

#End Region
#Region "3. Delete"
        Public Function DeleteChiTietPhieuKhamByMa(ByVal maChiTietPhieuKham As String) As Boolean
            Return ChiTietPhieuKhamDAL.DeleteChiTietPhieuKhamByMa(maChiTietPhieuKham)
        End Function
#End Region
#Region "4. Get"
        Public Function GetChiTietPhieuKhamByMaNgayKham(ByVal maKhamBenh As String) As ObservableCollection(Of ChiTietPhieuKhamDTO)
            Return ChiTietPhieuKhamDAL.GetChiTietPhieuKhamByMaKhamBenh(maKhamBenh)
        End Function

        Public Function GetMaChiTietPhieuKham() As String
            Return ChiTietPhieuKhamDAL.GetMaChiTietPhieuKham()
        End Function
#End Region

#Region "5.Valild"
        Public Function IsVaildSoLuong(ByVal soLuong As String, ByRef iSoLuong As Integer)
            If (Integer.TryParse(soLuong, iSoLuong)) Then
                If (iSoLuong > 0) Then
                    Return True
                End If
            End If
            Return False
        End Function
#End Region
    End Module
End Namespace

