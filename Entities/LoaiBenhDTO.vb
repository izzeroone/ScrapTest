Namespace Entities
    Public Class LoaiBenhDTO
        Private _MaLoaiBenh As String
        Private _TenLoaiBenh As String

        Public Property MaLoaiBenh As String
            Get
                Return _MaLoaiBenh
            End Get
            Set(value As String)
                _MaLoaiBenh = value
            End Set
        End Property
        Public Property TenLoaiBenh As String
            Get
                Return _TenLoaiBenh
            End Get
            Set(value As String)
                _TenLoaiBenh = value
            End Set
        End Property
        Public Sub New()

        End Sub

        Public Sub New(ByVal MaLoaiBenh As String, ByVal TenLoaiBenh As String)
            _MaLoaiBenh = MaLoaiBenh
            _TenLoaiBenh = TenLoaiBenh
        End Sub

        Public Sub New(ByVal row As DataRow)
            _MaLoaiBenh = row.Field(Of String)("maloaibenh")
            _TenLoaiBenh = row.Field(Of String)("tenloaibenh")
        End Sub
    End Class
End Namespace

