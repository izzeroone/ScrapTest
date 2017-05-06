Imports System.ComponentModel
Imports System.Data
Imports Npgsql
Imports NpgsqlTypes

Module KhamBenhDAO
#Region "1.Inserting"
    Public Function insertKhamBenh(ByVal khamBenh As KhamBenh) As Boolean
        Dim result As Boolean
        result = False
        Try
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter()

            parameter.ParameterName = "_NgayKham"
            'parameter.DbType = NpgsqlDbType.Date
            parameter.NpgsqlDbType = NpgsqlDbType.Date
            parameter.Value = khamBenh.NgayKham
            param.Add(parameter)

            parameter = New NpgsqlParameter()
            parameter.ParameterName = "_HoTenBenhNhan"
            parameter.DbType = System.Data.DbType.String
            parameter.Value = khamBenh.HoTenBenhNhan
            param.Add(parameter)

            parameter = New NpgsqlParameter()
            parameter.ParameterName = "_GioiTinh"
            parameter.DbType = System.Data.DbType.String
            parameter.Value = khamBenh.GioiTinh
            param.Add(parameter)

            parameter = New NpgsqlParameter()
            parameter.ParameterName = "_NamSinh"
            parameter.NpgsqlDbType = NpgsqlDbType.Integer
            parameter.Value = khamBenh.NamSinh
            param.Add(parameter)

            parameter = New NpgsqlParameter()
            parameter.ParameterName = "_DiaChi"
            parameter.DbType = System.Data.DbType.String
            parameter.Value = khamBenh.DiaChi
            param.Add(parameter)

            Dim n As Boolean = ExecuteNoneQuery("newKhamBenh", param)
            If (n = True) Then
                result = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return result
    End Function

    Public Function insertOrUpdateKhamBenh(ByVal khamBenh As KhamBenh) As Boolean
        Dim result As Boolean
        result = False
        Try
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter()

            parameter.ParameterName = "__MaKhamBenh"
            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = khamBenh.MaKhamBenh
            param.Add(parameter)

            parameter = New NpgsqlParameter()
            parameter.ParameterName = "_NgayKham"
            parameter.NpgsqlDbType = NpgsqlDbType.Date
            parameter.Value = khamBenh.NgayKham
            param.Add(parameter)

            parameter = New NpgsqlParameter()
            parameter.ParameterName = "_HoTenBenhNhan"
            parameter.DbType = System.Data.DbType.String
            parameter.Value = khamBenh.HoTenBenhNhan
            param.Add(parameter)

            parameter = New NpgsqlParameter()
            parameter.ParameterName = "_GioiTinh"
            parameter.DbType = System.Data.DbType.String
            parameter.Value = khamBenh.GioiTinh
            param.Add(parameter)

            parameter = New NpgsqlParameter()
            parameter.ParameterName = "_NamSinh"
            parameter.NpgsqlDbType = NpgsqlDbType.Integer
            parameter.Value = khamBenh.NamSinh
            param.Add(parameter)

            parameter = New NpgsqlParameter()
            parameter.ParameterName = "_DiaChi"
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

#Region "3. Delete"
    Public Function DeleteKhamBenhById(ByVal maKhamBenh As String) As Boolean
        Try
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter()

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = maKhamBenh
            param.Add(parameter)

            Return ExecuteNoneQuery("deletekhambenhbyid", param)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "4. Get"
    Public Function GetMaKhamBenh() As String
        Return ObjExecuteQuery("getmakhambenh").ToString()
    End Function

    Public Function GetKhamBenhByDate(ByVal ngayKham As Date) As BindingList(Of KhamBenh)
        Try
            Dim list As New BindingList(Of KhamBenh)
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter()

            parameter.NpgsqlDbType = NpgsqlDbType.Date
            parameter.Value = ngayKham
            param.Add(parameter)

            Dim tb As DataTable = ExecuteQuery("getkhambenhbydate", param)
            For Each row As DataRow In tb.Rows
                list.Add(New KhamBenh(row))
            Next
            Return list
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Module
