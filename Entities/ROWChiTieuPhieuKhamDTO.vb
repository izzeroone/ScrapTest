Namespace Entities
    Public Class ROWChiTietPhieuKhamDTO
        Inherits ChiTietPhieuKhamDTO
        Private _TenLoaiBenh As String
        Private _TenThuoc As String
        Private _TenDonVi As String
        Private _TenCachDung As String

        Public Property TenLoaiBenh As String
            Get
                Return _TenLoaiBenh
            End Get
            Set(value As String)
                _TenLoaiBenh = value
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

        Public Property TenDonVi As String
            Get
                Return _TenDonVi
            End Get
            Set(value As String)
                _TenDonVi = value
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

        Public Sub New()

        End Sub

        Public Sub New(ByVal row As DataRow)
            MyBase.New(row)
            _TenLoaiBenh = row.Field(Of String)("tenloaibenh")
            _TenThuoc = row.Field(Of String)("tenthuoc")
            _TenDonVi = row.Field(Of String)("tendonvi")
            _TenCachDung = row.Field(Of String)("tencachdung")
        End Sub
    End Class
End Namespace

