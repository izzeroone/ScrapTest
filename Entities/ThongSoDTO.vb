Namespace Entities
    ''' <summary>
    ''' Module lưu thông số của chương trình
    ''' </summary>
    Public Module ThongSoDTO
        Private _soBenhNhanKhamToiDa As Integer
        Private _tienKham As Integer

        Public Property SoBenhNhanKhamToiDa As Integer
            Get
                Return _soBenhNhanKhamToiDa
            End Get
            Set(value As Integer)
                _soBenhNhanKhamToiDa = value
            End Set
        End Property

        Public Property TienKham As Integer
            Get
                Return _tienKham
            End Get
            Set(value As Integer)
                _tienKham = value
            End Set
        End Property
    End Module
End Namespace
