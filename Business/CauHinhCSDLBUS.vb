Imports Entities.Entities
Imports DataAccess.DataAccess
Imports System.Collections.ObjectModel
Namespace Business
    Public Module CauHinhCSDLBUS
        Public Function SetDefaultCauHinhCSDL() As CauHinhCSDLDTO
            WriteDefaultCauHinhCSDL()
            Dim cauHinh As CauHinhCSDLDTO = GetCauHinh()
            UpdateCauHinh(cauHinh)
            Return cauHinh
        End Function
        Public Function SetCauHinhCSDL(ByVal cauHinh As CauHinhCSDLDTO) As Boolean
            If TestCauHinhCSDL(cauHinh) Then
                WriteCauHinhCSDL(cauHinh)
                UpdateCauHinh(cauHinh)
                Return True
            Else
                Return False
            End If
        End Function
        Public Function TestCauHinhCSDL(ByVal cauHinh As CauHinhCSDLDTO) As Boolean
            Return DataAccessHelper.TestConnectionString(cauHinh)
        End Function
        Public Function GetCauHinhCSDL() As CauHinhCSDLDTO
            Return GetCauHinh()
        End Function
    End Module
End Namespace

