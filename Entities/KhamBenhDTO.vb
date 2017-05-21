﻿Imports System.Data

Namespace Entities
    Public Class KhamBenhDTO
        Private _maKhamBenh As String
        Private _ngayKham As Date
        Private _hoTenBenhNhan As String
        Private _gioiTinh As String
        Private _namSinh As Int32
        Private _diaChi As String
        Private _trieuChung As String
        Private _maLoaiBenh As String
        Private _tinhTrang As String

        Public Property MaKhamBenh As String
            Get
                Return _maKhamBenh
            End Get
            Set(value As String)
                _maKhamBenh = value
            End Set
        End Property

        Public Property NgayKham As Date
            Get
                Return _ngayKham
            End Get
            Set(value As Date)
                _ngayKham = value
            End Set
        End Property

        Public Property HoTenBenhNhan As String
            Get
                Return _hoTenBenhNhan
            End Get
            Set(value As String)
                _hoTenBenhNhan = value
            End Set
        End Property

        Public Property GioiTinh As String
            Get
                Return _gioiTinh
            End Get
            Set(value As String)
                _gioiTinh = value
            End Set
        End Property

        Public Property NamSinh As Int32
            Get
                Return _namSinh
            End Get
            Set(value As Int32)
                _namSinh = value
            End Set
        End Property

        Public Property DiaChi As String
            Get
                Return _diaChi
            End Get
            Set(value As String)
                _diaChi = value
            End Set
        End Property

        Public Property TrieuChung As String
            Get
                Return _trieuChung
            End Get
            Set(value As String)
                _trieuChung = value
            End Set
        End Property

        Public Property MaLoaiBenh As String
            Get
                Return _maLoaiBenh
            End Get
            Set(value As String)
                _maLoaiBenh = value
            End Set
        End Property


        Public Property TinhTrang As String
            Get
                Return _tinhTrang
            End Get
            Set(value As String)
                _tinhTrang = value
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Sub New(ByVal MaKhamBenh As String, ByVal NgayKham As Date, ByVal HoTenBenhNhan As String, ByVal GioiTinh As String,
                   ByVal NamSinh As Int16, ByVal DiaChi As String)
            _maKhamBenh = MaKhamBenh
            _ngayKham = NgayKham
            _hoTenBenhNhan = HoTenBenhNhan
            _gioiTinh = GioiTinh
            _namSinh = NamSinh
            _diaChi = DiaChi
        End Sub

        Public Sub New(ByVal row As DataRow)
            _maKhamBenh = row.Field(Of String)("makhambenh")
            _ngayKham = row.Field(Of Date)("ngaykham")
            _hoTenBenhNhan = row.Field(Of String)("hotenbenhnhan")
            _gioiTinh = row.Field(Of String)("gioitinh")
            _namSinh = row.Field(Of Int32)("namsinh")
            _diaChi = row.Field(Of String)("diachi")
        End Sub

        Public Function GetAdditionData(ByVal row As DataRow) As KhamBenhDTO
            _trieuChung = row.Field(Of String)("trieuchung")
            _maLoaiBenh = row.Field(Of String)("maloaibenh")
            '_tinhTrang = row.Field(Of String)("tinhtrang")
            Return Me
        End Function
    End Class
End Namespace
