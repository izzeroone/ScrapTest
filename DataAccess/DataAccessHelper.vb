Imports System.Data
Imports System.Windows.Forms
Imports Npgsql
Imports Entities.Entities
Namespace DataAccess
    Public Module DataAccessHelper
        'Cấu hình mặc định
        Private ReadOnly defaultUser As String = "ngayngu"
        Private ReadOnly defaultPassword As String = "vip123"
        Private ReadOnly defaultHost As String = "127.0.0.1"
        Private ReadOnly defaultPort As Integer = 5432
        Private ReadOnly defaultDatabase As String = "QuanLyPhongMach2"

        Private connectionString As String
        'Dùng để lưu thông số cấu hình
        Private _user As String = defaultUser
        Private _password As String = defaultPassword
        Private _host As String = defaultHost
        Private _port As Integer = defaultPort
        Private _database As String = defaultDatabase

        Sub New()
            ConstructConnectionString()
        End Sub
        ''' <summary>
        ''' Tạo connection string
        ''' </summary>
        Public Sub ConstructConnectionString()
            connectionString = String.Format("User ID={0};Password={1};Host={2};Port={3};Database={4};",
                                         _user, _password, _host, _port.ToString(), _database)
        End Sub

        ''' <summary>
        ''' Hàm cập nhật thông số cài đặt
        ''' </summary>
        Public Sub UpdateCauHinh(ByVal cauHinh As CauHinhCSDLDTO)
            _user = cauHinh.Username
            _password = cauHinh.Password
            _host = cauHinh.Address
            _port = cauHinh.Port.ToString()
            _database = cauHinh.Database
            ConstructConnectionString()
        End Sub

        ''' <summary>
        ''' Kiểm tra thông số cấu hình có kết nối được không
        ''' </summary>
        Public Function TestConnectionString(ByVal cauHinh As CauHinhCSDLDTO) As Boolean
            Dim testString As String = String.Format("User ID={0};Password={1};Host={2};Port={3};Database={4};",
                                         cauHinh.Username, cauHinh.Password, cauHinh.Address, cauHinh.Port.ToString(), cauHinh.Database)
            Dim result As Boolean
            Dim connect As New NpgsqlConnection(testString)
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

        ''' <summary>
        ''' Execute 1 hàm trong cơ sở dữ liệu và trả về 1 bảng
        ''' </summary>
        ''' <param name="spName"></param>
        ''' <param name="sqlParams"></param>
        ''' <returns></returns>
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
        ''' <summary>
        ''' Execute 1 hàm trong cơ sở dữ liệu và trả về 1 bảng
        ''' </summary>
        ''' <param name="spName"></param>
        ''' <returns></returns>
        Public Function ExecuteQuery(ByVal spName As String) As DataTable
            Return ExecuteQuery(spName, Nothing)
        End Function
        ''' <summary>
        ''' Execute 1 hàm trong cơ sở dữ liệu và trả về 1 đối tượng
        ''' </summary>
        ''' <param name="spName"></param>
        ''' <param name="sqlParams"></param>
        ''' <returns></returns>
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
                MessageBox.Show(ex.ToString())
            End Try

            Return dt
        End Function
        ''' <summary>
        ''' Execute 1 hàm trong cơ sở dữ liệu và trả về 1 đối tượng
        ''' </summary>
        ''' <param name="spName"></param>
        ''' <returns></returns>
        Public Function ExecuteScalar(ByVal spName As String) As Object
            Return ExecuteScalar(spName, Nothing)
        End Function
        ''' <summary>
        ''' Execute 1 hàm trong cơ sở dữ liệu và trả về có thực hiện được hay không
        ''' </summary>
        ''' <param name="spName"></param>
        ''' <param name="sqlParams"></param>
        ''' <returns></returns>
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
                MessageBox.Show(ex.ToString())
            End Try

            Return n
        End Function
        ''' <summary>
        ''' Execute 1 hàm trong cơ sở dữ liệu và trả về có thực hiện được hay không
        ''' </summary>
        ''' <param name="spName"></param>
        ''' <returns></returns>
        Public Function ExecuteNoneQuery(ByVal spName As String) As Integer
            Return ExecuteNoneQuery(spName, Nothing)
        End Function

    End Module
End Namespace
