Imports System.ComponentModel
Imports System.Data
Imports Entities.Entities
Imports DataAccess.DataAccess
Namespace Business
    Public Module KhamBenhBUS
#Region "1. Inserting"
        Public Function InsertKhamBenh(ByVal khamBenh As KhamBenhDTO) As Boolean
            Return KhamBenhDAL.insertKhamBenh(khamBenh)
        End Function

        Public Function InsertOrUpdateKhamBenh(ByVal khamBenh As KhamBenhDTO) As Boolean
            Return KhamBenhDAL.insertOrUpdateKhamBenh(khamBenh)
        End Function

#End Region
#Region "3. Delete"
        Public Function DeleteKhamBenhById(ByVal maKhamBenh As String) As Boolean
            Return KhamBenhDAL.DeleteKhamBenhById(maKhamBenh)
        End Function
#End Region
#Region "4. Get"
        Public Function GetKhamBenhByDate(ByVal ngayKham As Date) As BindingList(Of KhamBenhDTO)
            Return KhamBenhDAL.GetKhamBenhByDate(ngayKham)
        End Function

        Public Function GetMaKhamBenh() As String
            Return KhamBenhDAL.GetMaKhamBenh()
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

