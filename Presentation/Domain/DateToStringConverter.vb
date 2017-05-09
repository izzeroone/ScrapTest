Imports System.Globalization

Namespace Domain
    Public Class DateToStringConverter
        Implements IValueConverter

        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            Dim _date As Date = value
            Return _date.ToShortDateString()

        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Return Date.Parse(value.ToString())
        End Function
    End Class
End Namespace
