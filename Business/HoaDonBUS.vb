
Imports Entities.Entities
Imports DataAccess.DataAccess
Namespace DataAccess
    Module HoaDonBUS
#Region "Insert"
        Public Function InsertOrUpdateHoaDon(ByVal hoaDon As HoaDonDTO) As Boolean
            Return HoaDonDAL.InsertOrUpdateHoaDon(hoaDon)
        End Function
#End Region
#Region "Check"
        Public Function IsHoaDonPay(ByVal maKhamBenh) As Boolean
            Return HoaDonDAL.IsHoaDonPay(maKhamBenh)
        End Function
#End Region
#Region "Get"
        Public Function GetMaHoaDon()
            Return HoaDonDAL.GetMaHoaDon()
        End Function

        Public Function GetHoaDon(ByVal maKhamBenh) As HoaDonDTO
            Dim tb As DataTable = HoaDonDAL.GetHoaDon(maKhamBenh)
            Return New HoaDonDTO(tb.Rows.Item(0))
        End Function
#End Region
#Region "Delete"
        Public Function DeleteHoaDon(ByVal maKhamBenh As String) As Boolean

            Return HoaDonDAL.DeleteHoaDon(maKhamBenh)
        End Function
#End Region

    End Module
End Namespace

