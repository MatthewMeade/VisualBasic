Public Class Form1
    'Matthew Meade
    'Lab 4
    '14/10/2016
    Private Sub calculateButton_Click(sender As Object, e As EventArgs) Handles calculateButton.Click
        'Declare Variables
        Dim cardNum As String = "" 'Declare as string to allow spaces and other chars
        Dim beginBal, endBal, purchases, payments, charges, minPayment As Double

        'Call Methods
        GetData(cardNum, beginBal, purchases, payments)
        ComputeBalance(beginBal, purchases, payments, charges, endBal, minPayment)
        DisplayStatement(cardNum, beginBal, purchases, payments, charges, endBal, minPayment)
    End Sub


    'GetData
    'Get inputs from user and assign them to referenced variables
    Private Sub GetData(ByRef cardNum As String, ByRef beginBal As Double, ByRef purchases As Double, ByRef payments As Double)
        cardNum = cardTextbox.Text
        beginBal = balanceTextbox.Text
        purchases = purchasesTextbox.Text
        payments = paymentsTextBox.Text
    End Sub


    'ComputeBalance
    'Calculate end of month balance and minimum payment on the account
    'Returns charges endBal and minPayment by reference
    Private Sub ComputeBalance(beginBal As Double, purchases As Double, payments As Double, ByRef charges As Double, ByRef endBal As Double, ByRef minPayment As Double)
        'Finance Charges are 1.5% of beginning balance
        charges = beginBal * 0.015

        'Calculate end of month balance
        endBal = charges + beginBal + purchases - payments

        If endBal < 10 Then
            'If end balance is less than 10 minimum payment is the full balance
            minPayment = endBal
        Else
            'Otherwise the minimum payment is 5% of the end balance
            minPayment = endBal * 0.05
        End If
    End Sub


    'DisplayStatement
    'Output all inputs and calculated values to user
    Private Sub DisplayStatement(cardNum As String, beginBal As Double, purchases As Double, payments As Double, charges As Double, endBal As Double, minPayment As Double)

        cardOutputTextbox.Text = cardNum
        beginBalOutputTextbox.Text = beginBal
        purchasesOutputTextbox.Text = purchases
        paymentsOutputTextbox.Text = payments
        chargesOutputTextbox.Text = Format(charges, "0.00")
        endBalOutputTextbox.Text = Format(endBal, "0.00")
        minPaymentOutputTextbox.Text = Format(minPayment, "0.00")
    End Sub

End Class