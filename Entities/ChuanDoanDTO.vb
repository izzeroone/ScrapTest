Namespace Entities
    Public Class ChuanDoanDTO
        Private _MaKhamBenh As String
        Private _MaDichVu As String
        Private _TenDichVu As String
        Private _MaDonVi As String
        Private _TenDonVi As String
        Private _SoLuong As Integer
        Private _DonGia As Integer


        Public Sub New()

        End Sub


        ''' <summary>
        ''' Lấy dữ liệu từ datarow
        ''' </summary>
        ''' <param name="row"></param>
        Public Sub New(ByVal row As DataRow)
            MaKhamBenh = row.Field(Of String)("makhambenh")
            MaDichVu = row.Field(Of String)("madichvu")
            TenDichVu = row.Field(Of String)("tendichvu")
            MaDonVi = row.Field(Of String)("madonvi")
            TenDonVi = row.Field(Of String)("tendonvi")
            SoLuong = row.Field(Of Integer)("soluong")
            DonGia = row.Field(Of Decimal)("dongia")

        End Sub

        Public Property MaKhamBenh As String
            Get
                Return _MaKhamBenh
            End Get
            Set(value As String)
                _MaKhamBenh = value
            End Set
        End Property

        Public Property MaDichVu As String
            Get
                Return _MaDichVu
            End Get
            Set(value As String)
                _MaDichVu = value
            End Set
        End Property

        Public Property TenDichVu As String
            Get
                Return _TenDichVu
            End Get
            Set(value As String)
                _TenDichVu = value
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

        Public Property DonGia As Integer
            Get
                Return _DonGia
            End Get
            Set(value As Integer)
                _DonGia = value
            End Set
        End Property
    End Class
End Namespace