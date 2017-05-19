Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module LoaiCachDungDAL
#Region "1. Insert & Update"
        Public Function InsertOrUpdateLoaiCachDung(ByRef loaiCachDung As LoaiCachDungDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = loaiCachDung.MaCachDung
            param.Add(parameter)

            parameter = New NpgsqlParameter
            parameter.NpgsqlDbType = NpgsqlDbType.Text
            parameter.Value = loaiCachDung.TenCachDung
            param.Add(parameter)

            Return ExecuteNoneQuery("insertorupdateloaicachdung", param)
        End Function
#End Region
#Region "2. Delete"
        Public Function DeleteLoaiCachDungByMa(ByVal maCachDung As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = maCachDung
            param.Add(parameter)

            Return ExecuteNoneQuery("deleteloaicachdungbyma", param)
        End Function
#End Region
#Region "3. Get"
        Public Function GetMaCachDung() As String
            Return ExecuteScalar("getmacachdung")
        End Function

        Public Function GetAllLoaiCachDung() As ObservableCollection(Of LoaiCachDungDTO)
            Dim list As New ObservableCollection(Of LoaiCachDungDTO)
            Dim tb As DataTable = ExecuteQuery("getallloaicachdung")
            For Each row As DataRow In tb.Rows
                list.Add(New LoaiCachDungDTO(row))
            Next
            Return list
        End Function
#End Region
    End Module
End Namespace
