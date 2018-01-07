Imports System.ComponentModel
Imports System.Data
Imports Entities.Entities
Imports DataAccess.DataAccess
Imports System.Collections.ObjectModel
Imports System.Text.RegularExpressions

Namespace Business
    Public Module KhamBenhBUS
#Region "1. Inserting"
        ''' <summary>
        ''' Thêm bệnh nhân vào cơ sở dữ liệu
        ''' </summary>
        ''' <param name="khamBenh"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateKhamBenh(ByVal khamBenh As KhamBenhDTO) As Boolean
            Return KhamBenhDAL.InsertOrUpdateKhamBenh(khamBenh)
        End Function

        Public Function updateChuanDoanKhamBenh(ByVal khamBenh As KhamBenhDTO) As Boolean
            Return KhamBenhDAL.UpdateChuanDoanBenh(khamBenh)
        End Function
#End Region
#Region "2. Delete"
        ''' <summary>
        ''' Xóa bệnh nhân theo mã khám bệnh
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function DeleteKhamBenhByMa(ByVal maKhamBenh As String) As Boolean
            Return KhamBenhDAL.DeleteKhamBenhByMa(maKhamBenh)
        End Function
#End Region
#Region "3. Get"
        ''' <summary>
        ''' Lấy danh sách khám bệnh theo ngày khám
        ''' </summary>
        ''' <param name="ngayKham"></param>
        ''' <returns></returns>
        Public Function GetKhamBenhByNgayKham(ByVal ngayKham As Date) As ObservableCollection(Of KhamBenhDTO)
            Dim list As New ObservableCollection(Of KhamBenhDTO)
            '
            Dim tb As DataTable = KhamBenhDAL.GetKhamBenhByNgayKham(ngayKham)
            Dim khamBenh As KhamBenhDTO
            'Lấy thông tin của từng bệnh nhân từ bảng vào danh sách
            For Each row As DataRow In tb.Rows
                khamBenh = New KhamBenhDTO(row)
                khamBenh.GetAdditionData(row)
                khamBenh.TinhTrang = GetTinhTrangKhamBenh(khamBenh.MaKhamBenh)
                list.Add(khamBenh)
            Next
            Return list

        End Function
        ''' <summary>
        ''' Phát sinh mã khám bệnh
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaKhamBenh() As String
            Return KhamBenhDAL.GetMaKhamBenh()
        End Function
        ''' <summary>
        ''' Lấy bệnh nhân theo mã khám bệnh
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetKhamBenhByMaKhamBenh(ByVal maKhamBenh As String) As KhamBenhDTO
            Return KhamBenhDAL.GetKhamBenhByMaKhamBenh(maKhamBenh)
        End Function
        ''' <summary>
        ''' Lấy tình trạng khám bệnh của bệnh nhân (đã khám, đã thanh toán chưa)
        ''' </summary>
        ''' <param name="maKhamBenh"></param>
        ''' <returns></returns>
        Public Function GetTinhTrangKhamBenh(ByVal maKhamBenh As String) As Integer
            Return Integer.Parse(KhamBenhDAL.GetTinhTrangKhamBenh(maKhamBenh))
        End Function
#End Region
#Region "4.Valid"
        ''' <summary>
        ''' Kiểm tra năm sinh có hợp lệ hay không
        ''' </summary>
        ''' <param name="namSinh"></param>
        ''' <param name="iNamSinh"></param>
        ''' <returns></returns>
        Public Function IsVaildNamSinh(ByVal namSinh As String, ByRef iNamSinh As Integer)
            If (Integer.TryParse(namSinh, iNamSinh)) Then
                If (iNamSinh > 0) Then
                    Return True
                End If
            End If
            Return False
        End Function
        ''' <summary>
        ''' Kiểm tra xem có vượt quá số bệnh nhân khám tối đa hay không
        ''' </summary>
        ''' <param name="khamBenh"></param>
        ''' <returns></returns>
        Public Function IsKhamBenhInsertable(ByVal khamBenh As KhamBenhDTO) As Boolean
            Dim result As Boolean
            Try
                Boolean.TryParse(KhamBenhDAL.IsKhamBenhInsertable(khamBenh).ToString(), result)
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
        ''' <summary>
        ''' Kiểm tra khám bệnh có hợp lệ hay không
        ''' </summary>
        ''' <param name="khamBenh"></param>
        ''' <returns></returns>
        Public Function IsVaildKhamBenh(ByRef khamBenh As KhamBenhDTO) As Boolean
            Dim numberRegex As String = "\d+"
            'Trim các khoảng trắng
            khamBenh.HoTenBenhNhan.Trim()
            khamBenh.DiaChi.Trim()
            'Kiểm tra các điều kiện họ tên bệnh nhân có số hay không
            If khamBenh.HoTenBenhNhan = "" Or Regex.IsMatch(khamBenh.HoTenBenhNhan, numberRegex) Then
                Return False
            End If
            'Kiểm tra giới tính phải là Nam, Nữ hoặc Không biết
            If Not (khamBenh.GioiTinh = "Nam" Or khamBenh.GioiTinh = "Nữ" Or khamBenh.GioiTinh = "Không biết") Then
                Return False
            End If
            If khamBenh.DiaChi = "" Then
                Return False
            End If
            Return True
        End Function
#End Region
    End Module
End Namespace

