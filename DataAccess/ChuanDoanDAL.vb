Imports System.ComponentModel
Imports System.Data
Imports Npgsql
Imports NpgsqlTypes
Imports Entities.Entities
Imports System.Windows.Forms
Imports System.Collections.ObjectModel

Namespace DataAccess
    Public Module ChuanDoanDAL
#Region "1.Inserting & Update"

        Public Function InsertOrUpdateChuanDoan(ByVal chuanDoan As ChuanDoanDTO) As Boolean
            Dim result As Boolean
            result = False
            Try
                Dim param As New List(Of NpgsqlParameter)
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = chuanDoan.MaKhamBenh})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = chuanDoan.MaDichVu})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Integer, .Value = chuanDoan.SoLuong})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = chuanDoan.DonGia})
                Dim n As Boolean = ExecuteNoneQuery("insertorupdatechuandoan", param)
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
        ''' <summary>
        ''' Thực hiện hàm xóa chi tiết phiếu khám dựa vào mã
        ''' </summary>
        ''' <returns></returns>
        Public Function DeleteChuanDoanByMa(ByVal maKhamBenh As String, ByVal maDichVu As String) As Boolean
            Try
                Dim param As New List(Of NpgsqlParameter)
                param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
                param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maDichVu})
                Return ExecuteNoneQuery("deletechuandoanbyma", param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region
#Region "3. Get"

        ''' <summary>
        ''' Thực hiện hàm lấy chi tiết phiếu khám dựa vào mã khám bệnh
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetChuanDoanByMaKhamBenh(ByVal maKhamBenh As String) As DataTable
            Try
                Dim list As New ObservableCollection(Of ChiTietPhieuKhamDTO)
                Dim param As New List(Of NpgsqlParameter)
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
                Return ExecuteQuery("getchuandoanbymakhambenh", param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region
    End Module
End Namespace
