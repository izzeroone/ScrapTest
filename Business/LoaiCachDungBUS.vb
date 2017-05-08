Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module LoaiCachDungBUS
#Region "1. Insert & Update"
        Public Function InsertOrUpdateCachDung(ByVal loaiCachDung As LoaiCachDungDTO) As Boolean
            Return LoaiCachDungDAL.InsertOrUpdateLoaiCachDung(loaiCachDung)
        End Function
#End Region
#Region "2.Delete"
        Public Function DeleteCachDungByMa(ByVal maCachDung As String) As Boolean
            Return LoaiCachDungDAL.DeleteLoaiCachDungByMa(maCachDung)
        End Function
#End Region

#Region "3.Get"
        Public Function GetMaCachDung() As String
            Return LoaiCachDungDAL.GetMaCachDung()
        End Function

        Public Function GetAllLoaiCachDung() As ObservableCollection(Of LoaiCachDungDTO)
            Return LoaiCachDungDAL.GetAllLoaiCachDung()
        End Function
#End Region

    End Module
End Namespace