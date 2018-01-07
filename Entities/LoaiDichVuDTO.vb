Namespace Entities
    Public Class LoaiDichVuDTO
        Private _MaDichVu As String
        Private _TenDichVu As String
        Private _MaDonVi As String
        Private _TenDonVi As String
        Private _DonGia As Integer



        Public Sub New()

        End Sub


        ''' <summary>
        ''' Lấy dữ liệu từ datarow
        ''' </summary>
        ''' <param name="row"></param>
        Public Sub New(ByVal row As DataRow)
            _MaDichVu = row.Field(Of String)("madichvu")
            _TenDichVu = row.Field(Of String)("tendichvu")
            _MaDonVi = row.Field(Of String)("madonvi")
            _TenDonVi = row.Field(Of String)("tendonvi")
            _DonGia = row.Field(Of Decimal)("dongia")
        End Sub

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

        Public Property DonGia As Integer
            Get
                Return _DonGia
            End Get
            Set(value As Integer)
                _DonGia = value
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
    End Class
End Namespace

