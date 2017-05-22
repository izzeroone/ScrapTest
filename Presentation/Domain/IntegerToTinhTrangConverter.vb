Imports System.Globalization

Namespace Domain
    Public Class IntegerToTinhTrangConverter
        Implements IValueConverter

        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            Dim i As Integer = value
            Select Case i
                Case 0
                    Return "Chưa khám"
                Case 1
                    Return "Đã khám, chưa thanh toán"
                Case 2
                    Return "Đã khám, đã thanh toán"
                Case Else
                    Return "Không biết"
            End Select
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

