Public Class BankInfo

    Property TipeRekening As String
    Property NomorRekening As String
    Property NamaRekening As String
    Property MataUang As String

    Property SaldoAwal As Double
    Property SaldoAkhir As Double
    Property CR As Double
    Property DB As Double

    Public Overrides Function ToString() As String
        Return "Tipe rekening: " & TipeRekening & vbCrLf &
               "Nomor rekening: " & NomorRekening & vbCrLf &
               "Nama rekening: " & NamaRekening & vbCrLf &
               "Mata uang: " & MataUang & vbCrLf &
               "Saldo awal: " & SaldoAwal & vbCrLf &
               "Debet: " & DB & vbCrLf &
               "Kredit: " & CR & vbCrLf &
               "Saldo akhir: " & SaldoAkhir

    End Function



End Class
