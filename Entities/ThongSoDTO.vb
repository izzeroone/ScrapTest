Namespace Entities
    Public Module ThongSoDTO
        Private _soBenhNhanKhamToiDa As String
        Private _tienKham As Integer

        Public Property SoBenhNhanKhamToiDa As String
            Get
                Return _soBenhNhanKhamToiDa
            End Get
            Set(value As String)
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
