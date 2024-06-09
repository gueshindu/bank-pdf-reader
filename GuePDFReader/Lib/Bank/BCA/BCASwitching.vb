Public Class BCASwitching
    Inherits BCATrans
    Public Const TRANS_TYPE = "SWITCHING"
    Dim tmpKeterangan As String = ""

    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)
        BuildSwitching()
    End Sub

    'CONTOH:
    '01/12 SWITCHING CR DR 002 5,050,000.00
    'MUNANDIROH
    ' /New BRI MOB

    '
    'CONTOH

    '24/01 SWITCHING CR TRANSFER DR 113 255,000.00
    'SUPRAPTO
    ' /BANK JATEN
    Private Sub BuildSwitching()
        bankTrans.TransType = TRANS_TYPE

        Dim idx = splitLine.Length
        Dim value As Double = 0

        While idx > 0
            If GueUtils.IsRupiah(splitLine(idx - 1)) Then
                value = GueUtils.ParseDouble(splitLine(idx - 1))
            End If
            idx -= 1
        End While
        bankTrans.Mutasi = value

        bankTrans.Reference = splitLine(3) & " " &
                                  splitLine(4) & " " &
                                  splitLine(5)

    End Sub

    Public Overrides Function NextLine(line As String) As Boolean
        If Not MyBase.NextLine(line) Then
            skipGlobalIndex -= 1
            Return False
        End If

        If transLineNumber = 2 Then
            bankTrans.Nama = line
        ElseIf transLineNumber = 2 Then
            'Contoh:
            'Q /KC SYARIAH
            tmpKeterangan = line
            bankTrans.Keterangan &= " " & tmpKeterangan
        End If

        Return True

    End Function
End Class
