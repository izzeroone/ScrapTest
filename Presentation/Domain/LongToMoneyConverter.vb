Imports System.Globalization

Namespace Domain
    Public Class LongToMoneyConverter
        Implements IValueConverter

        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            Dim l As Long = value
            Return String.Format(String.Format(CultureInfo.InvariantCulture,
                                      "{0:#,0₫}", value))
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
