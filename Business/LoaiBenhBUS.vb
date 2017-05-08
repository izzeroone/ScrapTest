Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module LoaiBenhBUS
#Region "1. Insert & Update"
        Public Function InsertOrUpdateLoaiBenh(ByVal loaiBenh As LoaiBenhDTO) As Boolean
            Return LoaiBenhDAL.InsertOrUpdateLoaiBenh(loaiBenh)
        End Function
#End Region
#Region "2.Delete"
        Public Function DeleteLoaiBenhByMa(ByVal maLoaiBenh As String) As Boolean
            Return LoaiBenhDAL.DeleteLoaiBenhByMa(maLoaiBenh)
        End Function
#End Region

#Region "3.Get"
        Public Function GetMaLoaiBenh() As String
            Return LoaiBenhDAL.GetMaLoaiBenh()
        End Function

        Public Function GetAllLoaiBenh() As ObservableCollection(Of LoaiBenhDTO)
            Return LoaiBenhDAL.GetAllLoaiBenh()
        End Function
#End Region

    End Module
End Namespace