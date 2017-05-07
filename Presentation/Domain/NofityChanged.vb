Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Namespace Domain
    Public Module NofityChanged
        <Extension()>
        Public Sub MutateVerbose(Of TField)(ByVal instance As INotifyPropertyChanged,
                                        ByRef field As TField,
                                        ByVal newValue As TField,
                                        ByVal raise As Action(Of PropertyChangedEventArgs),
                                        Optional ByVal propertyName As String = Nothing)
            If EqualityComparer(Of TField).Default.Equals(field, newValue) Then
                Return
            End If
            field = newValue
            raise.Invoke(New PropertyChangedEventArgs(propertyName))
        End Sub
    End Module
End Namespace
