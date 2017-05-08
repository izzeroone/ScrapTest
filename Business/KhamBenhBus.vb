Imports System.ComponentModel
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
        Public Function GetKhamBenhByNgayKham(ByVal ngayKham As Date) As BindingList(Of KhamBenhDTO)
            Return KhamBenhDAL.GetKhamBenhByNgayKham(ngayKham)
        End Function

        Public Function GetMaKhamBenh() As String
            Return KhamBenhDAL.GetMaKhamBenh()
        End Function

        Public Function GetAllMaKhamBenh() As ObservableCollection(Of String)
            Return KhamBenhDAL.GetAllMaKhamBenh()
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
#End Region
    End Module
End Namespace

