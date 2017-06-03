Imports System.ComponentModel
Imports System.Data
Imports Entities.Entities
Imports DataAccess.DataAccess
Imports System.Collections.ObjectModel
Imports System.Text.RegularExpressions

Namespace Business
    Public Module KhamBenhBUS
#Region "1. Inserting"
        Public Function InsertOrUpdateKhamBenh(ByVal khamBenh As KhamBenhDTO) As Boolean
            Return KhamBenhDAL.InsertOrUpdateKhamBenh(khamBenh)
        End Function

#End Region
#Region "3. Delete"
        Public Function DeleteKhamBenhByMa(ByVal maKhamBenh As String) As Boolean
            Return KhamBenhDAL.DeleteKhamBenhByMa(maKhamBenh)
        End Function
#End Region
#Region "4. Get"
        Public Function GetKhamBenhByNgayKham(ByVal ngayKham As Date) As ObservableCollection(Of KhamBenhDTO)
            Dim list As New ObservableCollection(Of KhamBenhDTO)
            Dim tb As DataTable = KhamBenhDAL.GetKhamBenhByNgayKham(ngayKham)
            Dim khamBenh As KhamBenhDTO
            For Each row As DataRow In tb.Rows
                khamBenh = New KhamBenhDTO(row)
                khamBenh.GetAdditionData(row)
                khamBenh.TinhTrang = GetTinhTrangKhamBenh(khamBenh.MaKhamBenh)
                list.Add(khamBenh)
            Next
            Return list

        End Function

        Public Function GetMaKhamBenh() As String
            Return KhamBenhDAL.GetMaKhamBenh()
        End Function

        Public Function GetAllMaKhamBenh() As ObservableCollection(Of String)
            Return KhamBenhDAL.GetAllMaKhamBenh()
        End Function

        Public Function GetAllKhamBenh() As ObservableCollection(Of KhamBenhDTO)
            Return KhamBenhDAL.GetAllKhamBenh()
        End Function

        Public Function GetKhamBenhByMaKhamBenh(ByVal maKhamBenh As String) As KhamBenhDTO
            Return KhamBenhDAL.GetKhamBenhByMaKhamBenh(maKhamBenh)
        End Function

        Public Function GetTinhTrangKhamBenh(ByVal maKhamBenh As String) As Integer
            Return Integer.Parse(KhamBenhDAL.GetTinhTrangKhamBenh(maKhamBenh))
        End Function
#End Region

#Region "5.Valild"
        Public Function IsVaildNamSinh(ByVal namSinh As String, ByRef iNamSinh As Integer)
            If (Integer.TryParse(namSinh, iNamSinh)) Then
                If (iNamSinh > 0) Then
                    Return True
                End If
            End If
            Return False
        End Function

        Public Function IsKhamBenhInsertable(ByVal khamBenh As KhamBenhDTO) As Boolean
            Dim result As Boolean
            Try
                Boolean.TryParse(KhamBenhDAL.IsKhamBenhInsertable(khamBenh).ToString(), result)
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

        Public Function IsVaildKhamBenh(ByRef khamBenh As KhamBenhDTO) As Boolean
            Dim numberRegex As String = "\d+"
            'Trim các khoảng trắng
            khamBenh.HoTenBenhNhan.Trim()
            khamBenh.DiaChi.TrimStart()
            'Kiểm tra các điều kiện
            If khamBenh.HoTenBenhNhan = "" Or Regex.IsMatch(khamBenh.HoTenBenhNhan, numberRegex) Then
                Return False
            End If
            If Not (khamBenh.HoTenBenhNhan = "Nam" Or khamBenh.HoTenBenhNhan = "Nữ" Or khamBenh.HoTenBenhNhan = "Không biết") Then
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

