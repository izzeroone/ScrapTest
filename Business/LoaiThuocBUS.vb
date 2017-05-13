Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module LoaiThuocBUS
#Region "1. Insert & Update"
        Public Function InsertOrUpdateThuoc(ByVal loaiThuoc As LoaiThuocDTO) As Boolean
            Return LoaiThuocDAL.InsertOrUpdateLoaiThuoc(loaiThuoc)
        End Function
#End Region
#Region "2.Delete"
        Public Function DeleteThuocByMa(ByVal maThuoc As String) As Boolean
            Return LoaiThuocDAL.DeleteLoaiThuocByMa(maThuoc)
        End Function
#End Region

#Region "3.Get"
        Public Function GetMaThuoc() As String
            Return LoaiThuocDAL.GetMaThuoc()
        End Function

        Public Function GetAllLoaiThuoc() As ObservableCollection(Of LoaiThuocDTO)
            Dim dt As DataTable = LoaiThuocDAL.GetAllLoaiThuoc()
            Dim list As New ObservableCollection(Of LoaiThuocDTO)
            For Each row As DataRow In dt.Rows
                list.Add(New LoaiThuocDTO(row))
            Next
            Return list
        End Function
#End Region

    End Module
End Namespace