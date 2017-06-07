Namespace Entities
    Public Class LoaiCachDungDTO
        Private _MaCachDung As String
        Private _TenCachDung As String

        Public Property MaCachDung As String
            Get
                Return _MaCachDung
            End Get
            Set(value As String)
                _MaCachDung = value
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
        Public Sub New(ByVal MaCachDung As String, ByVal TenCachDung As String)
            _MaCachDung = MaCachDung
            _TenCachDung = TenCachDung
        End Sub

        ''' <summary>
        ''' Lấy dữ liệu từ datarow
        ''' </summary>
        ''' <param name="row"></param>
        Public Sub New(ByVal row As DataRow)
            _MaCachDung = row.Field(Of String)("macachdung")
            _TenCachDung = row.Field(Of String)("tencachdung")
        End Sub
    End Class
End Namespace

