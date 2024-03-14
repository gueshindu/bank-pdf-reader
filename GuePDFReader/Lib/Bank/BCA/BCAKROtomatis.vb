Public Class BCAKROtomatis
    Inherits BCATrans

    Public Const TRANS_TYPE = "KR OTOMATIS"
    Private tmpKeterangan As String

    Public Sub New(line As String, periode As Date)
        MyBase.New(line, periode)
        BuildKROtomatis()
    End Sub

    Private Sub BuildKROtomatis()
        'CONTOH: 
        '         10/01 KR OTOMATIS BCA23011023006 120,000.0
        '         11/01 KR OTOMATIS MID : 885001147175 0998 397,200.00

        bankTrans.TransType = TRANS_TYPE
        bankTrans.DBCR = "CR"

        If (splitLine(3).StartsWith("BCA")) Then
            bankTrans.Reference = splitLine(3)
            bankTrans.Mutasi = GueUtils.ParseDouble(splitLine(4))
        ElseIf (splitLine(3).StartsWith("MID")) Then
            bankTrans.Reference = splitLine(3) & " " &
                                  splitLine(4) & " " &
                                  splitLine(5) & " " &
                                  splitLine(6)
            bankTrans.Mutasi = GueUtils.ParseDouble(splitLine(7))
        End If
        bankTrans.IsValid = True
    End Sub

    Public Overrides Function NextLine(line As String) As Boolean
        If Not MyBase.NextLine(line) Then
            skipGlobalIndex -= 1
            Return False
        End If

        If transLineNumber = 2 Then
            bankTrans.Nama = line
        ElseIf transLineNumber > 2 Then
            'Contoh:
            'QR : 400000.00
            'DDR: 2800.00
            'Fillet
            'AutoCr-PL
            tmpKeterangan = line
            bankTrans.Keterangan &= " " & tmpKeterangan
        End If

        Return True

    End Function
End Class
