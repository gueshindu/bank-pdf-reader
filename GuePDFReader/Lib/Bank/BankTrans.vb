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


End Class
