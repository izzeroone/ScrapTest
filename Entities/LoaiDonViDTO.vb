Namespace Entities
    Public Class LoaiDonViDTO
        Private _MaDonVi As String
        Private _TenDonVi As String

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

        Public Sub New()

        End Sub

        Public Sub New(ByVal MaDonVi As String, ByVal TenDonVi As String)
            _MaDonVi = MaDonVi
            _TenDonVi = TenDonVi
        End Sub

        Public Sub New(ByVal row As DataRow)
            _MaDonVi = row.Field(Of String)("madonvi")
            _TenDonVi = row.Field(Of String)("tendonvi")
        End Sub
    End Class
End Namespace

