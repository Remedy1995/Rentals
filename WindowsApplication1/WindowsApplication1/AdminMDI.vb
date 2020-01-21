Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class AdminMDI
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim i As Integer
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub


    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer
    Private am As Object
    Private con As Object
    Private tbUpperBody As Object
    Public Property ColorDialog1 As Object

    Private Sub AdminMDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        conn.ConnectionString = "Data Source=(localDB)\MSSQLLocalDB;AttachDbfilename=c:\users\remedy\documents\visual studio 2015\Projects\WindowsApplication1\WindowsApplication1\remdy.mdf;integrated Security=True"
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()















        Dim noDays As Integer

        For noDays = 1 To 365 Step 29
            cmbnodays.Items.Add(noDays)

        Next

        creditlimit.Text = "0"

        For q = 0 To 100 Step 10
            creditlimit.Items.Add(q)


        Next


        settlediscount.Text = "0"
        For d = 0 To 40 Step 5
            settlediscount.Items.Add(d)

        Next




        productdescription.Text = "select an option"
        productdescription.Items.Add("Plastic Chairs")
        productdescription.Items.Add("Plastic tables")
        productdescription.Items.Add("Canopies")
        productdescription.Items.Add("Wollen Carpets")


        Credit.Text = "validate Account"
        Credit.Items.Add("yes")
        Credit.Items.Add("No")

        depositpaid.Text = "deposit paid"
        depositpaid.Items.Add("Yes")
        depositpaid.Items.Add("No")

        paymentoverdue.Text = ("overdue Pay")
        paymentoverdue.Items.Add("Yes")
        paymentoverdue.Items.Add("No")

        paymentmethod.Text = ("Cash")
        paymentmethod.Items.Add("visa card")
        paymentmethod.Items.Add("master card")
        paymentmethod.Items.Add("debit card")




    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles productdescription.SelectedIndexChanged
        If productdescription.Text = "Plastic Chairs" Then
            productcode.Text = "PLC039"
            costPerDay.Text = "12"
            PayDueDay.Text = "GHC" + (costPerDay.Text)
        ElseIf productdescription.Text = "Plastic tables" Then
            productcode.Text = "PLT040"
            costPerDay.Text = "17"
            PayDueDay.Text = "GHC" + (costPerDay.Text)
        ElseIf productdescription.Text = "Canopies" Then
            productcode.Text = "CAN041"
            costPerDay.Text = "20"
            PayDueDay.Text = "GHC" + (costPerDay.Text)
        ElseIf productdescription.Text = "Wollen Carpets" Then
            productcode.Text = "WOCA042"
            costPerDay.Text = "27"
            PayDueDay.Text = "GHC" + (costPerDay.Text)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim iExit As DialogResult
        iExit = MessageBox.Show("Confirm if you want to exit Vision Chairs Inventory System", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If iExit = DialogResult.Yes Then

            Dim fam = New Form1
            fam.Show()
            Me.Hide()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        PayDueDay.Clear()
        productcode.Clear()
        costPerDay.Clear()


        Customername.Text = ""
        tax.Text = ""
        subtotal.Text = ""
        totalcost.Text = ""
        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today
        DateTimePicker3.Value = Today




        cmbnodays.Text = "0"
        creditlimit.Text = "0"
        productdescription.Text = "Select an option"
        settlediscount.Text = "0"


        RichText2.Clear()

        settledue.Clear()

        Qty.Clear()















































    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim discount As Double

        'cost of the plastic chairs by the number of days the client hired our products
        subtotal.Text = Val(cmbnodays.Text) * Val(costPerDay.Text)

        'subtotal by the quantity of products our clients hired
        subtotal.Text = (subtotal.Text) * (Qty.Text)


        'discount allowed on the goods

        discount = ((subtotal.Text) * settlediscount.Text) / 100


        subtotal.Text = (subtotal.Text - discount)

        tax.Text = 0.25

        totalcost.Text = ((subtotal.Text) / 100)
        totalcost.Text = totalcost.Text + (tax.Text)
        totalcost.Text = FormatNumber((totalcost.Text), 2)

        totalcost.Text = "GHC" + totalcost.Text


        tax.Text = "GHC" + (tax.Text)

        subtotal.Text = ((subtotal.Text) / 10)
        subtotal.Text = FormatNumber((subtotal.Text), 2)


        subtotal.Text = "GHC" + subtotal.Text





        totalcost.Text = (totalcost.Text)



        RichText2.AppendText("Customer Name" + vbTab + vbTab + Customername.Text + vbNewLine)
        RichText2.AppendText("Contact Number" + vbTab + vbTab + TextBox1.Text + vbNewLine)
        RichText2.AppendText("Description" + vbTab + vbTab + vbTab + productdescription.Text + vbNewLine)
        RichText2.AppendText("Product Code" + vbTab + vbTab + productcode.Text + vbNewLine)
        RichText2.AppendText("Qty" + vbTab + vbTab + vbTab + vbTab + Qty.Text + vbNewLine)
        RichText2.AppendText("No of Days" + vbTab + vbTab + vbTab + cmbnodays.Text + vbNewLine)
        RichText2.AppendText("Amount dep" + vbTab + vbTab + vbTab + amountdep.Text + vbNewLine)
        RichText2.AppendText("Cost Per Day" + vbTab + vbTab + vbTab + costPerDay.Text + vbNewLine)
        RichText2.AppendText("Discount" + vbTab + vbTab + vbTab + productdescription.Text + vbNewLine)
        RichText2.AppendText("Method of payment" + vbTab + paymentmethod.Text + vbNewLine)
        RichText2.AppendText("Tax" + vbTab + vbTab + vbTab + vbTab + tax.Text + vbNewLine)
        RichText2.AppendText("Sub Total" + vbTab + vbTab + vbTab + subtotal.Text + vbNewLine)
        RichText2.AppendText("Total" + vbTab + vbTab + vbTab + vbTab + totalcost.Text + vbNewLine)
        RichText2.AppendText("Order Date" + vbTab + vbTab + vbTab + DateTimePicker1.Text + vbNewLine)
        RichText2.AppendText("due date" + vbTab + vbTab + vbTab + DateTimePicker3.Text + vbNewLine)
        RichText2.AppendText("late returns" + vbTab + vbTab + vbTab + DateTimePicker2.Text)



































    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles costPerDay.TextChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub settlediscount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles settlediscount.SelectedIndexChanged

    End Sub

    Private Sub Panel1_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub






    Private Sub cmbnodays_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbnodays.SelectedIndexChanged
        settledue.Text = Val(cmbnodays.Text)

        Dim r As Integer = Val(cmbnodays.Text)
        DateTimePicker2.Value = DateTimePicker2.Value.AddDays(r / 2)
        DateTimePicker3.Value = DateTimePicker3.Value.AddDays(r / 4)


        If Val(cmbnodays.Text <= 59) Then
            creditlimit.Text = "10"
            settlediscount.Text = "0"

        ElseIf Val(cmbnodays.Text <= 117) Then
            creditlimit.Text = "20"
            settlediscount.Text = "5"

        ElseIf Val(cmbnodays.Text <= 175) Then
            creditlimit.Text = "30"
            settlediscount.Text = "10"

        ElseIf Val(cmbnodays.Text <= 233) Then
            creditlimit.Text = "40"
            settlediscount.Text = "15"

        ElseIf Val(cmbnodays.Text <= 291) Then
            creditlimit.Text = "50 "
            settlediscount.Text = "20"

        ElseIf Val(cmbnodays.Text <= 349) Then
            creditlimit.Text = "50"
            settlediscount.Text = "25"



        End If







    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim family = New Form2
        family.Show()
        ' Me.Hide()

    End Sub

    Private Sub HelpMenu_Click(sender As Object, e As EventArgs) Handles HelpMenu.Click

    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()


    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub



    Private Class RichTextBox1
    End Class

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into register values( '" + productdescription.SelectedItem + "','" + productcode.Text + "','" + settledue.Text + "','" + costPerDay.Text + "','" + creditlimit.Text + "','" + Credit.Text + "','" + Customername.Text + "','" + paymentoverdue.Text + "','" + settlediscount.Text + "','" + depositpaid.Text + "','" + paymentmethod.Text + "','" + Qty.Text + "','" + tax.Text + "','" + subtotal.Text + "','" + totalcost.Text + "')"
        cmd.ExecuteNonQuery()


        MessageBox.Show("information has been inserted successfully")





        '                                "



    End Sub










    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        PrintDocument1.PrinterSettings.Copies = 1
        PrintDocument1.Print()





    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        SaveFileDialog1.Filter = "Txt Files(*.txt)|*.txt"

        If SaveFileDialog1.ShowDialog <> Me.DialogResult.Cancel Then

            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, RichText2.Text, True)








        End If
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(RichText2.Text, RichText2.Font, Brushes.Blue, 100, 100)


    End Sub

    Private Sub RichText2_TextChanged(sender As Object, e As EventArgs) Handles RichText2.TextChanged

    End Sub

    Private Sub amountdep_TextChanged(sender As Object, e As EventArgs) Handles amountdep.TextChanged

    End Sub

    Private Sub Customername_TextChanged(sender As Object, e As EventArgs) Handles Customername.TextChanged

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub
End Class
