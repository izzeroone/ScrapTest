﻿Imports System.Data

Public Class KhamBenh
    Private _MaKhamBenh As String
    Private _NgayKham As Date
    Private _HoTenBenhNhan As String
    Private _GioiTinh As String
    Private _NamSinh As Int32
    Private _DiaChi As String

    Public Property MaKhamBenh As String
        Get
            Return _MaKhamBenh
        End Get
        Set(value As String)
            _MaKhamBenh = value
        End Set
    End Property

    Public Property NgayKham As Date
        Get
            Return _NgayKham
        End Get
        Set(value As Date)
            _NgayKham = value
        End Set
    End Property

    Public Property HoTenBenhNhan As String
        Get
            Return _HoTenBenhNhan
        End Get
        Set(value As String)
            _HoTenBenhNhan = value
        End Set
    End Property

    Public Property GioiTinh As String
        Get
            Return _GioiTinh
        End Get
        Set(value As String)
            _GioiTinh = value
        End Set
    End Property

    Public Property NamSinh As Int32
        Get
            Return _NamSinh
        End Get
        Set(value As Int32)
            _NamSinh = value
        End Set
    End Property

    Public Property DiaChi As String
        Get
            Return _DiaChi
        End Get
        Set(value As String)
            _DiaChi = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal NgayKham As Date, ByVal HoTenBenhNhan As String, ByVal GioiTinh As String,
                   ByVal NamSinh As Int16, ByVal DiaChi As String)
        _NgayKham = NgayKham
        _HoTenBenhNhan = HoTenBenhNhan
        _GioiTinh = GioiTinh
        _NamSinh = NamSinh
        _DiaChi = DiaChi
    End Sub

    Public Sub New(ByVal row As DataRow)
        _MaKhamBenh = row.Field(Of String)("MaKhamBenh")
        _NgayKham = row.Field(Of Date)("NgayKham")
        _GioiTinh = row.Field(Of String)("GioiTinh")
        _NamSinh = row.Field(Of Int16)("NamSinh")
        _DiaChi = row.Field(Of String)("DiaChi")
    End Sub
End Class
