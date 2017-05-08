Imports Entities.Entities
Imports System.Collections.ObjectModel
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module ROWChiTietPhieuKhamDAL
#Region "For get only"
        Public Function GetChiTietPhieuKhamByMaKhamBenh(ByRef maKhamBenh As String) As ObservableCollection(Of ROWChiTietPhieuKhamDTO)
            Dim list As New ObservableCollection(Of ROWChiTietPhieuKhamDTO)
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = maKhamBenh
            param.Add(parameter)

            Dim dt As DataTable = ExecuteQuery("getchitietphieukhambymakhambenh", param)

            For Each row As DataRow In dt.Rows
                list.Add(New ROWChiTietPhieuKhamDTO(row))
            Next

            Return list
        End Function
#End Region
    End Module
End Namespace