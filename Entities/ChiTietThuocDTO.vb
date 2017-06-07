Namespace Entities
    Public Class ChiTietThuocDTO
        Private _tenThuoc As String
        Private _donGia As Integer
        Private _soLuong As Integer
        Private _thanhTien As Integer

        Public Property TenThuoc As String
            Get
                Return _tenThuoc
            End Get
            Set(value As String)
                _tenThuoc = value
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

        Public Property SoLuong As Integer
            Get
                Return _soLuong
            End Get
            Set(value As Integer)
                _soLuong = value
            End Set
        End Property

        Public Property ThanhTien As Integer
            Get
                Return _thanhTien
            End Get
            Set(value As Integer)
                _thanhTien = value
            End Set
        End Property

        Public Sub New()

        End Sub

        ''' <summary>
        ''' Lấy dữ liệu từ datarow
        ''' </summary>
        ''' <param name="row"></param>
        Public Sub New(ByVal row As DataRow)
            _tenThuoc = row.Field(Of String)("tenthuoc")
            _donGia = row.Field(Of Decimal)("dongia")
            _soLuong = row.Field(Of Integer)("soluong")
            _thanhTien = _soLuong * _donGia
        End Sub
    End Class
End Namespace