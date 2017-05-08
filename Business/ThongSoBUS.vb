Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module ThongSoBUS
        Public Sub LoadThongSo()
            If Not Int32.TryParse(ThongSoDAL.GetThongSo("sobenhnhantoida"), ThongSoDTO.SoBenhNhanKhamToiDa) Then
                ThongSoDTO.SoBenhNhanKhamToiDa = 40
            End If
        End Sub

        Public Function UpdateSoBenhNhanToiDa(ByVal giaTri As Integer) As Boolean
            Return ThongSoDAL.UpdateThongSo("sobenhnhantoida", giaTri.ToString())
        End Function
    End Module
End Namespace
