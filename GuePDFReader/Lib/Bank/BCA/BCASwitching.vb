Public Class BCASwitching
    Inherits BCATrans
    Public Const TRANS_TYPE = "SWITCHING"
    Dim tmpKeterangan As String = ""

    Public Sub New(oneLineTrans As String, periode As Date)
        MyBase.New(oneLineTrans, periode)
        BuildSwitching()
    End Sub

    Private Sub BuildSwitching()
        bankTrans.TransType = TRANS_TYPE
        bankTrans.Reference = splitLine(3) & " " &
                                  splitLine(4) & " " &
                                  splitLine(5)
        bankTrans.Mutasi = GueUtils.ParseDouble(splitLine(6))
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
