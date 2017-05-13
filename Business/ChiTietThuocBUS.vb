Imports DataAccess.DataAccess
Imports Entities.Entities
Imports System.Collections.ObjectModel
Namespace Business
    Public Module ChiTietThuocBUS
#Region "1.get"
        Public Function GetChiTietThuoc(ByVal maKhamBenh As String) As ObservableCollection(Of ChiTietThuocDTO)
            Dim dt As DataTable = ChiTietThuocDAL.GetChiTietThuoc(maKhamBenh)
            Dim list As New ObservableCollection(Of ChiTietThuocDTO)
            For Each row As DataRow In dt.Rows
                list.Add(New ChiTietThuocDTO(row))
            Next
            Return list
        End Function
#End Region
    End Module
End Namespace
