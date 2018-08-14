Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace CardCustomLayoutTemplateExample
    Public NotInheritable Class DataGenerator

        Private Sub New()
        End Sub

        Public Shared Function GenerateTestData() As Object
            Dim data As IList(Of DataRow) = New List(Of DataRow)()
            Dim rand As New Random(Date.Now.Second)

            Dim countries = New String() { "USA", "Canada", "Argentina", "Brazil" }
            For Each country As String In countries
                For i As Integer = 0 To 99
                    data.Add(New DataRow With { _
                        .Country = country, _
                        .Sales = rand.NextDouble() * 100 * i, _
                        .SalesTarget = rand.NextDouble()* 100 * i, _
                        .SalesDate = Date.Now.AddDays(((If(i Mod 2 = 0, -1, 1)) * i) + rand.Next(10, 40)) _
                    })
                Next i
            Next country
            Return data
        End Function
    End Class
    Public Class DataRow
        Public Property Country() As String
        Public Property Sales() As Double
        Public Property SalesTarget() As Double
        Public Property SalesDate() As Date
    End Class
End Namespace
