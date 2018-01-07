Namespace Entities
    Public Class ChiTietPhieuKhamDTO
        Private _MaChiTietPhieuKham As String
        Private _MaKhamBenh As String
        Private _TrieuChung As String
        Private _MaLoaiBenh As String
        Private _TenLoaiBenh As String
        Private _MaThuoc As String
        Private _TenThuoc As String
        Private _MaDonVi As String
        Private _TenDonVi As String
        Private _SoLuong As Integer
        Private _MaCachDung As String
        Private _TenCachDung As String
        Private _LoiDan As String

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

        Public Property TenLoaiBenh As String
            Get
                Return _TenLoaiBenh
            End Get
            Set(value As String)
                _TenLoaiBenh = value
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

        Public Property TenThuoc As String
            Get
                Return _TenThuoc
            End Get
            Set(value As String)
                _TenThuoc = value
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

        Public Property TenDonVi As String
            Get
                Return _TenDonVi
            End Get
            Set(value As String)
                _TenDonVi = value
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

        Public Property TenCachDung As String
            Get
                Return _TenCachDung
            End Get
            Set(value As String)
                _TenCachDung = value
            End Set
        End Property

        Public Property LoiDan As String
            Get
                Return _LoiDan
            End Get
            Set(value As String)
                _LoiDan = value
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
            Me.MaChiTietPhieuKham = MaChiTietPhieuKham
            Me.MaKhamBenh = MaKhamBenh
            Me.TrieuChung = TrieuChung
            Me.MaLoaiBenh = MaLoaiBenh
            Me.MaThuoc = MaThuoc
            Me.MaDonVi = MaDonVi
            Me.SoLuong = SoLuong
            Me.MaCachDung = MaCachDung
        End Sub

        Public Sub New(ByVal MaChiTietPhieuKham As String,
                        ByVal MaKhamBenh As String,
                        ByVal TrieuChung As String,
                        ByVal MaLoaiBenh As String,
                       ByVal LoiDan As String,
                        ByVal MaThuoc As String,
                        ByVal MaDonVi As String,
                       ByVal SoLuong As Integer,
                       ByVal MaCachDung As Integer)
            Me.MaChiTietPhieuKham = MaChiTietPhieuKham
            Me.MaKhamBenh = MaKhamBenh
            Me.TrieuChung = TrieuChung
            Me.MaLoaiBenh = MaLoaiBenh
            Me.MaThuoc = MaThuoc
            Me.MaDonVi = MaDonVi
            Me.SoLuong = SoLuong
            Me.MaCachDung = MaCachDung
            Me.LoiDan = LoiDan
        End Sub

        ''' <summary>
        ''' Lấy dữ liệu từ datarow
        ''' </summary>
        ''' <param name="row"></param>
        Public Sub New(ByVal row As DataRow)
            MaChiTietPhieuKham = row.Field(Of String)("machitietphieukham")
            MaKhamBenh = row.Field(Of String)("makhambenh")
            TrieuChung = row.Field(Of String)("trieuchung")
            MaLoaiBenh = row.Field(Of String)("maloaibenh")
            TenLoaiBenh = row.Field(Of String)("tenloaibenh")
            MaThuoc = row.Field(Of String)("mathuoc")
            TenThuoc = row.Field(Of String)("tenthuoc")
            MaDonVi = row.Field(Of String)("madonvi")
            TenDonVi = row.Field(Of String)("tendonvi")
            SoLuong = row.Field(Of Integer)("soluong")
            MaCachDung = row.Field(Of String)("macachdung")
            TenCachDung = row.Field(Of String)("tencachdung")
            LoiDan = row.Field(Of String)("loidan")
        End Sub
    End Class
End Namespace