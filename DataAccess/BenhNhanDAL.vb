Imports System.Windows.Forms
Imports Entities.Entities
Imports Npgsql
Imports NpgsqlTypes
Namespace DataAccess
    Public Module BenhNhanDAL
        Public Function FindBenhNhan(ByVal ngayKhamBatDau As Date,
                                     ByVal ngayKhamKetThuc As Date,
                                     ByVal hoTen As String,
                                     ByVal gioiTinh As String,
                                     ByVal namSinh As String,
                                     ByVal diaChi As String,
                                     ByVal trieuChung As String,
                                     ByVal maLoaiBenh As String,
                                     ByVal maThuoc As String,
                                     ByVal maDonVi As String) As List(Of BenhNhanDTO)
            Dim list As New List(Of BenhNhanDTO)
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Date, .Value = ngayKhamBatDau})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Date, .Value = ngayKhamKetThuc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = hoTen})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = gioiTinh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = namSinh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = diaChi})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = trieuChung})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = maLoaiBenh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = maThuoc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = maDonVi})

            Dim tb As DataTable = ExecuteQuery("findbenhnhan3", param)
            For Each row As DataRow In tb.Rows
                list.Add(New BenhNhanDTO(row))
            Next
            Return list
        End Function

        Public Function FindBenhNhanV2(ByVal ngayKhamBatDau As Date,
                                     ByVal ngayKhamKetThuc As Date,
                                     ByVal hoTen As String,
                                     ByVal gioiTinh As String,
                                     ByVal namSinh As String,
                                     ByVal diaChi As String,
                                     ByVal trieuChung As String,
                                     ByVal tenLoaiBenh As String,
                                     ByVal tenThuoc As String,
                                     ByVal tenDonVi As String) As List(Of BenhNhanDTO)
            Dim list As New List(Of BenhNhanDTO)
            Dim param As New List(Of NpgsqlParameter)
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Date, .Value = ngayKhamBatDau})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Date, .Value = ngayKhamKetThuc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = hoTen})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = gioiTinh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = namSinh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = diaChi})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = trieuChung})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = tenLoaiBenh})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = tenThuoc})
            param.Add(New NpgsqlParameter() With {.NpgsqlDbType = NpgsqlDbType.Text, .Value = tenDonVi})

            Dim tb As DataTable = ExecuteQuery("findbenhnhanv2", param)
            For Each row As DataRow In tb.Rows
                list.Add(New BenhNhanDTO(row))
            Next
            Return list
        End Function
    End Module
End Namespace