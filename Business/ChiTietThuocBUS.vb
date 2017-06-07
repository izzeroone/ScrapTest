Imports DataAccess.DataAccess
Imports Entities.Entities
Imports System.Collections.ObjectModel
Namespace Business
    Public Module ChiTietThuocBUS
#Region "1.get"
        ''' <summary>
        ''' Lấy chi tiết thuốc đã sử dụng
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetChiTietThuoc(ByVal maKhamBenh As String) As ObservableCollection(Of ChiTietThuocDTO)
            'Lấy bảng chi tiết thuốc từ cơ sở dữ liệu
            Dim dt As DataTable = ChiTietThuocDAL.GetChiTietThuoc(maKhamBenh)
            Dim list As New ObservableCollection(Of ChiTietThuocDTO)
            'Thêm dữ liệu vào danh sách
            For Each row As DataRow In dt.Rows
                list.Add(New ChiTietThuocDTO(row))
            Next
            Return list
        End Function
#End Region
    End Module
End Namespace
