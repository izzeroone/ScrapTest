﻿Imports System.Data
Imports Npgsql
Module DataAccessHelper
    Dim connectionString As String

    Sub New()
        connectionString = String.Format("User ID={0};Password={1};Host={2};Port={3};Database={4};",
                                         "ngayngu", "abc123", "127.0.0.1", "5432", "QuanLyPhongMach")
    End Sub

    Public Function ExecuteQuery(ByVal spName As String, sqlParams As List(Of NpgsqlParameter)) As DataTable
        Dim dt As DataTable = New DataTable
        Try
            Dim connect As NpgsqlConnection = New NpgsqlConnection(connectionString)
            connect.Open()

            Try
                Dim command As NpgsqlCommand = connect.CreateCommand
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = spName
                If (Not (sqlParams) Is Nothing) Then
                    For Each param As NpgsqlParameter In sqlParams
                        command.Parameters.Add(param)
                    Next
                End If

                Dim adapter As NpgsqlDataAdapter = New NpgsqlDataAdapter
                adapter.SelectCommand = command
                adapter.Fill(dt)
            Catch ex As NpgsqlException
                Throw ex
            Finally
                connect.Close()
            End Try

        Catch ex As Exception
            Throw ex
        End Try

        Return dt
    End Function

    Public Function ExecuteQuery(ByVal spName As String) As DataTable
        Return ExecuteQuery(spName, Nothing)
    End Function

    Public Function ExecuteNoneQuery(ByVal spName As String, ByVal sqlParams As List(Of NpgsqlParameter)) As Integer
        Dim n As Integer
        Try
            Dim connect As NpgsqlConnection = New NpgsqlConnection(connectionString)
            connect.Open
            Try
                Dim command As NpgsqlCommand = connect.CreateCommand
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = spName
                If (Not (sqlParams) Is Nothing) Then
                    For Each param As NpgsqlParameter In sqlParams
                        command.Parameters.Add(param)
                    Next
                End If

                n = command.ExecuteNonQuery
            Catch ex As NpgsqlException
                Throw ex
            Finally
                connect.Close
            End Try

        Catch ex As Exception
            Throw ex
        End Try

        Return n
    End Function

    Public Function ExecuteNoneQuery(ByVal spName As String) As Integer
        Return ExecuteNoneQuery(spName, Nothing)
    End Function

End Module
