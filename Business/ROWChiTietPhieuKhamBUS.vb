Imports System.Collections.ObjectModel
Imports Entities.Entities
Imports DataAccess.DataAccess
Namespace Business
    Public Module ROWChiTietPhieuKhamBUS
#Region "For get only"
        Public Function GetChiTietPhieuKhamByMaKhamBenh(ByVal maKhamBenh As String) As ObservableCollection(Of ROWChiTietPhieuKhamDTO)
            Return ROWChiTietPhieuKhamDAL.GetChiTietPhieuKhamByMaKhamBenh(maKhamBenh)
        End Function
#End Region
    End Module
End Namespace
