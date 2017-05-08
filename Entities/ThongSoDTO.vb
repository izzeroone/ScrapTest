Namespace Entities
    Public Module ThongSoDTO
        Private _soBenhNhanKhamToiDa As String

        Public Property SoBenhNhanKhamToiDa As String
            Get
                Return _soBenhNhanKhamToiDa
            End Get
            Set(value As String)
                _soBenhNhanKhamToiDa = value
            End Set
        End Property
    End Module
End Namespace
