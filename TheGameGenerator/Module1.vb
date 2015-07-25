Module Module1
    Dim trh As New TheGameGenerator.trhDataSetTableAdapters.veciTableAdapter()
    Dim waittime As trhDataSet.veciRow
    Sub Main()
        Console.Title = 0
        trh.Fill((New trhDataSet).veci)
        Dim veci As trhDataSet.veciDataTable = trh.GetData()
        Dim GPUdict As List(Of trhDataSet.veciRow()) = GenerateGPUList(veci)
        Parallel.ForEach(Of trhDataSet.veciRow)(veci.Select("typ='mb'"), Sub(mb As trhDataSet.veciRow)
                                                                             For Each cpu As trhDataSet.veciRow In veci.Select("socket='" & mb.socket & "'")
                                                                                 For Each gpu() As trhDataSet.veciRow In SelectGPUs(GPUdict, mb, cpu)
                                                                                     For Each ramkap As Integer In {1, 2, 4, 6, 8, 12, 14, 16, 24, 32, 64}
                                                                                         For Each hddvyk As Integer In {1, 2, 3, 4, 8, 16, 32, 64, 128, 256}
                                                                                             Dim spotreba As Integer = 0
                                                                                             Dim psu As trhDataSet.veciRow = veci.Select("typ='psu' AND vykon>'" & spotreba * 1.1 & "'", "vykon ASC").First
                                                                                             Dim vykon = CInt(GetVykon(mb, cpu, gpu, ramkap, hddvyk, psu))
                                                                                             If vykon > 0 Then
                                                                                                 'Console.WriteLine(vykon & " - " & String.Join(",   ", cpu.nazev, gpu.nazev, ram.nazev, hdd.nazev, psu.nazev))
                                                                                             End If
                                                                                             Console.Title = Long.Parse(Console.Title) + 1
                                                                                         Next
                                                                                     Next
                                                                                 Next
                                                                             Next
                                                                         End Sub)
        Console.ReadKey()

    End Sub

    Public Function GetVykon(mb As trhDataSet.veciRow, cpu As trhDataSet.veciRow, gpu() As trhDataSet.veciRow, ram() As trhDataSet.veciRow, hdd As trhDataSet.veciRow, psu As trhDataSet.veciRow) As Decimal
        Dim gpupow As Decimal = 0
        For i As Integer = 0 To gpu.Count - 1
            gpu(i) = GetItemInfo(igpu(i), "gpu")
            gpupow += gpu(i).vykon
            spotreba += gpu(i).spotreba
        Next
        gpupow *= Math.Pow(0.9, gpu.Count)
        'RAM
        Dim ram(iram.Count) As TheGame.trhDataSet.veciRow
        Dim ramkap As Integer = 0
        For i As Integer = 0 To iram.Count - 1
            ram(i) = GetItemInfo(iram(i), "ram")
            ramkap += ram(i).vykon
            spotreba += ram(i).spotreba
        Next
        Dim rampow As Decimal = GetVykonRAM(ramkap)
        'HDD
        Dim hdd As TheGame.trhDataSet.veciRow = GetItemInfo(ihdd, "hdd")
        Dim hddpow As Decimal = GetVykonHDD(hdd.vykon)
        spotreba += hdd.spotreba
        'PSU
        Dim psu As TheGame.trhDataSet.veciRow = GetItemInfo(ipsu, "psu")
        'vykon
        Dim vykon = cpu.vykon ' Math.Min(cpu.vykon, gpupow) * 2 * rampow * hddpow
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

    Private Function GenerateGPUList(veci As trhDataSet.veciDataTable) As List(Of trhDataSet.veciRow())
        Throw New NotImplementedException
    End Function

    Private Function SelectGPUs(GPUdict As List(Of trhDataSet.veciRow()), mb As trhDataSet.veciRow, cpu As trhDataSet.veciRow) As Object
        Throw New NotImplementedException
    End Function

    Private Function GetCost(id As Integer, veci As trhDataSet.veciDataTable, recepty As trhDataSet.receptyDataTable)
        Throw New NotImplementedException
        Dim recept = GetRecept(id, recepty)

    End Function

    Private Function GetCost(ParamArray ids() As Integer)
        Dim cost = 0
        For Each id In ids
            cost += GetCost(id)
        Next
        Return cost
    End Function

    Public Function GetRecept(id As Integer, recepty As trhDataSet.receptyDataTable) As Dictionary(Of Integer, Integer)
        Dim request() As trhDataSet.receptyRow = recepty.Select("vyrobek=" & id)
        If request.Length > 0 Then
            Dim dict As New Dictionary(Of Integer, Integer)
            Dim suroviny = request(0).suroviny.Split(";")
            For i As Integer = 0 To suroviny.Length - 1
                If suroviny(i) > 0 Then dict.Add(i, suroviny(i))
            Next
            Return dict
        Else
            Return Nothing
        End If
    End Function

End Module
