Imports System.Globalization

Namespace Domain
    Public Class DoubleToPercentConverter
        Implements IValueConverter

        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            Dim v As Double = value
            Return String.Format(CultureInfo.InvariantCulture,
                                      "{0:#0.##%}", v)
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

