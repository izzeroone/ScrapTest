Imports System.Xml.Serialization
Imports Entities.Entities
Imports System.IO
Imports Encrypt.StringCipher

Namespace DataAccess
    Public Module CauHinhCSDLDAL
        Private passphase As String = "QuanLyPhongMach"
#Region "1. Get"
        Public Function GetAllCauHinhCSDL() As List(Of CauHinhCSDLDTO)
            If Not File.Exists(IO.Path.Combine(My.Application.Info.DirectoryPath, "CauHinh.xml")) Then
                WriteCauHinhDefaultCSDL()
            End If
            Dim serializer As New XmlSerializer(GetType(List(Of CauHinhCSDLDTO)))
            Try
                Using stream As FileStream = File.OpenRead(IO.Path.Combine(My.Application.Info.DirectoryPath, "CauHinh.xml"))
                    CauHinhCSDLDTO.List = serializer.Deserialize(stream)
                End Using
                For Each item As CauHinhCSDLDTO In CauHinhCSDLDTO.List
                    item.Password = Encrypt.StringCipher.Decrypt(item.Password, passphase)
                Next
                Return CauHinhCSDLDTO.List
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region
#Region "2. Writing"
        Public Function WriteCauHinhDefaultCSDL() As Boolean
            Dim serializer As New XmlSerializer(GetType(List(Of CauHinhCSDLDTO)))
            CauHinhCSDLDTO.List.Clear()
            CauHinhCSDLDTO.List.Add(New CauHinhCSDLDTO() With {.Id = "Free Database Server",
                                                .Address = "stampy.db.elephantsql.com",
                                                .Port = "5432",
                                                .Username = "htyycgpx",
                                                .Password = Encrypt.StringCipher.Encrypt("xo2vkZBRfinzgnFOZCGzwjFSpkh33sh0", passphase),
                                                .Database = "htyycgpx"})
            CauHinhCSDLDTO.List.Add(New CauHinhCSDLDTO() With {.Id = "Local",
                                                .Address = "127.0.0.1",
                                                .Port = "5432",
                                                .Username = "ngayngu",
                                                .Password = Encrypt.StringCipher.Encrypt("abc123", passphase),
                                                .Database = "QuanLyPhongMach2"})
            Try
                Using stream As FileStream = File.OpenWrite(IO.Path.Combine(My.Application.Info.DirectoryPath, "CauHinh.xml"))
                    serializer.Serialize(stream, CauHinhCSDLDTO.List)
                End Using

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function WriteCauHinhCSDL() As Boolean
            If Not File.Exists(IO.Path.Combine(My.Application.Info.DirectoryPath, "CauHinh.xml")) Then
                WriteCauHinhDefaultCSDL()
                Return False
            End If
            File.Delete(IO.Path.Combine(My.Application.Info.DirectoryPath, "CauHinh.xml"))
            Dim serializer As New XmlSerializer(GetType(List(Of CauHinhCSDLDTO)))
            Dim tempList As List(Of CauHinhCSDLDTO) = CauHinhCSDLDTO.List
            For Each cauHinh As CauHinhCSDLDTO In tempList
                cauHinh.Password = Encrypt.StringCipher.Encrypt(cauHinh.Password, passphase)
            Next
            Try
                Using stream As FileStream = File.OpenWrite(IO.Path.Combine(My.Application.Info.DirectoryPath, "CauHinh.xml"))
                    serializer.Serialize(stream, tempList)
                End Using
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
#Region "3. Insert"
#End Region
#End Region
    End Module
End Namespace
