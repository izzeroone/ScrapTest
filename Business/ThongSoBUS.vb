Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module ThongSoBUS
        'Thông số mặc định
        Private ReadOnly defaultSoBenhNhan = 40
        Private ReadOnly defaultTienKham = 30000
        ''' <summary>
        ''' Lấy thông số từ cơ sở dữ liệu
        ''' </summary>
        Public Sub LoadThongSo()
            If Not Int32.TryParse(ThongSoDAL.GetThongSo("sobenhnhantoida"), ThongSoDTO.SoBenhNhanKhamToiDa) Then
                ThongSoDTO.SoBenhNhanKhamToiDa = 40
            End If
            If Not Int32.TryParse(ThongSoDAL.GetThongSo("tienkham"), ThongSoDTO.TienKham) Then
                ThongSoDTO.TienKham = 30000
            End If
        End Sub
        ''' <summary>
        ''' Cập nhật thông số số bệnh nhân tối đa
        ''' </summary>
        ''' <param name="giaTri"></param>
        ''' <returns></returns>
        Public Function UpdateSoBenhNhanToiDa(ByVal giaTri As Integer) As Boolean
            ThongSoDTO.SoBenhNhanKhamToiDa = giaTri
            Return ThongSoDAL.UpdateThongSo("sobenhnhantoida", giaTri.ToString())
        End Function
        ''' <summary>
        ''' Cập nhật thông số tiền khám
        ''' </summary>
        ''' <param name="tienKham"></param>
        ''' <returns></returns>
        Public Function UpdateTienKham(ByVal tienKham As Integer) As Boolean
            ThongSoDTO.TienKham = tienKham
            Return ThongSoDAL.UpdateThongSo("tienkham", tienKham.ToString())
        End Function
        ''' <summary>
        ''' Đặt các thông số về giá trị mặc định
        ''' </summary>
        Public Sub SetDefaultValue()
            UpdateSoBenhNhanToiDa(defaultSoBenhNhan)
            UpdateTienKham(defaultTienKham)
        End Sub
    End Module
End Namespace
