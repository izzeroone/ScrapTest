Imports System.Collections.ObjectModel
Imports Entities.Entities
Imports DataAccess.DataAccess
Namespace Business
    Public Module BaoCaoDoanhThuBUS
#Region "For get only"
        Public Function GetBaoCaoDoanhThu(ByVal month As Date, ByRef tong As Long) As ObservableCollection(Of BaoCaoDoanhThuDTO)
            Dim list As New ObservableCollection(Of BaoCaoDoanhThuDTO)
            Dim tb As DataTable = BaoCaoDoanhThuDAL.getBaoCaoDoanhThu(month)
            tong = 0
            For Each row As DataRow In tb.Rows
                list.Add(New BaoCaoDoanhThuDTO(row))
                tong += row.Field(Of Decimal)("doanhthu")
            Next

            For Each baoCao As BaoCaoDoanhThuDTO In list
                baoCao.TiLe = 1.0 * baoCao.DoanhThu / tong
            Next

            Return list
        End Function
#End Region
    End Module
End Namespace
