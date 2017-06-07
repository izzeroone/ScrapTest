Imports System.Xml.Serialization
Imports Entities.Entities
Imports System.IO
Imports Encrypt.StringCipher

Namespace DataAccess
    Public Module CauHinhCSDLDAL
        'Thông số cấu hình mặc định
        Private ReadOnly passphase As String = "QuanLyPhongMach"
        Private ReadOnly defaultUser As String = "ngayngu"
        Private ReadOnly defaultPassword As String = "vip123"
        Private ReadOnly defaultHost As String = "127.0.0.1"
        Private ReadOnly defaultPort As Integer = 5432
        Private ReadOnly defaultDatabase As String = "QuanLyPhongMach2"
        Friend CauHinhCSDLDTO

        ''' <summary>
        ''' Đọc thông số cấu hình CSDL từ file
        ''' </summary>
        ''' <returns></returns>
#Region "1. Get"
        Public Function GetCauHinh() As CauHinhCSDLDTO
            Dim cauHinh As CauHinhCSDLDTO
            'Nếu chưa có file thì tạo 1 file mặc định
            If Not File.Exists(IO.Path.Combine(My.Application.Info.DirectoryPath, "CauHinh.xml")) Then
                WriteDefaultCauHinhCSDL()
            End If
            'Đọc dữ liệu từ file
            Dim serializer As New XmlSerializer(GetType(CauHinhCSDLDTO))
            Try
                Using stream As FileStream = File.OpenRead(IO.Path.Combine(My.Application.Info.DirectoryPath, "CauHinh.xml"))
                    cauHinh = serializer.Deserialize(stream)
                End Using
                cauHinh.Password = Encrypt.StringCipher.Decrypt(cauHinh.Password, passphase)
                Return cauHinh
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region
#Region "2. Writing"
        ''' <summary>
        ''' Ghi cấu hình mặc định
        ''' </summary>
        ''' <returns></returns>
        Public Function WriteDefaultCauHinhCSDL() As Boolean
            Dim serializer As New XmlSerializer(GetType(CauHinhCSDLDTO))
            'Tạo cấu hình mặc định
            Dim defaultCauHinh As New CauHinhCSDLDTO With {.Address = defaultHost, .Username = defaultUser,
                                                .Password = defaultPassword, .Port = defaultPort.ToString(),
                                                .Database = defaultDatabase}
            defaultCauHinh.Password = Encrypt.StringCipher.Encrypt(defaultCauHinh.Password, passphase)
            'Lưu cấu hình xuống file
            Try
                Using stream As FileStream = File.OpenWrite(IO.Path.Combine(My.Application.Info.DirectoryPath, "CauHinh.xml"))
                    serializer.Serialize(stream, defaultCauHinh)
                End Using
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Ghi cấu hình vào file
        ''' </summary>
        ''' <param name="cauHinh"></param>
        ''' <returns></returns>
        Public Function WriteCauHinhCSDL(ByVal cauHinh As CauHinhCSDLDTO) As Boolean
            'Nếu chưa có file thì tạo file mặc định
            If Not File.Exists(IO.Path.Combine(My.Application.Info.DirectoryPath, "CauHinh.xml")) Then
                WriteDefaultCauHinhCSDL()
                Return False
            End If
            File.Delete(IO.Path.Combine(My.Application.Info.DirectoryPath, "CauHinh.xml"))
            Dim serializer As New XmlSerializer(GetType(CauHinhCSDLDTO))
            'Mã hóa password để người ngoài không thể chôm chỉa được
            cauHinh.Password = Encrypt.StringCipher.Encrypt(cauHinh.Password, passphase)
            'Lưu cấu hình vào file
            Try
                Using stream As FileStream = File.OpenWrite(IO.Path.Combine(My.Application.Info.DirectoryPath, "CauHinh.xml"))
                    serializer.Serialize(stream, cauHinh)
                End Using
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
#End Region
    End Module
End Namespace
