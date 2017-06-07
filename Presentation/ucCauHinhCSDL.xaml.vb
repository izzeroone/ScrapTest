Imports Business.Business
Imports Entities.Entities
Imports System.Collections.ObjectModel
Public Class ucCauHinhCSDL
    ''' <summary>
    ''' Khi màn hình được hiển thì thì cập nhật lại thông số từ cơ sớ dữ liệu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub UserControl_IsVisibleChanged(sender As Object, e As DependencyPropertyChangedEventArgs)
        If Me.IsVisible = True Then
            Dim cauHinh As CauHinhCSDLDTO = GetCauHinhCSDL()
            UpdateDisplay(cauHinh)
        End If
    End Sub

    ''' <summary>
    ''' Cập nhật hiển thị cho cấu hình
    ''' </summary>
    Private Sub UpdateDisplay(ByVal cauHinh As CauHinhCSDLDTO)
        tbServer.Text = cauHinh.Address
        tbPort.Text = cauHinh.Port.ToString()
        tbUser.Text = cauHinh.Username
        tbPass.Password = cauHinh.Password
        tbDatabase.Text = cauHinh.Database
    End Sub

    ''' <summary>
    ''' Cập nhật cấu hình csdl
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        Dim cauHinh As New CauHinhCSDLDTO
        cauHinh.Address = tbServer.Text
        If Not Integer.TryParse(tbPort.Text, cauHinh.Port) Then
            Domain.Dialog.Show("Port phải là số")
            Exit Sub
        End If
        cauHinh.Username = tbUser.Text
        cauHinh.Password = tbPass.Password
        cauHinh.Database = tbDatabase.Text
        If SetCauHinhCSDL(cauHinh) Then
            Domain.Dialog.Show("Cập nhật cấu hình thành công")
        Else
            Domain.Dialog.Show("Không thể kết nối tới máy chủ")
        End If
    End Sub

    ''' <summary>
    ''' Đặt cấu hình mặc định
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DefaultButton_Click(sender As Object, e As RoutedEventArgs)
        Dim cauHinh As CauHinhCSDLDTO = CauHinhCSDLBUS.SetDefaultCauHinhCSDL()
        UpdateDisplay(cauHinh)
    End Sub

    ''' <summary>
    ''' Thử kết nối cơ sỡ dữ liệu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TestButton_Click(sender As Object, e As RoutedEventArgs)
        Dim cauHinh As New CauHinhCSDLDTO
        cauHinh.Address = tbServer.Text
        If Not Integer.TryParse(tbPort.Text, cauHinh.Port) Then
            Domain.Dialog.Show("Port phải là số")
            Exit Sub
        End If
        cauHinh.Username = tbUser.Text
        cauHinh.Password = tbPass.Password
        cauHinh.Database = tbDatabase.Text
        If CauHinhCSDLBUS.TestCauHinhCSDL(cauHinh) Then
            Domain.Dialog.Show("Kết nối tới máy chủ thành công")
        Else
            Domain.Dialog.Show("Không thể kết nối tới máy chủ")
        End If
    End Sub
End Class
