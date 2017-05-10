Imports DataAccess.DataAccess
Imports Entities.Entities
Namespace Business
    Public Module BenhNhanBUS
        Public Function FindKhamBenh(ByVal ngayKhamBatDau As Date,
                                     ByVal ngayKhamKetThuc As Date,
                                     ByVal hoTen As String,
                                     ByVal gioiTinh As String,
                                     ByVal namSinh As String,
                                     ByVal diaChi As String,
                                     ByVal trieuChung As String,
                                     ByVal maLoaiBenh As String,
                                     ByVal maThuoc As String,
                                     ByVal maDonVi As String) As List(Of BenhNhanDTO)

            Return BenhNhanDAL.FindBenhNhan(ngayKhamBatDau, ngayKhamKetThuc, hoTen, gioiTinh, namSinh, diaChi, trieuChung, maLoaiBenh, maThuoc, maDonVi)

        End Function

        Public Function FindKhamBenhV2(ByVal ngayKhamBatDau As Date,
                                     ByVal ngayKhamKetThuc As Date,
                                     ByVal hoTen As String,
                                     ByVal gioiTinh As String,
                                     ByVal namSinh As String,
                                     ByVal diaChi As String,
                                     ByVal trieuChung As String,
                                     ByVal tenLoaiBenh As String,
                                     ByVal tenThuoc As String,
                                     ByVal tenDonVi As String) As List(Of BenhNhanDTO)

            Return BenhNhanDAL.FindBenhNhanV2(ngayKhamBatDau, ngayKhamKetThuc, hoTen, gioiTinh, namSinh, diaChi, trieuChung, tenLoaiBenh, tenThuoc, tenDonVi)

        End Function

        Public Function IsVaildNamSinh(ByVal namSinh As String, ByRef iNamSinh As Integer) As Boolean
            If (Integer.TryParse(namSinh, iNamSinh)) Then
                If (namSinh > 0) Then
                    Return True
                End If
            End If
            Return False
        End Function
    End Module
End Namespace
