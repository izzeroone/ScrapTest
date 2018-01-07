Imports System.ComponentModel
Imports System.Data
Imports Npgsql
Imports NpgsqlTypes
Imports Entities.Entities
Imports System.Windows.Forms
Imports System.Collections.ObjectModel

Namespace DataAccess
    Public Module KhamBenhDAL
#Region "1.Inserting & Update"
        ''' <summary>
        ''' Thực hiện cập nhật hoặc thêm khám bệnh nếu chưa có
        ''' </summary>
        ''' <param name="khamBenh"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateKhamBenh(ByVal khamBenh As KhamBenhDTO) As Boolean
            Dim result As Boolean
            result = False
            Try
                Dim param As New List(Of NpgsqlParameter)

                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = khamBenh.MaKhamBenh})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Date, .Value = khamBenh.NgayKham})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = khamBenh.HoTenBenhNhan})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = khamBenh.GioiTinh})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Integer, .Value = khamBenh.NamSinh})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = khamBenh.DiaChi})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = khamBenh.DienThoai})

                Dim n As Boolean = ExecuteNoneQuery("insertorupdatekhambenh", param)
                If (n = True) Then
                    result = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
            Return result
        End Function

        Public Function UpdateChuanDoanBenh(ByVal khamBenh As KhamBenhDTO) As Boolean
            Dim result As Boolean
            result = False
            Try
                Dim param As New List(Of NpgsqlParameter)

                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = khamBenh.MaKhamBenh})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = khamBenh.TrieuChung})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = khamBenh.MaLoaiBenh})
                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = khamBenh.LoiDan})

                Dim n As Boolean = ExecuteNoneQuery("updatechuandoanbenh", param)
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
        ''' Thực hiện hàm xóa khám bệnh dựa trên mã
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function DeleteKhamBenhByMa(ByVal maKhamBenh As String) As Boolean
            Try
                Dim param As New List(Of NpgsqlParameter)

                param.Add(New NpgsqlParameter With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})

                Return ExecuteNoneQuery("deletekhambenhbyma", param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region
#Region "3. Get"
        ''' <summary>
        ''' Phát sinh mã khám bệnh
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaKhamBenh() As String
            Return ExecuteScalar("getmakhambenh").ToString()
        End Function

        ''' <summary>
        ''' Lấy danh sách bệnh nhân của ngày khám
        ''' </summary>
        ''' <param name="ngayKham"></param>
        ''' <returns></returns>
        Public Function GetKhamBenhByNgayKham(ByVal ngayKham As Date) As DataTable
            Try
                Dim list As New BindingList(Of KhamBenhDTO)
                Dim param As New List(Of NpgsqlParameter)
                Dim parameter As New NpgsqlParameter()

                parameter.NpgsqlDbType = NpgsqlDbType.Date
                parameter.Value = ngayKham
                param.Add(parameter)

                Return ExecuteQuery("getkhambenhbyngaykham", param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>
        ''' Lấy thông tin của bệnh nhân dựa trên ngày khám
        ''' </summary>
        ''' <param name="MaKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetKhamBenhByMaKhamBenh(ByVal MaKhamBenh As String) As KhamBenhDTO
            Dim param As New List(Of NpgsqlParameter)
            Dim parameter As New NpgsqlParameter()

            parameter.NpgsqlDbType = NpgsqlDbType.Char
            parameter.Value = MaKhamBenh
            param.Add(parameter)

            Dim tb As DataTable = ExecuteQuery("getkhambenhbymakhambenh", param)
            Return New KhamBenhDTO(tb.Rows.Item(0)).GetAdditionData(tb.Rows.Item(0))
        End Function

        ''' <summary>
        ''' Lấy tình tráng khám bệnh của bệnh nhân
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetTinhTrangKhamBenh(ByVal maKhamBenh As String) As String
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            Return ExecuteScalar("gettinhtrangkhambenh", param).ToString()
        End Function
#End Region
#Region "4.Vaild"
        ''' <summary>
        ''' Kiểm tra xem có vượt quá thông số số bệnh nhân tối đa hay không
        ''' </summary>
        ''' <param name="khamBenh"></param>
        ''' <returns></returns>
        Public Function IsKhamBenhInsertable(ByVal khamBenh As KhamBenhDTO) As Object
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = khamBenh.MaKhamBenh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Date, .Value = khamBenh.NgayKham})

            Return ExecuteScalar("iskhambenhinsertable", param)
        End Function
#End Region
    End Module
End Namespace
