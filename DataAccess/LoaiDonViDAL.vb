Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module LoaiDonViDAL
#Region "1. Insert & Update"
        Public Function InsertOrUpdateLoaiDonVi(ByRef loaiDonVi As LoaiDonViDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = loaiDonVi.MaDonVi
            param.Add(parameter)

            parameter = New NpgsqlParameter
            parameter.NpgsqlDbType = NpgsqlDbType.Text
            parameter.Value = loaiDonVi.TenDonVi
            param.Add(parameter)

            Return ExecuteNoneQuery("insertorupdateloaidonvi", param)
        End Function
#End Region
#Region "2. Delete"
        Public Function DeleteLoaiDonViByMa(ByVal maDonVi As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = maDonVi
            param.Add(parameter)

            Return ExecuteNoneQuery("deleteloaidonvibyma", param)
        End Function
#End Region
#Region "3. Get"
        Public Function GetMaDonVi() As String
            Return ExecuteScalar("getmadonvi")
        End Function

        Public Function GetAllLoaiDonVi() As ObservableCollection(Of LoaiDonViDTO)
            Dim list As New ObservableCollection(Of LoaiDonViDTO)
            Dim tb As DataTable = ExecuteQuery("getallloaidonvi")
            For Each row As DataRow In tb.Rows
                list.Add(New LoaiDonViDTO(row))
            Next
            Return list
        End Function
#End Region
    End Module
End Namespace
