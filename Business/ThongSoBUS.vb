Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module ThongSoBUS
        Private ReadOnly defaultSoBenhNhan = 40
        Private ReadOnly defaultTienKham = 30000
        Public Sub LoadThongSo()
            If Not Int32.TryParse(ThongSoDAL.GetThongSo("sobenhnhantoida"), ThongSoDTO.SoBenhNhanKhamToiDa) Then
                ThongSoDTO.SoBenhNhanKhamToiDa = 40
            End If
            If Not Int32.TryParse(ThongSoDAL.GetThongSo("tienkham"), ThongSoDTO.TienKham) Then
                ThongSoDTO.TienKham = 30000
            End If
        End Sub

        Public Function UpdateSoBenhNhanToiDa(ByVal giaTri As Integer) As Boolean
            Return ThongSoDAL.UpdateThongSo("sobenhnhantoida", giaTri.ToString())
        End Function

        Public Function UpdateTienKham(ByVal tienKham As Integer) As Boolean
            Return ThongSoDAL.UpdateThongSo("tienkham", tienKham.ToString())
        End Function

        Public Sub DefaultValue()
            UpdateSoBenhNhanToiDa(defaultSoBenhNhan)
            UpdateTienKham(defaultTienKham)
        End Sub
    End Module
End Namespace
