Imports Entities.Entities
Imports DataAccess.DataAccess
Imports System.Collections.ObjectModel
Namespace Business
    Public Module BaoCaoThuocBUS
#Region "For get only"
        ''' <summary>
        ''' Tính báo cáo thuốc của mỗi ngày trong tháng
        ''' </summary>
        ''' <param name="thang"></param>
        ''' <returns></returns>
        Public Function GetBaoCaoThuoc(ByVal thang As Date) As ObservableCollection(Of BaoCaoThuocDTO)
            Dim list As New ObservableCollection(Of BaoCaoThuocDTO)
            'Lấy bảng dữ liệu
            Dim tb As DataTable = BaoCaoThuocDAL.GetBaoCaoThuoc(thang)
            'Thêm dữ liệu trong bảng vào báo cáo
            For Each row As DataRow In tb.Rows
                list.Add(New BaoCaoThuocDTO(row))
            Next
            Return list
        End Function
#End Region
    End Module
End Namespace
