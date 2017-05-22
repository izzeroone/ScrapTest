Namespace Entities
    Public Class ChiTietHoaDonDTO
        Private _maChiTietHoaDon As String
        Private _maHoaDon As String
        Private _tenThuoc As String
        Private _tenDonVi As String
        Private _soLuong As Integer
        Private _donGia As Integer
        Private _thanhTien As Long

        Public Property MaChiTietHoaDon As String
            Get
                Return _maChiTietHoaDon
            End Get
            Set(value As String)
                _maChiTietHoaDon = value
            End Set
        End Property

        Public Property MaHoaDon As String
            Get
                Return _maHoaDon
            End Get
            Set(value As String)
                _maHoaDon = value
            End Set
        End Property

        Public Property TenThuoc As String
            Get
                Return _tenThuoc
            End Get
            Set(value As String)
                _tenThuoc = value
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

        Public Property DonGia As Integer
            Get
                Return _donGia
            End Get
            Set(value As Integer)
                _donGia = value
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

        Public Sub New()

        End Sub

        Public Sub New(ByVal row As DataRow)
            MaChiTietHoaDon = row.Field(Of String)("machitiethoadon")
            MaHoaDon = row.Field(Of String)("mahoadon")
            TenThuoc = row.Field(Of String)("tenthuoc")
            TenDonVi = row.Field(Of String)("tendonvi")
            SoLuong = row.Field(Of Integer)("soluong")
            DonGia = row.Field(Of Decimal)("dongia")
            ThanhTien = SoLuong * DonGia
        End Sub
    End Class
End Namespace

