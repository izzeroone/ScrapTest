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
        ''' <summary>
        ''' Thực hiện hàm thêm hoặc cập nhật chi tiết phiếu khám nếu chưa có
        ''' </summary>
        ''' <param name="chiTietPhieuKham"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateChiTietPhieuKham(ByVal chiTietPhieuKham As ChiTietPhieuKhamDTO) As Boolean
            Dim result As Boolean
            result = False
            Try
                Dim param As New List(Of NpgsqlParameter)
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = chiTietPhieuKham.MaChiTietPhieuKham})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = chiTietPhieuKham.MaKhamBenh})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = chiTietPhieuKham.TrieuChung})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = chiTietPhieuKham.MaLoaiBenh})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = chiTietPhieuKham.MaThuoc})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = chiTietPhieuKham.MaDonVi})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Integer, .Value = chiTietPhieuKham.SoLuong})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = chiTietPhieuKham.MaCachDung})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = chiTietPhieuKham.LoiDan})
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
        ''' <summary>
        ''' Thực hiện hàm xóa chi tiết phiếu khám dựa vào mã
        ''' </summary>
        ''' <param name="maChiTietPhieuKham"></param>
        ''' <returns></returns>
        Public Function DeleteChiTietPhieuKhamByMa(ByVal maChiTietPhieuKham As String) As Boolean
            Try
                Dim param As New List(Of NpgsqlParameter)
                param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maChiTietPhieuKham})

                Return ExecuteNoneQuery("deletechitietphieukhambyma", param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region
#Region "3. Get"
        ''' <summary>
        ''' Thực hiền hàm phát sinh mã chi tiết phiếu khám
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaChiTietPhieuKham() As String
            Return ExecuteScalar("getmachitietphieukham").ToString()
        End Function
        ''' <summary>
        ''' Thực hiện hàm lấy chi tiết phiếu khám dựa vào mã khám bệnh
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetChiTietPhieuKhamByMaKhamBenh(ByVal maKhamBenh As String) As DataTable
            Try
                Dim list As New ObservableCollection(Of ChiTietPhieuKhamDTO)
                Dim param As New List(Of NpgsqlParameter)
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
                Return ExecuteQuery("getchitietphieukhambymakhambenh", param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region
    End Module
End Namespace
