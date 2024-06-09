Public Class BankTrans


    Property TransDate As Date
    Property TransType As String
    Property DBCR As String
    Property Reference As String = ""
    Property Keterangan As String = ""
    Property Nama As String = ""
    Property Mutasi As Double
    Property Saldo As Double
    Property IsValid As Boolean

    Public Overrides Function ToString() As String

        Return TransDate & ". " & TransType & " - " & Keterangan & " " & Nama & " : " & Mutasi & " (" & DBCR & ")"
    End Function

    Public Function RefDanKeterangan() As String
        Dim result = ""
        If (Reference.Trim <> "") Then
            result = Reference.Trim & " "
        End If

        If (Keterangan.Trim <> "") Then
            result &= Keterangan
        End If
        Return result.Trim
    End Function

    Public Function ToFormatedTextHeader(
            Optional showNama As Boolean = True,
            Optional showKeterangan As Boolean = True,
            Optional showTipe As Boolean = True,
            Optional separator As String = vbTab) As String

        Dim toHeader = "Tanggal" & separator

        If (showNama) Then
            toHeader &= "Nama" & separator
        End If
        If (showKeterangan) Then
            toHeader &= "Keterangan" & separator
        End If
        If (showTipe) Then
            toHeader &= "Tipe" & separator
        End If
        toHeader &= "Debit" & vbTab & "Kredit"

        Return toHeader
    End Function
    Public Function ToFormatedText(
            Optional showNama As Boolean = True,
            Optional showKeterangan As Boolean = True,
            Optional showTipe As Boolean = True,
            Optional separator As String = vbTab) As String
        'Format: 03/08/2023	SPBU 43.50717 REST 5307952078595783 KARTU DEBIT	 Rp100,000 	00.00

        Dim result = TransDate & separator
        If (showNama) Then
            result &= Nama & separator
        End If
        If (showKeterangan) Then
            result &= RefDanKeterangan() & separator
        End If
        If (showTipe) Then
            result &= TransType & separator
        End If

        If DBCR = "DB" Then
            result &= Mutasi & separator & "0"
        Else
            result &= "0" & separator & Mutasi

        End If
        Return result

    End Function

End Class
