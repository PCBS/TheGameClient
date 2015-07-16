Imports System.IO

Public Class Form1
    Structure pc
        Dim mb As hardware_pcbsDataSet.MBRow
        Dim cpu As hardware_pcbsDataSet.CPURow
        Dim gpu() As DataRow
        Dim ram() As DataRow
        Dim hdd As hardware_pcbsDataSet.HDDRow
        Dim psu As hardware_pcbsDataSet.PSURow
        Public ReadOnly Property vykon As Integer
            Get
                Return CInt(GetVykon(mb.idveci, cpu.idveci, id(gpu), id(ram), hdd.idveci, psu.idveci))
            End Get
        End Property

    End Structure

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RAMTableAdapter.Fill(Me.Hardware_pcbsDataSet.RAM)
        Me.PSUTableAdapter.Fill(Me.Hardware_pcbsDataSet.PSU)
        Me.MBTableAdapter.Fill(Me.Hardware_pcbsDataSet.MB)
        Me.HDDTableAdapter.Fill(Me.Hardware_pcbsDataSet.HDD)
        Me.GPUTableAdapter.Fill(Me.Hardware_pcbsDataSet.GPU)
        Me.CPUTableAdapter.Fill(Me.Hardware_pcbsDataSet.CPU)
        Me.VeciTableAdapter1.Fill(Me.Hardware_pcbsDataSet.veci)
        Me.ReceptyTableAdapter1.Fill(Me.Hardware_pcbsDataSet.recepty)
    End Sub

    Private Sub VsechnyKompy()
        Dim rr As New StreamWriter("C:\temp\kompy.csv", False)
        'Try
        With Me.Hardware_pcbsDataSet
            For Each mb As hardware_pcbsDataSet.MBRow In .MB
                For Each cpu As hardware_pcbsDataSet.CPURow In .CPU.Select("socket='" & mb.socket & "'")
                    For Each gpu() As DataRow In SelectMore(.GPU, mb.sloty.Split(";")(0))
                        For Each ram() As DataRow In SelectMore(.RAM, mb.sloty.Split(";")(1))
                            For Each hdd As hardware_pcbsDataSet.HDDRow In .HDD
                                For Each psu As hardware_pcbsDataSet.PSURow In .PSU
                                    Dim vykon = CInt(GetVykon(mb.idveci, cpu.idveci, id(gpu), id(ram), hdd.idveci, psu.idveci))
                                    If vykon > 0 Then
                                        Dim komp As New pc
                                        komp.mb = mb
                                        komp.cpu = cpu
                                        komp.gpu = gpu
                                        komp.ram = ram
                                        komp.hdd = hdd
                                        komp.psu = psu

                                    End If
                                    Button1.Text = Long.Parse(Button1.Text) + 1
                                    Application.DoEvents()
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        End With
        'Catch ex As Exception
        '    MsgBox(Err.Number & " - " & Err.Description, MsgBoxStyle.Critical, ex.ToString)
        'End Try
        rr.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        VsechnyKompy()
        Button1.Enabled = True
    End Sub

    Public Function GetTree(id As Integer, count As Integer) As TreeNode
        Dim node As New TreeNode(count & " " & Me.Hardware_pcbsDataSet.veci(id).nazev)
        Dim suroviny() As String = GetRecept(id)
        If suroviny.Length > 0 Then
            For i As Integer = 0 To suroviny.Length - 1
                If suroviny(i) > 0 Then
                    node.Nodes.Add(GetTree(i, count * suroviny(i)))
                End If
            Next
        End If
        Return node
    End Function

    Public Function GetRecept(id As Integer) As String()
        Dim request = Me.Hardware_pcbsDataSet.recepty.Select("vyrobek=" & id)
        If request.Length > 0 Then
            Return request(0)("suroviny").split(";")
        Else
            Dim retur() As String = {}
            Return retur
        End If
    End Function

    Public Function GetItemInfo(id As Integer) As TheGame.hardware_pcbsDataSet.veciRow
        Return Me.Hardware_pcbsDataSet.veci.Select("idveci=" & id).FirstOrDefault()
    End Function

    Public Function GetItemInfo(id As Integer, type As String) As TheGame.hardware_pcbsDataSet.veciRow
        Return Me.Hardware_pcbsDataSet.veci.Select("idveci=" & id & " AND typ='" & type & "'").First()
    End Function

    Public Function GetVykon(imb As Integer, icpu As Integer, igpu() As Integer, iram() As Integer, ihdd As Integer, ipsu As Integer) As Decimal
        Dim spotreba As Integer = 0
        'Motherboard
        Dim mb As TheGame.hardware_pcbsDataSet.veciRow = GetItemInfo(imb, "mb")
        spotreba += mb.spotreba
        'CPU
        Dim cpu As TheGame.hardware_pcbsDataSet.veciRow = GetItemInfo(icpu, "cpu")
        spotreba += cpu.spotreba
        'GPU
        Dim gpu(igpu.Count) As TheGame.hardware_pcbsDataSet.veciRow
        Dim gpupow As Decimal = 0
        For i As Integer = 0 To igpu.Count - 1
            gpu(i) = GetItemInfo(igpu(i), "gpu")
            gpupow += gpu(i).vykon
            spotreba += gpu(i).spotreba
        Next
        gpupow *= Math.Pow(0.9, gpu.Count)
        'RAM
        Dim ram(iram.Count) As TheGame.hardware_pcbsDataSet.veciRow
        Dim ramkap As Integer = 0
        For i As Integer = 0 To iram.Count - 1
            ram(i) = GetItemInfo(iram(i), "ram")
            ramkap += ram(i).vykon
            spotreba += ram(i).spotreba
        Next
        Dim rampow As Decimal = GetVykonRAM(ramkap)
        'HDD
        Dim hdd As TheGame.hardware_pcbsDataSet.veciRow = GetItemInfo(ihdd, "hdd")
        Dim hddpow As Decimal = GetVykonHDD(hdd.vykon)
        spotreba += hdd.spotreba
        'PSU
        Dim psu As TheGame.hardware_pcbsDataSet.veciRow = GetItemInfo(ipsu, "psu")
        'Vykon
        Dim vykon = Math.Min(cpu.vykon, gpupow) * 2 * rampow * hddpow
        If mb.sloty.Split(";")(0) < ram.Count Then vykon = 0
        If mb.sloty.Split(";")(1) < gpu.Count Then vykon = 0
        If psu.vykon < spotreba * 1.1 Then vykon = 0
        If Not mb.socket = cpu.socket Then vykon = 0
        Return vykon
    End Function

    Public Function GetVykonRAM(ramkap As Integer) As Decimal
        Select Case ramkap
            Case Is >= 64
                Return 2.0
            Case Is >= 32
                Return 1.8
            Case Is >= 24
                Return 1.6
            Case Is >= 16
                Return 1.4
            Case Is >= 12
                Return 1.2
            Case Is >= 8
                Return 1.0
            Case Is >= 6
                Return 0.8
            Case Is >= 4
                Return 0.6
            Case Is >= 2
                Return 0.4
            Case Is >= 1
                Return 0.2
            Case Else
                Return 0
        End Select
    End Function

    Public Function GetVykonHDD(hddvyk As Integer) As Decimal
        Select Case hddvyk
            Case 1
                Return 0.2
            Case 2
                Return 0.4
            Case 3
                Return 0.6
            Case 4
                Return 0.8
            Case 64
                Return 1.0
            Case 128
                Return 1.2
            Case 256
                Return 1.4
            Case 512
                Return 1.6
            Case 1024
                Return 1.8
            Case 2048
                Return 1.0
            Case Else
                Return 0
        End Select
    End Function

    Public Function SelectMore(table As DataTable, count As Integer) As DataRow()()
        If count > 1 Then
            Dim VyberMin = SelectMore(table, count - 1)
            Dim vysledek As New List(Of DataRow())(table.Rows.Count * VyberMin.Length)
            For i As Integer = 0 To table.Rows.Count - 1
                For y As Integer = 0 To VyberMin.Length - 1
                    Dim seznam(VyberMin(y).Length) As DataRow
                    seznam(0) = table.Rows(i)
                    For x As Integer = 1 To VyberMin(i).Length
                        seznam(x) = VyberMin(y)(x - 1)
                    Next
                    vysledek.Add(seznam)
                Next
            Next
            Return vysledek.ToArray
        ElseIf count = 1 Then
            Dim vysledek As New List(Of DataRow())(table.Rows.Count)
            For i As Integer = 0 To table.Rows.Count - 1
                vysledek.Add({table.Rows(i)})
            Next
            Return vysledek.ToArray
        Else
            Throw New ArgumentOutOfRangeException("count")
        End If
    End Function

    Public Function id(p1() As DataRow) As Integer()
        Dim vysl(p1.Length - 1) As Integer
        For i As Integer = 0 To p1.Length - 1
            vysl(i) = p1(i)("idveci")
        Next
        Return vysl
    End Function

End Class
