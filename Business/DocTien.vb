
Imports VB = Microsoft.VisualBasic.Strings

Namespace Business
    Public Module DocTien

        Public Function TienBangChu(ByVal sSoTien As String) As String
            Dim DonVi() As String = {"", "nghìn ", "triệu ", "tỷ ", "nghìn ", "triệu "}
            Dim so As String
            Dim chuoi As String = ""
            Dim temp As String
            Dim id As Byte

            Do While (Not sSoTien.Equals(""))
                If sSoTien.Length <> 0 Then
                    so = getNum(sSoTien)
                    sSoTien = VB.Left(sSoTien, sSoTien.Length - so.Length)
                    temp = setNum(so)
                    so = temp
                    If Not so.Equals("") Then
                        temp = temp + DonVi(id)
                        chuoi = temp + chuoi
                    End If
                    id = id + 1
                End If
            Loop
            temp = UCase(VB.Left(chuoi, 1))

            Return temp & VB.Right(chuoi, Len(chuoi) - 1)
        End Function

        Private Function getNum(ByVal sSoTien As String) As String
            Dim so As String

            If sSoTien.Length >= 3 Then
                so = VB.Right(sSoTien, 3)
            Else
                so = VB.Right(sSoTien, sSoTien.Length)
            End If
            Return so
        End Function

        Private Function setNum(ByVal sSoTien As String) As String
            Dim chuoi As String = ""
            Dim flag0 As Boolean
            Dim flag1 As Boolean
            Dim temp As String

            temp = sSoTien
            Dim kyso() As String = {"không ", "một ", "hai ", "ba ", "bốn ", "năm ", "sáu ", "bảy ", "tám ", "chín "}
            'Xet hang tram
            If sSoTien.Length = 3 Then
                If Not (VB.Left(sSoTien, 1) = 0 And VB.Left(VB.Right(sSoTien, 2), 1) = 0 And VB.Right(sSoTien, 1) = 0) Then
                    chuoi = kyso(VB.Left(sSoTien, 1)) + "trăm "
                End If
                sSoTien = VB.Right(sSoTien, 2)
            End If
            'Xet hang chuc
            If sSoTien.Length = 2 Then
                If VB.Left(sSoTien, 1) = 0 Then
                    If VB.Right(sSoTien, 1) <> 0 Then
                        chuoi = chuoi + "linh "
                    End If
                    flag0 = True
                Else
                    If VB.Left(sSoTien, 1) = 1 Then
                        chuoi = chuoi + "mười "
                    Else
                        chuoi = chuoi + kyso(VB.Left(sSoTien, 1)) + "mươi "
                        flag1 = True
                    End If
                End If
                sSoTien = VB.Right(sSoTien, 1)
            End If
            'Xet hang don vi
            If VB.Right(sSoTien, 1) <> 0 Then
                If VB.Left(sSoTien, 1) = 5 And Not flag0 Then
                    If temp.Length = 1 Then
                        chuoi = chuoi + "năm "
                    Else
                        chuoi = chuoi + "lăm "
                    End If
                Else
                    If VB.Left(sSoTien, 1) = 1 And Not (Not flag1 Or flag0) And chuoi <> "" Then
                        chuoi = chuoi + "mốt "
                    Else
                        chuoi = chuoi + kyso(VB.Left(sSoTien, 1)) + ""
                    End If
                End If
            Else
            End If
            Return chuoi
        End Function
    End Module
End Namespace

