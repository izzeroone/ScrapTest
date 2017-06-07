Imports System.Collections.ObjectModel
Imports Entities.Entities
Imports DataAccess.DataAccess
Namespace Business
    ''' <summary>
    ''' Module dùng trong hiển thị danh sách chi tiết phiếu khám với tên thuốc,
    ''' tên đơn vị, tên cách dùng, tên loại bệnh thay vì mã tương ứng để người
    ''' dùng dễ nhận biết hơn
    ''' </summary>
    Public Module ROWChiTietPhieuKhamBUS
#Region "For get only"
        ''' <summary>
        ''' Lấy danh sách hiển thị chi tiết phiếu khám
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetChiTietPhieuKhamByMaKhamBenh(ByVal maKhamBenh As String) As ObservableCollection(Of ROWChiTietPhieuKhamDTO)
            Dim list As New ObservableCollection(Of ROWChiTietPhieuKhamDTO)
            'Lấy bảng dữ liệu
            Dim dt As DataTable = ROWChiTietPhieuKhamDAL.GetChiTietPhieuKhamByMaKhamBenh(maKhamBenh)
            'Thêm từng hàng trong dòng dữ liệu vào danh sách
            For Each row As DataRow In dt.Rows
                list.Add(New ROWChiTietPhieuKhamDTO(row))
            Next

            Return list
        End Function
#End Region
    End Module
End Namespace
