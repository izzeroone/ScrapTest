Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module LoaiDonViBUS
#Region "1. Insert & Update"
        Public Function InsertOrUpdateDonVi(ByVal loaiDonVi As LoaiDonViDTO) As Boolean
            Return LoaiDonViDAL.InsertOrUpdateLoaiDonVi(loaiDonVi)
        End Function
#End Region
#Region "2.Delete"
        Public Function DeleteDonViByMa(ByVal maDonVi As String) As Boolean
            Return LoaiDonViDAL.DeleteLoaiDonViByMa(maDonVi)
        End Function
#End Region

#Region "3.Get"
        Public Function GetMaDonVi() As String
            Return LoaiDonViDAL.GetMaDonVi()
        End Function

        Public Function GetAllLoaiDonVi() As ObservableCollection(Of LoaiDonViDTO)
            Return LoaiDonViDAL.GetAllLoaiDonVi()
        End Function
#End Region

    End Module
End Namespace