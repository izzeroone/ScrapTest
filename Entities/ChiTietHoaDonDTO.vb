Namespace Entities
    Public Class ChiTietHoaDonDTO
        Private _maChiTietPhieuKham As String
        Private _maKhamBenh As String
        Private _tenMatHang As String
        Private _tenDonVi As String
        Private _soLuong As Integer
        Private _donGiaThucTe As Integer
        Private _thanhTien As Long

        Public Property MaChiTietPhieuKham As String
            Get
                Return _maChiTietPhieuKham
            End Get
            Set(value As String)
                _maChiTietPhieuKham = value
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

        Public Property TenMatHang As String
            Get
                Return _tenMatHang
            End Get
            Set(value As String)
                _tenMatHang = value
            End Set
        End Property

        Public Property TenDonVi As String
            Get
                Return _tenDonVi
            End Get
            Set(value As String)
                _tenDonVi = value
            End Set
        End Property

        Public Property SoLuong As Integer
            Get
                Return _soLuong
            End Get
            Set(value As Integer)
                _soLuong = value
            End Set
        End Property


        Public Property ThanhTien As Long
            Get
                Return _thanhTien
            End Get
            Set(value As Long)
                _thanhTien = value
            End Set
        End Property

        Public Property DonGiaThucTe As Integer
            Get
                Return _donGiaThucTe
            End Get
            Set(value As Integer)
                _donGiaThucTe = value
            End Set
        End Property

        Public Sub New()

        End Sub

        ''' <summary>
        ''' Lấy dữ liệu từ datarow
        ''' </summary>
        ''' <param name="row"></param>
        Public Sub New(ByVal row As DataRow)
            MaChiTietPhieuKham = row.Field(Of String)("machitietphieukham")
            MaKhamBenh = row.Field(Of String)("makhambenh")
            TenMatHang = row.Field(Of String)("tenthuoc")
            TenDonVi = row.Field(Of String)("tendonvi")
            SoLuong = row.Field(Of Integer)("soluong")
            DonGiaThucTe = row.Field(Of Decimal)("dongiathucte")
            ThanhTien = SoLuong * DonGiaThucTe
        End Sub
    End Class
End Namespace

