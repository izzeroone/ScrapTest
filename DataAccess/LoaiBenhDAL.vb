Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module LoaiBenhDAL
#Region "1. Insert & Update"
        Public Function InsertOrUpdateLoaiBenh(ByRef loaiBenh As LoaiBenhDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = loaiBenh.MaLoaiBenh
            param.Add(parameter)

            parameter = New NpgsqlParameter
            parameter.NpgsqlDbType = NpgsqlDbType.Text
            parameter.Value = loaiBenh.TenLoaiBenh
            param.Add(parameter)

            Return ExecuteNoneQuery("insertorupdateloaibenh", param)
        End Function
#End Region
#Region "2. Delete"
        Public Function DeleteLoaiBenhByMa(ByVal maLoaiBenh As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = maLoaiBenh
            param.Add(parameter)

            Return ExecuteNoneQuery("deleteloaibenhbyma", param)
        End Function
#End Region
#Region "3. Get"
        Public Function GetMaLoaiBenh() As String
            Return ExecuteScalar("getmaloaibenh")
        End Function

        Public Function GetAllLoaiBenh() As ObservableCollection(Of LoaiBenhDTO)
            Dim list As New ObservableCollection(Of LoaiBenhDTO)
            Dim tb As DataTable = ExecuteQuery("getallloaibenh")
            For Each row As DataRow In tb.Rows
                list.Add(New LoaiBenhDTO(row))
            Next
            Return list
        End Function
#End Region
    End Module
End Namespace
