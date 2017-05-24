Imports System.Data
Imports System.Windows.Forms
Imports Npgsql
Namespace DataAccess
    Public Module DataAccessHelper
        Private connectionString As String
        Public _user As String = "ngayngu"
        Public _password As String = "abc123"
        Public _host As String = "127.0.0.1"
        Public _port As Integer = "5432"
        Public _database As String = "QuanLyPhongMach2"

        Sub New()
            'connectionString = String.Format("User ID={0};Password={1};Host={2};Port={3};Database={4};",
            '                             "htyycgpx", "xo2vkZBRfinzgnFOZCGzwjFSpkh33sh0", "stampy.db.elephantsql.com", "5432", "htyycgpx")
            ConstructConnectionString()
        End Sub

        Public Sub ConstructConnectionString()
            connectionString = String.Format("User ID={0};Password={1};Host={2};Port={3};Database={4};",
                                         _user, _password, _host, _port.ToString(), _database)
        End Sub

        Public Function ExecuteQuery(ByVal spName As String, sqlParams As List(Of NpgsqlParameter)) As DataTable
            Dim dt As DataTable = New DataTable
            Try
                Dim connect As NpgsqlConnection = New NpgsqlConnection(connectionString)
                connect.Open()

                Try
                    Dim command As NpgsqlCommand = connect.CreateCommand
                    command.CommandType = CommandType.StoredProcedure
                    command.CommandText = spName
                    If (Not (sqlParams) Is Nothing) Then
                        For Each param As NpgsqlParameter In sqlParams
                            command.Parameters.Add(param)
                        Next
                    End If

                    Dim adapter As NpgsqlDataAdapter = New NpgsqlDataAdapter
                    adapter.SelectCommand = command
                    adapter.Fill(dt)
                Catch ex As NpgsqlException
                    Throw ex
                Finally
                    connect.Close()
                End Try

            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try

            Return dt
        End Function

        Public Function ExecuteQuery(ByVal spName As String) As DataTable
            Return ExecuteQuery(spName, Nothing)
        End Function

        Public Function ExecuteScalar(ByVal spName As String, sqlParams As List(Of NpgsqlParameter)) As Object
            Dim dt As Object
            Try
                Dim connect As NpgsqlConnection = New NpgsqlConnection(connectionString)
                connect.Open()

                Try
                    Dim command As NpgsqlCommand = connect.CreateCommand
                    command.CommandType = CommandType.StoredProcedure
                    command.CommandText = spName
                    If (Not (sqlParams) Is Nothing) Then
                        For Each param As NpgsqlParameter In sqlParams
                            command.Parameters.Add(param)
                        Next
                    End If

                    dt = command.ExecuteScalar()
                Catch ex As NpgsqlException
                    Throw ex
                Finally
                    connect.Close()
                End Try

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        Public Function ExecuteScalar(ByVal spName As String) As Object
            Return ExecuteScalar(spName, Nothing)
        End Function

        Public Function ExecuteNoneQuery(ByVal spName As String, ByVal sqlParams As List(Of NpgsqlParameter)) As Integer
            Dim n As Integer
            Try
                Dim connect As NpgsqlConnection = New NpgsqlConnection(connectionString)
                connect.Open()

                Try
                    Dim command As NpgsqlCommand = connect.CreateCommand
                    command.CommandType = CommandType.StoredProcedure
                    command.CommandText = spName
                    If (Not (sqlParams) Is Nothing) Then
                        For Each param As NpgsqlParameter In sqlParams
                            command.Parameters.Add(param)
                        Next
                    End If

                    n = command.ExecuteNonQuery
                Catch ex As NpgsqlException
                    Throw ex
                Finally
                    connect.Close()
                End Try

            Catch ex As Exception
                Throw ex
            End Try

            Return n
        End Function

        Public Function ExecuteNoneQuery(ByVal spName As String) As Integer
            Return ExecuteNoneQuery(spName, Nothing)
        End Function

        Public Function TestConnectionString() As Boolean
            Dim result As Boolean
            Dim connect As New NpgsqlConnection(connectionString)
            Try
                connect.Open()
                result = True
            Catch ex As Exception
                result = False
            Finally
                connect.Close()
            End Try
            Return result
        End Function
    End Module
End Namespace
