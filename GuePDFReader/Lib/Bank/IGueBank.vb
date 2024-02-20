Public Interface IGueBank
    Function ExecuteParse() As Boolean
    Sub SetTextToParse(txt As String)
    Function GetBankInfo() As BankInfo
    Function GetBankDocsPeriode() As Date
    Function GetListTransaksi() As List(Of BankTrans)
End Interface
