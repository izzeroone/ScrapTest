Imports Entities.Entities
Imports DataAccess.DataAccess
Imports System.Collections.ObjectModel
Namespace Business
    Public Module CauHinhCSDLBUS
        Public Function GetAllCauHinhCSDL() As List(Of CauHinhCSDLDTO)
            Return CauHinhCSDLDAL.GetAllCauHinhCSDL()
        End Function
        Public Function SetActive(ByVal activeIndex As Integer) As Boolean
            If activeIndex <= CauHinhCSDLDTO.List.Count Then
                Dim cauHinh As CauHinhCSDLDTO
                cauHinh = CauHinhCSDLDTO.List.Item(activeIndex)
                CauHinhCSDLDTO.List.RemoveAt(activeIndex)
                CauHinhCSDLDTO.List.Insert(0, cauHinh)
                CauHinhCSDLDAL.WriteCauHinhCSDL()
                Return SetCSDL()
            Else
                Return False
            End If
        End Function
        Public Function SetCSDL() As Boolean
            Try
                Dim host As String = DataAccessHelper._host
                Dim port As Integer = DataAccessHelper._port
                Dim user As String = DataAccessHelper._user
                Dim password As String = DataAccessHelper._password
                Dim database As String = DataAccessHelper._database
                DataAccessHelper._host = CauHinhCSDLDTO.List.Item(0).Address
                DataAccessHelper._port = CauHinhCSDLDTO.List.Item(0).Port
                DataAccessHelper._user = CauHinhCSDLDTO.List.Item(0).Username
                DataAccessHelper._password = CauHinhCSDLDTO.List.Item(0).Password
                DataAccessHelper._database = CauHinhCSDLDTO.List.Item(0).Database
                DataAccessHelper.ConstructConnectionString()
                If DataAccessHelper.TestConnectionString() = False Then
                    DataAccessHelper._host = host
                    DataAccessHelper._port = port
                    DataAccessHelper._user = user
                    DataAccessHelper._password = password
                    DataAccessHelper._database = database
                    DataAccessHelper.ConstructConnectionString()
                    Return False
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Module
End Namespace

