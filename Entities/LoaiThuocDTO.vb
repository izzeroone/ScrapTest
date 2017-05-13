Namespace Entities
    Public Class LoaiThuocDTO
        Private _MaThuoc As String
        Private _TenThuoc As String
        Private _DonGia As Integer

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



        Public Property DonGia As Integer
            Get
                Return _DonGia
            End Get
            Set(value As Integer)
                _DonGia = value
            End Set
        End Property

        Public Sub New()

        End Sub
        Public Sub New(ByVal MaThuoc As String, ByVal TenThuoc As String)
            _MaThuoc = MaThuoc
            _TenThuoc = TenThuoc
        End Sub

        Public Sub New(ByVal row As DataRow)
            _MaThuoc = row.Field(Of String)("mathuoc")
            _TenThuoc = row.Field(Of String)("tenthuoc")
            _DonGia = row.Field(Of Decimal)("dongia")
        End Sub
    End Class
End Namespace

