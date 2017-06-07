Imports Entities.Entities
Imports DataAccess.DataAccess
Imports System.Collections.ObjectModel
Namespace Business
    Public Module CauHinhCSDLBUS
        ''' <summary>
        ''' Đặt cấu hình cơ sở dữ liệu về mặc định và trả về giao diện
        ''' </summary>
        ''' <returns></returns>
        Public Function SetDefaultCauHinhCSDL() As CauHinhCSDLDTO
            'Ghi cấu hình mặc định
            WriteDefaultCauHinhCSDL()
            'Sau đó lấy cầu hình từ file và trả về
            Dim cauHinh As CauHinhCSDLDTO = GetCauHinh()
            UpdateCauHinh(cauHinh)
            Return cauHinh
        End Function
        Public Function SetCauHinhCSDL(ByVal cauHinh As CauHinhCSDLDTO) As Boolean
            'Kiểm tra cấu hình có kết nối được hay không
            If TestCauHinhCSDL(cauHinh) Then
                'Nếu kết nối được thì ghi cấu hình và cập nhật cấu hình vào Module DataAccessHelper
                WriteCauHinhCSDL(cauHinh)
                UpdateCauHinh(cauHinh)
                Return True
            Else
                Return False
            End If
        End Function
        ''' <summary>
        ''' Kiểm tra cấu hình có kết nối được hay không
        ''' </summary>
        ''' <param name="cauHinh"></param>
        ''' <returns></returns>
        Public Function TestCauHinhCSDL(ByVal cauHinh As CauHinhCSDLDTO) As Boolean
            Return DataAccessHelper.TestConnectionString(cauHinh)
        End Function
        ''' <summary>
        ''' Lấy cấu hình cơ sở dữ liệu từ File
        ''' </summary>
        ''' <returns></returns>
        Public Function GetCauHinhCSDL() As CauHinhCSDLDTO
            Return GetCauHinh()
        End Function
    End Module
End Namespace

