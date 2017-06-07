Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module LoaiCachDungBUS
#Region "1. Insert & Update"
        ''' <summary>
        ''' Cập nhật hoặc thêm loại cách dùng nếu chưa có
        ''' </summary>
        ''' <param name="loaiCachDung"></param>
        ''' <returns></returns>
        Public Function InsertOrUpdateCachDung(ByVal loaiCachDung As LoaiCachDungDTO) As Boolean
            Return LoaiCachDungDAL.InsertOrUpdateLoaiCachDung(loaiCachDung)
        End Function
#End Region
#Region "2.Delete"
        ''' <summary>
        ''' Xóa cách dùng dựa vào mã
        ''' </summary>
        ''' <param name="maCachDung"></param>
        ''' <returns></returns>
        Public Function DeleteCachDungByMa(ByVal maCachDung As String) As Boolean
            Return LoaiCachDungDAL.DeleteLoaiCachDungByMa(maCachDung)
        End Function
#End Region
#Region "3.Get"
        ''' <summary>
        ''' Phát sinh mã cách dùng
        ''' </summary>
        ''' <returns></returns>
        Public Function GetMaCachDung() As String
            Return LoaiCachDungDAL.GetMaCachDung()
        End Function
        ''' <summary>
        ''' Lấy danh tất cả các loại cách dùng
        ''' </summary>
        ''' <returns></returns>
        Public Function GetAllLoaiCachDung() As ObservableCollection(Of LoaiCachDungDTO)
            Dim list As New ObservableCollection(Of LoaiCachDungDTO)
            Dim tb As DataTable = LoaiCachDungDAL.GetAllLoaiCachDung()
            For Each row As DataRow In tb.Rows
                list.Add(New LoaiCachDungDTO(row))
            Next
            Return list
        End Function
#End Region
    End Module
End Namespace