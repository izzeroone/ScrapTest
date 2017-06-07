Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module LoaiBenhBUS
#Region "1.Insert & Update"
        ''' <summary>
        ''' Cập nhật hoặc thêm loại bệnh nếu chưa có
        ''' </summary>
        ''' <param name="loaiBenh"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateLoaiBenh(ByVal loaiBenh As LoaiBenhDTO) As Boolean
            Return LoaiBenhDAL.InsertOrUpdateLoaiBenh(loaiBenh)
        End Function
#End Region
#Region "2.Delete"
        ''' <summary>
        ''' Xóa loại bệnh dựa vào mã loại bệnh
        ''' </summary>
        ''' <param name="maLoaiBenh"></param>
        ''' <returns></returns>
        Public Function DeleteLoaiBenhByMa(ByVal maLoaiBenh As String) As Boolean
            Return LoaiBenhDAL.DeleteLoaiBenhByMa(maLoaiBenh)
        End Function
#End Region
#Region "3.Get"
        ''' <summary>
        ''' Phát sinh mã loại bệnh
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaLoaiBenh() As String
            Return LoaiBenhDAL.GetMaLoaiBenh()
        End Function
        ''' <summary>
        ''' Lấy danh sách tất cả loại bệnh
        ''' </summary>
        ''' <returns></returns>
        Public Function GetAllLoaiBenh() As ObservableCollection(Of LoaiBenhDTO)
            Dim list As New ObservableCollection(Of LoaiBenhDTO)
            Dim tb As DataTable = LoaiBenhDAL.GetAllLoaiBenh()
            For Each row As DataRow In tb.Rows
                list.Add(New LoaiBenhDTO(row))
            Next
            Return list
        End Function
#End Region
    End Module
End Namespace