Namespace Entities
    Public Class HoaDonDTO
        Private _maHoaDon As String
        Private _maKhamBenh As String
        Private _tienKham As Integer

        Public Property MaHoaDon As String
            Get
                Return _maHoaDon
            End Get
            Set(value As String)
                _maHoaDon = value
            End Set
        End Property

        Public Property MaKhamBenh As String
            Get
                Return _maKhamBenh
            End Get
            Set(value As String)
                _maKhamBenh = value
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

        Public Sub New()

        End Sub

        Public Sub New(ByVal row As DataRow)
            MaHoaDon = row.Field(Of String)("mahoadon")
            MaKhamBenh = row.Field(Of String)("makhambenh")
            TienKham = row.Field(Of Decimal)("tienkham")
        End Sub
    End Class
End Namespace