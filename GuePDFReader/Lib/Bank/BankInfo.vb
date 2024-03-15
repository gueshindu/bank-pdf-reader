Public Class BankInfo

    Property NamaBank As String
    Property TipeRekening As String
    Property NomorRekening As String
    Property NamaRekening As String
    Property MataUang As String

    Property SaldoAwal As Double
    Property SaldoAkhir As Double
    Property CR As Double
    Property DB As Double

    Public Overrides Function ToString() As String
        Return NamaBank & vbCrLf &
               "Tipe rekening: " & TipeRekening & vbCrLf &
               "Nomor rekening: " & NomorRekening & vbCrLf &
               "Nama rekening: " & NamaRekening & vbCrLf &
               "Mata uang: " & MataUang & vbCrLf &
               "Saldo awal: " & SaldoAwal.ToString("#,###.##") & vbCrLf &
               "Debet: " & DB.ToString("#,###.##") & vbCrLf &
               "Kredit: " & CR.ToString("#,###.##") & vbCrLf &
               "Saldo akhir: " & SaldoAkhir.ToString("#,###.##")

    End Function



End Class
