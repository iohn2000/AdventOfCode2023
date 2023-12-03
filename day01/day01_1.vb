Imports System.IO
Public Class Day1 : Implements IAoCDay
    Private Sum As Integer = 0
    Public Sub Run(filePath As String) Implements IAoCDay.Run
        Using day1File As StreamReader = File.OpenText(filePath)
            Dim lineOfText As String, firstNr, lastNr As (Integer, Integer)
            Do
                Dim numberFirst, numberLast As String
                lineOfText = day1File.ReadLine()
                If lineOfText = Nothing Then Exit Do
                firstNr = FindFirstNr(lineOfText)
                lastNr = FindFirstNr(StrReverse(lineOfText), True)
                Dim nameResult = Me.FindNrName(lineOfText)
                If firstNr.Item1 < nameResult.Item1.Pos Then numberFirst = firstNr.Item2 Else numberFirst = Me.ConvertToNumber(nameResult.Item1.Name)
                If lastNr.Item1 > nameResult.Item2.Pos Then numberLast = lastNr.Item2 Else numberLast = Me.ConvertToNumber(nameResult.Item2.Name)
                If numberFirst + numberLast >= 0 Then Sum += Integer.Parse(numberFirst.ToString + numberLast.ToString)
            Loop Until lineOfText = Nothing
        End Using
        Console.WriteLine(Sum)
    End Sub
    Private Function FindFirstNr(lineOfText As String, Optional isReverse As Boolean = False) As (Integer, Integer)
        For index As Integer = 0 To lineOfText.Length - 1 Step 1
            Dim n As Integer, c = lineOfText(index)
            If Integer.TryParse(c, n) = True Then
                If isReverse Then index = lineOfText.Length - index - 1
                Return (index, n)
            End If
        Next
        Return (-1, -1)
    End Function
    Private Function FindNrName(lineOfText As String) As (NrNameResult, NrNameResult)
        Dim nrNames As New List(Of String)({"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"})
        Dim earliestPos As Integer = lineOfText.Length, latestPos As Integer = -1
        Dim earliestNrName As String = String.Empty, latestNrName As String = String.Empty
        nrNames.ForEach(Sub(name As String)
                            Dim idxFirst As Integer = lineOfText.IndexOf(name)
                            Dim idxLast As Integer = lineOfText.LastIndexOf(name)

                            If idxFirst <> -1 AndAlso idxFirst < earliestPos Then
                                earliestPos = idxFirst
                                earliestNrName = name
                            End If

                            If idxLast <> -1 AndAlso idxLast > latestPos Then
                                latestPos = idxLast
                                latestNrName = name
                            End If
                        End Sub)
        Return (New NrNameResult With {.Pos = earliestPos, .Name = earliestNrName}, New NrNameResult With {.Pos = latestPos, .Name = latestNrName})
    End Function

    Private Function ConvertToNumber(letters As String) As Integer
        Select Case letters
            Case "one" : Return 1
            Case "two" : Return 2
            Case "three" : Return 3
            Case "four" : Return 4
            Case "five" : Return 5
            Case "six" : Return 6
            Case "seven" : Return 7
            Case "eight" : Return 8
            Case "nine" : Return 9
            Case Else : Return -1
        End Select
    End Function
End Class
Public Class NrNameResult
    Public Property Pos As Integer
    Public Property Name As String
End Class
