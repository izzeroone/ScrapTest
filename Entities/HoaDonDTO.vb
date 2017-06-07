Namespace Entities
    Public Class HoaDonDTO
        Private _maKhamBenh As String
        Private _tienKhamThucTe As Integer


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
                Return _tienKhamThucTe
            End Get
            Set(value As Integer)
                _tienKhamThucTe = value
            End Set
        End Property

        Public Sub New()

        End Sub

        ''' <summary>
        ''' Lấy dữ liệu từ datarow
        ''' </summary>
        ''' <param name="row"></param>
        Public Sub New(ByVal row As DataRow)
            MaKhamBenh = row.Field(Of String)("makhambenh")
            TienKham = row.Field(Of Decimal)("tienkhamthucte")
        End Sub
    End Class
End Namespace