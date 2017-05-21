Namespace Entities
    Public Class BaoCaoThuocDTO
        Private _tenThuoc As String
        Private _donViTinh As String
        Private _soLuong As Long
        Private _soLanDung As Long

        Public Property TenThuoc As String
            Get
                Return _tenThuoc
            End Get
            Set(value As String)
                _tenThuoc = value
            End Set
        End Property

        Public Property DonViTinh As String
            Get
                Return _donViTinh
            End Get
            Set(value As String)
                _donViTinh = value
            End Set
        End Property

        Public Property SoLuong As Long
            Get
                Return _soLuong
            End Get
            Set(value As Long)
                _soLuong = value
            End Set
        End Property

        Public Property SoLanDung As Long
            Get
                Return _soLanDung
            End Get
            Set(value As Long)
                _soLanDung = value
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Sub New(ByVal row As DataRow)
            TenThuoc = row.Field(Of String)("tenthuoc")
            DonViTinh = row.Field(Of String)("donvitinh")
            SoLuong = row.Field(Of Long)("soluong")
            SoLanDung = row.Field(Of Long)("solandung")
        End Sub
    End Class
End Namespace

