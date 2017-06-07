Namespace Entities
    Public Class BaoCaoDoanhThuDTO
        Private _ngay As Date
        Private _soBenhNhan As Integer
        Private _doanhThu As Long
        Private _tiLe As Double

        Public Property Ngay As Date
            Get
                Return _ngay
            End Get
            Set(value As Date)
                _ngay = value
            End Set
        End Property

        Public Property SoBenhNhan As Integer
            Get
                Return _soBenhNhan
            End Get
            Set(value As Integer)
                _soBenhNhan = value
            End Set
        End Property

        Public Property DoanhThu As Long
            Get
                Return _doanhThu
            End Get
            Set(value As Long)
                _doanhThu = value
            End Set
        End Property

        Public Property TiLe As Double
            Get
                Return _tiLe
            End Get
            Set(value As Double)
                _tiLe = value
            End Set
        End Property

        Public Sub New()

        End Sub
        ''' <summary>
        ''' Lấy dữ liệu từ datarow
        ''' </summary>
        ''' <param name="row"></param>
        Public Sub New(ByVal row As DataRow)
            Ngay = row.Field(Of Date)("ngay")
            SoBenhNhan = row.Field(Of Long)("sobenhnhan")
            DoanhThu = row.Field(Of Decimal)("doanhthu")
        End Sub
    End Class
End Namespace
