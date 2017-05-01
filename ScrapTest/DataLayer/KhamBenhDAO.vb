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
#End Region
#Region "4. Get"
    Public Function GetMaKhamBenh() As String
        Return ObjExecuteQuery("getmakhambenh").ToString()
    End Function
#End Region
End Module
