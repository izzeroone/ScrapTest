Imports System.Windows.Forms
Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module BenhNhanDAL
        ''' <summary>
        ''' Thực hiện hàm tìm kiếm bệnh nhân ở cơ sở dữ liệu
        ''' </summary>
        ''' <param name="mode"></param>
        ''' <param name="maKhamBenh"></param>
        ''' <param name="ngayKhamBatDau"></param>
        ''' <param name="ngayKhamKetThuc"></param>
        ''' <param name="hoTen"></param>
        ''' <param name="gioiTinh"></param>
        ''' <param name="namSinhBatDau"></param>
        ''' <param name="namSinhKetThuc"></param>
        ''' <param name="diaChi"></param>
        ''' <param name="trieuChung"></param>
        ''' <param name="tenLoaiBenh"></param>
        ''' <param name="maChiTietPhieuKham"></param>
        ''' <param name="tenThuoc"></param>
        ''' <param name="tenDonVi"></param>
        ''' <param name="tenCachDung"></param>
        ''' <param name="soLuongBatDau"></param>
        ''' <param name="soLuongKetThuc"></param>
        ''' <param name="tienKhamBatDau"></param>
        ''' <param name="tienKhamKetThuc"></param>
        ''' <param name="tienThuocBatDau"></param>
        ''' <param name="tienThuocKetThuc"></param>
        ''' <returns></returns>
        Public Function FindBenhNhan(ByVal mode As Integer,
                                     ByVal maKhamBenh As String,
                                     ByVal ngayKhamBatDau As Date,
                                     ByVal ngayKhamKetThuc As Date,
                                     ByVal hoTen As String,
                                     ByVal gioiTinh As String,
                                     ByVal namSinhBatDau As Integer,
                                     ByVal namSinhKetThuc As Integer,
                                     ByVal diaChi As String,
                                     ByVal trieuChung As String,
                                     ByVal tenLoaiBenh As String,
                                     ByVal maChiTietPhieuKham As String,
                                     ByVal tenThuoc As String,
                                     ByVal tenDonVi As String,
                                     ByVal tenCachDung As String,
                                     ByVal soLuongBatDau As Integer,
                                     ByVal soLuongKetThuc As Integer,
                                     ByVal tienKhamBatDau As Integer,
                                     ByVal tienKhamKetThuc As Integer,
                                     ByVal tienThuocBatDau As Integer,
                                     ByVal tienThuocKetThuc As Integer
                                     ) As DataTable
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Integer, .Value = mode})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maKhamBenh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Date, .Value = ngayKhamBatDau})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Date, .Value = ngayKhamKetThuc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = hoTen})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = gioiTinh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Integer, .Value = namSinhBatDau})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Integer, .Value = namSinhKetThuc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = diaChi})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = trieuChung})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = tenLoaiBenh})

            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Char, .Value = maChiTietPhieuKham})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = tenThuoc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = tenDonVi})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = tenCachDung})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Integer, .Value = soLuongBatDau})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Integer, .Value = soLuongKetThuc})

            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = tienKhamBatDau})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = tienKhamKetThuc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = tienThuocBatDau})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Money, .Value = tienThuocKetThuc})
            Return ExecuteQuery("findbenhnhan", param)
        End Function

    End Module
End Namespace