Imports System.ComponentModel
Imports System.Data
Imports Npgsql
Imports NpgsqlTypes
Imports Entities.Entities
Imports System.Windows.Forms
Imports System.Collections.ObjectModel

Namespace DataAccess
    Public Module KhamBenhDAL
#Region "1.Inserting & Update"
        Public Function InsertOrUpdateKhamBenh(ByVal khamBenh As KhamBenhDTO) As Boolean
            Dim result As Boolean
            result = False
            Try
                Dim param As New List(Of NpgsqlParameter)
                Dim parameter As New NpgsqlParameter()

                parameter.NpgsqlDbType = NpgsqlDbType.Char
                parameter.Value = khamBenh.MaKhamBenh
                param.Add(parameter)

                parameter = New NpgsqlParameter()
                parameter.NpgsqlDbType = NpgsqlDbType.Date
                parameter.Value = khamBenh.NgayKham
                param.Add(parameter)

                parameter = New NpgsqlParameter()
                parameter.DbType = System.Data.DbType.String
                parameter.Value = khamBenh.HoTenBenhNhan
                param.Add(parameter)

                parameter = New NpgsqlParameter()
                parameter.DbType = System.Data.DbType.String
                parameter.Value = khamBenh.GioiTinh
                param.Add(parameter)

                parameter = New NpgsqlParameter()
                parameter.NpgsqlDbType = NpgsqlDbType.Integer
                parameter.Value = khamBenh.NamSinh
                param.Add(parameter)

                parameter = New NpgsqlParameter()
                parameter.DbType = System.Data.DbType.String
                parameter.Value = khamBenh.DiaChi
                param.Add(parameter)

                Dim n As Boolean = ExecuteNoneQuery("insertorupdatekhambenh", param)
                If (n = True) Then
                    result = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
            Return result
        End Function
#End Region

#Region "2. Delete"
        Public Function DeleteKhamBenhByMa(ByVal maKhamBenh As String) As Boolean
            Try
                Dim param As New List(Of NpgsqlParameter)
                Dim parameter As New NpgsqlParameter()

                parameter.NpgsqlDbType = NpgsqlDbType.Char
                parameter.Value = maKhamBenh
                param.Add(parameter)

                Return ExecuteNoneQuery("deletekhambenhbyma", param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region
#Region "3. Get"
        Public Function GetMaKhamBenh() As String
            Return ObjExecuteQuery("getmakhambenh").ToString()
        End Function

        Public Function GetKhamBenhByNgayKham(ByVal ngayKham As Date) As BindingList(Of KhamBenhDTO)
            Try
                Dim list As New BindingList(Of KhamBenhDTO)
                Dim param As New List(Of NpgsqlParameter)
                Dim parameter As New NpgsqlParameter()

                parameter.NpgsqlDbType = NpgsqlDbType.Date
                parameter.Value = ngayKham
                param.Add(parameter)

                Dim tb As DataTable = ExecuteQuery("getkhambenhbyngaykham", param)
                For Each row As DataRow In tb.Rows
                    list.Add(New KhamBenhDTO(row))
                Next
                Return list
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetAllMaKhamBenh() As ObservableCollection(Of String)
            Try

                Dim list As New ObservableCollection(Of String)
                Dim tb As DataTable = ExecuteQuery("getallmakhambenh")
                For Each row As DataRow In tb.Rows
                    list.Add(row.Field(Of String)("makhambenh"))
                Next
                Return list
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetKhamBenhByMaKhamBenh(ByVal MaKhamBenh As String) As KhamBenhDTO
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter()

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = MaKhamBenh
            param.Add(parameter)

            Dim tb As DataTable = ExecuteQuery("getkhambenhbymakhambenh", param)
            Return New KhamBenhDTO(tb.Rows.Item(0))
        End Function
#End Region
#Region "4.Vaild"
        Public Function IsKhamBenhInsertable(ByVal khamBenh As KhamBenhDTO) As Object
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = khamBenh.MaKhamBenh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Date, .Value = khamBenh.NgayKham})

            Return ObjExecuteQuery("iskhambenhinsertable", param)
        End Function
#End Region
    End Module
End Namespace
