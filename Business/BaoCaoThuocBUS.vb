Imports Entities.Entities
Imports DataAccess.DataAccess
Imports System.Collections.ObjectModel
Namespace Business
    Public Module BaoCaoThuocBUS
#Region "For get only"
        Public Function GetBaoCaoThuoc(ByVal thang As Date) As ObservableCollection(Of BaoCaoThuocDTO)
            Dim list As New ObservableCollection(Of BaoCaoThuocDTO)
            Dim tb As DataTable = BaoCaoThuocDAL.GetBaoCaoThuoc(thang)
            For Each row As DataRow In tb.Rows
                list.Add(New BaoCaoThuocDTO(row))
            Next
            Return list
        End Function
#End Region
    End Module
End Namespace
