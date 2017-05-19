Imports System.Xml.Serialization
Imports Entities.Entities
Imports System.IO
Imports Encrypt.StringCipher

Namespace DataAccess
    Public Module CauHinhCSDLDAL
        Private passphase As String = "QuanLyPhongMach"
#Region "1. Get"
        Public Function GetAllCauHinhCSDL() As List(Of CauHinhCSDLDTO)
            If Not File.Exists(IO.Path.Combine(My.Application.Info.DirectoryPath, "cauhinh.xml")) Then
                WriteCauHinhCSDL()
            End If
            Dim serializer As New XmlSerializer(GetType(List(Of CauHinhCSDLDTO)))
            Dim list As New List(Of CauHinhCSDLDTO)
            Try
                Using stream As FileStream = File.OpenWrite(IO.Path.Combine(My.Application.Info.DirectoryPath, "cauhinh.xml"))
                    list = serializer.Deserialize(stream)
                End Using
                For Each item As CauHinhCSDLDTO In list
                    item.Password = Encrypt.StringCipher.Decrypt(item.Password, passphase)
                Next
            Catch ex As Exception
            End Try
        End Function
#End Region
#Region "2. Writing"
        Public Function WriteCauHinhCSDL() As Boolean
            Dim serializer As New XmlSerializer(GetType(List(Of CauHinhCSDLDTO)))
            Dim list As New List(Of CauHinhCSDLDTO)
            list.Add(New CauHinhCSDLDTO() With {.Address = "127.0.0.1",
                                                .Port = "5432",
                                                .Username = "ngayngu",
                                                .Password = Encrypt.StringCipher.Encrypt("abc123", passphase),
                                                .Database = "QuanLyPhongMach"})
            list.Add(New CauHinhCSDLDTO() With {.Address = "stampy.db.elephantsql.com",
                                                .Port = "5432",
                                                .Username = "htyycgpx",
                                                .Password = Encrypt.StringCipher.Encrypt("xo2vkZBRfinzgnFOZCGzwjFSpkh33sh0", passphase),
                                                .Database = "htyycgpx"})
            Try
                Using stream As FileStream = File.OpenWrite(IO.Path.Combine(My.Application.Info.DirectoryPath, "cauhinh.xml"))
                    serializer.Serialize(stream, list)
                End Using

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
#End Region
    End Module
End Namespace
