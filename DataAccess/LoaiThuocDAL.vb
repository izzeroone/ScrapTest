Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module LoaiThuocDAL
#Region "1. Insert & Update"
        Public Function InsertOrUpdateLoaiThuoc(ByRef loaiThuoc As LoaiThuocDTO) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = loaiThuoc.MaThuoc
            param.Add(parameter)

            parameter = New NpgsqlParameter
            parameter.NpgsqlDbType = NpgsqlDbType.Text
            parameter.Value = loaiThuoc.TenThuoc
            param.Add(parameter)

            Return ExecuteNoneQuery("insertorupdateloaithuoc", param)
        End Function
#End Region
#Region "2. Delete"
        Public Function DeleteLoaiThuocByMa(ByVal maThuoc As String) As Boolean
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = maThuoc
            param.Add(parameter)

            Return ExecuteNoneQuery("deleteloaithuocbyma", param)
        End Function
#End Region
#Region "3. Get"
        Public Function GetMaThuoc() As String
            Return ObjExecuteQuery("getmathuoc")
        End Function

        Public Function GetAllLoaiThuoc() As ObservableCollection(Of LoaiThuocDTO)
            Dim list As New ObservableCollection(Of LoaiThuocDTO)
            Dim tb As DataTable = ExecuteQuery("getallloaithuoc")
            For Each row As DataRow In tb.Rows
                list.Add(New LoaiThuocDTO(row))
            Next
            Return list
        End Function
#End Region
    End Module
End Namespace
