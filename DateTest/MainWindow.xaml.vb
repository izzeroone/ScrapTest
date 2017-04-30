Imports Npgsql
Class MainWindow
    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Try
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter
            parameter.ParameterName = "_NgayKham"
            parameter.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date
            parameter.Value = Date.Today()
            param.Add(parameter)
            ExecuteNoneQuery("newKhamBenh", param)

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
End Class
