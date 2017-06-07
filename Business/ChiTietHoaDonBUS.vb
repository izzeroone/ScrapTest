Imports System.Collections.ObjectModel
Imports Entities.Entities
Imports DataAccess.DataAccess
Namespace Business
    Public Module ChiTietHoaDonBUS
#Region "Insert or update"
        ''' <summary>
        ''' Thêm chi tiết hóa đơn (thuốc sử dụng) vào cở sở lữ liệu
        ''' </summary>
        ''' <param name="chiTietHoaDon"></param>
        ''' <returns></returns>
        Public Function InsertChiTietHoaDon(ByVal chiTietHoaDon As ChiTietHoaDonDTO) As Boolean
            Return ChiTietHoaDonDAL.InsertChiTietHoaDon(chiTietHoaDon)
        End Function
#End Region
#Region "Get"
        ''' <summary>
        ''' Lấy tất cả chi tiết hóa đơn (thuốc sử dụng) của mã khám bệnh tương ứng
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetAllChiTietHoaDon(ByVal maKhamBenh) As ObservableCollection(Of ChiTietHoaDonDTO)
            Dim list As New ObservableCollection(Of ChiTietHoaDonDTO)
            'Lấy bảng từ cơ sở dữ liệu
            Dim tb As DataTable = ChiTietHoaDonDAL.GetAllChiTietHoaDon(maKhamBenh)
            'Thêm chi tiết hóa đơn vào danh sách
            For Each row As DataRow In tb.Rows
                list.Add(New ChiTietHoaDonDTO(row))
            Next
            Return list
        End Function
#End Region
#Region "Delete"
        ''' <summary>
        ''' Xóa tất cả chi tiết hóa đơn (thuốc sử dụng) của mã khám bệnh tương ứng
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function DeleteAllChiTietHoaDon(ByVal maKhamBenh) As Boolean
            Return ChiTietHoaDonDAL.DeleteAllChiTietHoaDon(maKhamBenh)
        End Function
#End Region
    End Module
End Namespace

