Namespace Entities
    Public Class ChiTietPhieuKhamDTO
        Private _MaChiTietPhieuKham As String
        Private _MaKhamBenh As String
        Private _TrieuChung As String
        Private _MaLoaiBenh As String
        Private _MaThuoc As String
        Private _MaDonVi As String
        Private _SoLuong As Integer
        Private _MaCachDung As String

        Public Property MaChiTietPhieuKham As String
            Get
                Return _MaChiTietPhieuKham
            End Get
            Set(value As String)
                _MaChiTietPhieuKham = value
            End Set
        End Property

        Public Property MaKhamBenh As String
            Get
                Return _MaKhamBenh
            End Get
            Set(value As String)
                _MaKhamBenh = value
            End Set
        End Property

        Public Property TrieuChung As String
            Get
                Return _TrieuChung
            End Get
            Set(value As String)
                _TrieuChung = value
            End Set
        End Property

        Public Property MaLoaiBenh As String
            Get
                Return _MaLoaiBenh
            End Get
            Set(value As String)
                _MaLoaiBenh = value
            End Set
        End Property

        Public Property MaThuoc As String
            Get
                Return _MaThuoc
            End Get
            Set(value As String)
                _MaThuoc = value
            End Set
        End Property

        Public Property MaDonVi As String
            Get
                Return _MaDonVi
            End Get
            Set(value As String)
                _MaDonVi = value
            End Set
        End Property

        Public Property SoLuong As Integer
            Get
                Return _SoLuong
            End Get
            Set(value As Integer)
                _SoLuong = value
            End Set
        End Property

        Public Property MaCachDung As String
            Get
                Return _MaCachDung
            End Get
            Set(value As String)
                _MaCachDung = value
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Sub New(ByVal MaChiTietPhieuKham As String,
                        ByVal MaKhamBenh As String,
                        ByVal TrieuChung As String,
                        ByVal MaLoaiBenh As String,
                        ByVal MaThuoc As String,
                        ByVal MaDonVi As String,
                       ByVal SoLuong As Integer,
                       ByVal MaCachDung As Integer)
            _MaChiTietPhieuKham = MaChiTietPhieuKham
            _MaKhamBenh = MaKhamBenh
            _TrieuChung = TrieuChung
            _MaLoaiBenh = MaLoaiBenh
            _MaThuoc = MaThuoc
            _MaDonVi = MaDonVi
            _SoLuong = SoLuong
            _MaCachDung = MaCachDung
        End Sub

        Public Sub New(ByVal row As DataRow)
            '_MaChiTietPhieuKham = row.Field(Of String)("MaChiTietPhieuKham")
            '_MaKhamBenh = row.Field(Of String)("MaKhamBenh")
            '_TrieuChung = row.Field(Of String)("TrieuChung")
            '_MaLoaiBenh = row.Field(Of String)("MaLoaiBenh")
            '_MaThuoc = row.Field(Of String)("MaThuoc")
            '_MaDonVi = row.Field(Of String)("MaDonVi")
            '_SoLuong = row.Field(Of Integer)("SoLuong")
            '_MaCachDung = row.Field(Of String)("MaCachDung")
            _MaChiTietPhieuKham = row.Field(Of String)("machitietphieukham")
            _MaKhamBenh = row.Field(Of String)("makhambenh")
            _TrieuChung = row.Field(Of String)("trieuchung")
            _MaLoaiBenh = row.Field(Of String)("maloaibenh")
            _MaThuoc = row.Field(Of String)("mathuoc")
            _MaDonVi = row.Field(Of String)("madonvi")
            _SoLuong = row.Field(Of Integer)("soluong")
            _MaCachDung = row.Field(Of String)("macachdung")
        End Sub
    End Class
End Namespace