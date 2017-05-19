Imports System.Collections.ObjectModel
Imports Entities.Entities
Imports DataAccess.DataAccess
Namespace DataAccess
    Public Module ChiTietHoaDonBUS
#Region "Insert or update"
        Public Function InsertChiTietHoaDon(ByVal chiTietHoaDon As ChiTietHoaDonDTO) As Boolean
            Return ChiTietHoaDonDAL.InsertChiTietHoaDon(chiTietHoaDon)
        End Function
#End Region
#Region "Get"
        Public Function GetAllChiTietHoaDon(ByVal maHoaDon) As ObservableCollection(Of ChiTietHoaDonDTO)
            Dim list As New ObservableCollection(Of ChiTietHoaDonDTO)
            Dim tb As DataTable = ChiTietHoaDonDAL.GetAllChiTietHoaDon(maHoaDon)
            For Each row As DataRow In tb.Rows
                list.Add(New ChiTietHoaDonDTO(row))
            Next
            Return list
        End Function
#End Region
#Region "Delete"
        Public Function DeleteAllChiTietHoaDon(ByVal maHoaDon) As Boolean
            Return ChiTietHoaDonDAL.DeleteAllChiTietHoaDon(maHoaDon)
        End Function
#End Region
    End Module
End Namespace

