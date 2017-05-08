Imports System.ComponentModel
Imports System.Data
Imports Npgsql
Imports NpgsqlTypes
Imports Entities.Entities
Imports System.Windows.Forms
Imports System.Collections.ObjectModel

Namespace DataAccess
    Public Module ChiTietPhieuKhamDAL
#Region "1.Inserting & Update"
        Public Function InsertOrUpdateChiTietPhieuKham(ByVal ChiTietPhieuKham As ChiTietPhieuKhamDTO) As Boolean
            Dim result As Boolean
            result = False
            Try
                Dim param As New List(Of NpgsqlParameter)

                Dim parameter As New NpgsqlParameter()
                parameter.NpgsqlDbType = NpgsqlDbType.Char
                parameter.Value = ChiTietPhieuKham.MaChiTietPhieuKham
                param.Add(parameter)

                parameter = New NpgsqlParameter()
                parameter.NpgsqlDbType = NpgsqlDbType.Char
                parameter.Value = ChiTietPhieuKham.MaKhamBenh
                param.Add(parameter)

                parameter = New NpgsqlParameter()
                parameter.NpgsqlDbType = NpgsqlDbType.Text
                parameter.Value = ChiTietPhieuKham.TrieuChung
                param.Add(parameter)

                parameter = New NpgsqlParameter()
                parameter.NpgsqlDbType = NpgsqlDbType.Char
                parameter.Value = ChiTietPhieuKham.MaLoaiBenh
                param.Add(parameter)

                parameter = New NpgsqlParameter()
                parameter.NpgsqlDbType = NpgsqlDbType.Char
                parameter.Value = ChiTietPhieuKham.MaThuoc
                param.Add(parameter)

                parameter = New NpgsqlParameter()
                parameter.NpgsqlDbType = NpgsqlDbType.Char
                parameter.Value = ChiTietPhieuKham.MaDonVi
                param.Add(parameter)

                parameter = New NpgsqlParameter()
                parameter.NpgsqlDbType = NpgsqlDbType.Integer
                parameter.Value = ChiTietPhieuKham.SoLuong
                param.Add(parameter)

                parameter = New NpgsqlParameter()
                parameter.NpgsqlDbType = NpgsqlDbType.Char
                parameter.Value = ChiTietPhieuKham.MaCachDung
                param.Add(parameter)

                Dim n As Boolean = ExecuteNoneQuery("insertorupdatechitietphieukham", param)
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
        Public Function DeleteChiTietPhieuKhamByMa(ByVal maChiTietPhieuKham As String) As Boolean
            Try
                Dim param As New List(Of NpgsqlParameter)
                Dim parameter As New NpgsqlParameter()

                parameter.NpgsqlDbType = NpgsqlDbType.Char
                parameter.Value = maChiTietPhieuKham
                param.Add(parameter)

                Return ExecuteNoneQuery("deletechitietphieukhambyma", param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region
#Region "3. Get"
        Public Function GetMaChiTietPhieuKham() As String
            Return ObjExecuteQuery("getmachitietphieukham").ToString()
        End Function

        Public Function GetChiTietPhieuKhamByMaKhamBenh(ByVal maKhamBenh As String) As ObservableCollection(Of ChiTietPhieuKhamDTO)
            Try
                Dim list As New ObservableCollection(Of ChiTietPhieuKhamDTO)
                Dim param As New List(Of NpgsqlParameter)
                Dim parameter As New NpgsqlParameter()

                parameter.NpgsqlDbType = NpgsqlDbType.Char
                parameter.Value = maKhamBenh
                param.Add(parameter)

                Dim tb As DataTable = ExecuteQuery("getchitietphieukhambymakhambenh", param)
                For Each row As DataRow In tb.Rows
                    list.Add(New ChiTietPhieuKhamDTO(row))
                Next
                Return list
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region
    End Module
End Namespace
