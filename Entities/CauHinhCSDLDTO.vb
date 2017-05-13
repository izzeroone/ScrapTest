Namespace Entities
    Public Class CauHinhCSDLDTO
        Private _id As String
        Private _address As String
        Private _port As Int32
        Private _username As String
        Private _password As String
        Private _database As String

        Public Property Address As String
            Get
                Return _address
            End Get
            Set(value As String)
                _address = value
            End Set
        End Property

        Public Property Port As Integer
            Get
                Return _port
            End Get
            Set(value As Integer)
                _port = value
            End Set
        End Property

        Public Property Username As String
            Get
                Return _username
            End Get
            Set(value As String)
                _username = value
            End Set
        End Property

        Public Property Password As String
            Get
                Return _password
            End Get
            Set(value As String)
                _password = value
            End Set
        End Property

        Public Property Database As String
            Get
                Return _database
            End Get
            Set(value As String)
                _database = value
            End Set
        End Property
    End Class
End Namespace
