Imports System.Collections.ObjectModel
Imports Entities.Entities
Imports DataAccess.DataAccess
Namespace Business
    Public Module HoaDonBUS
#Region "Insert"
        Public Function InsertOrUpdateHoaDon(ByVal hoaDon As HoaDonDTO) As Boolean
            Return HoaDonDAL.InsertOrUpdateHoaDon(hoaDon)
        End Function
#End Region
#Region "Check"
        Public Function IsHoaDonPay(ByVal maKhamBenh) As Boolean
            Dim result As Boolean
            Try
                Boolean.TryParse(HoaDonDAL.IsHoaDonPay(maKhamBenh), result)
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
#End Region
#Region "Get"
        Public Function GetMaHoaDon()
            Return HoaDonDAL.GetMaHoaDon()
        End Function

        Public Function GetHoaDon(ByVal maKhamBenh As String) As HoaDonDTO
            Dim tb As DataTable = HoaDonDAL.GetHoaDon(maKhamBenh)
            Return New HoaDonDTO(tb.Rows.Item(0))
        End Function
#End Region
#Region "Delete"
        Public Function DeleteHoaDon(ByVal maKhamBenh As String) As Boolean
            Dim hoaDon As HoaDonDTO = GetHoaDon(maKhamBenh)
            ChiTietHoaDonBUS.DeleteAllChiTietHoaDon(hoaDon.MaHoaDon)
            Return HoaDonDAL.DeleteHoaDon(maKhamBenh)
        End Function
#End Region
#Region "Calculator"
        Public Function CalcTienThuoc(ByVal list As ObservableCollection(Of ChiTietHoaDonDTO)) As Integer
            Dim tienThuoc As Integer = 0
            For Each chiTietHoaDon As ChiTietHoaDonDTO In list
                tienThuoc += chiTietHoaDon.SoLuong * chiTietHoaDon.DonGia
            Next
            Return tienThuoc
        End Function
#End Region

    End Module
End Namespace

