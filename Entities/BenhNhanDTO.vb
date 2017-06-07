Namespace Entities
    Public Class BenhNhanDTO
        Private _hoTen As String
        Private _ngayKham As Date
        Private _trieuChung As String
        Private _maLoaiBenh As String
        Private _tenLoaiBenh As String

        Public Property HoTen As String
            Get
                Return _hoTen
            End Get
            Set(value As String)
                _hoTen = value
            End Set
        End Property

        Public Property NgayKham As Date
            Get
                Return _ngayKham
            End Get
            Set(value As Date)
                _ngayKham = value
            End Set
        End Property

        Public Property TrieuChung As String
            Get
                Return _trieuChung
            End Get
            Set(value As String)
                _trieuChung = value
            End Set
        End Property

        Public Property MaLoaiBenh As String
            Get
                Return _maLoaiBenh
            End Get
            Set(value As String)
                _maLoaiBenh = value
            End Set
        End Property

        Public Property TenLoaiBenh As String
            Get
                Return _tenLoaiBenh
            End Get
            Set(value As String)
                _tenLoaiBenh = value
            End Set
        End Property

        Public Sub New()

        End Sub

        ''' <summary>
        ''' Lấy dữ liệu từ datarow
        ''' </summary>
        ''' <param name="row"></param>
        Public Sub New(ByVal row As DataRow)
            _hoTen = row.Field(Of String)("hotenbenhnhan")
            _ngayKham = row.Field(Of Date)("ngaykham")
            _trieuChung = row.Field(Of String)("trieuchung")
            _maLoaiBenh = row.Field(Of String)("maloaibenh")
            _tenLoaiBenh = row.Field(Of String)("tenloaibenh")
        End Sub
    End Class
End Namespace
