Public Class BankTrans


    Property TransDate As Date
    Property TransType As String
    Property DBCR As String
    Property Reference As String
    Property Keterangan As String
    Property Nama As String
    Property Mutasi As Double
    Property Saldo As Double
    Property IsValid As Boolean

    Public Overrides Function ToString() As String

        Return TransDate & ". " & TransType & " - " & Keterangan & " " & Nama & " : " & Mutasi & " (" & DBCR & ")"
    End Function

    Public Function ToFormatedText(Optional separator As String = vbTab) As String
        'Format: 03/08/2023	SPBU 43.50717 REST 5307952078595783 KARTU DEBIT	 Rp100,000 	00.00

        Dim result = TransDate & separator & Nama & separator & Reference & " " & Keterangan & separator & TransType & separator
        If DBCR = "DB" Then
            result &= Mutasi & separator & "0"
        Else
            result &= "0" & separator & Mutasi

        End If
        Return result

    End Function

End Class
