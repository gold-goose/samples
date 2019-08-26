﻿' The following code example creates SortedList instances using different constructors
' and demonstrates the differences in the behavior of the SortedList instances.

' <Snippet1>
Imports System.Collections
Imports System.Globalization

Public Class SamplesSortedList

    Public Shared Sub Main()

        ' Create the dictionary.
        Dim myHT As New Hashtable()
        myHT.Add("FIRST", "Hello")
        myHT.Add("SECOND", "World")
        myHT.Add("THIRD", "!")

        ' Create a SortedList using the default comparer.
        Dim mySL1 As New SortedList(myHT)
        Console.WriteLine("mySL1 (default):")
        Try
            mySL1.Add("first", "Ola!")
        Catch e As ArgumentException
            Console.WriteLine(e)
        End Try
        PrintKeysAndValues(mySL1)

        ' Create a SortedList using the specified case-insensitive comparer.
        Dim mySL2 As New SortedList(myHT, New CaseInsensitiveComparer())
        Console.WriteLine("mySL2 (case-insensitive comparer):")
        Try
            mySL2.Add("first", "Ola!")
        Catch e As ArgumentException
            Console.WriteLine(e)
        End Try
        PrintKeysAndValues(mySL2)

        ' Create a SortedList using the specified CaseInsensitiveComparer,
        ' which is based on the Turkish culture (tr-TR), where "I" is not
        ' the uppercase version of "i".
        Dim myCul As New CultureInfo("tr-TR")
        Dim mySL3 As New SortedList(myHT, New CaseInsensitiveComparer(myCul))
        Console.WriteLine("mySL3 (case-insensitive comparer, Turkish culture):")
        Try
            mySL3.Add("first", "Ola!")
        Catch e As ArgumentException
            Console.WriteLine(e)
        End Try
        PrintKeysAndValues(mySL3)

        ' Create a SortedList using the 
        ' StringComparer.InvariantCultureIgnoreCase value.
        Dim mySL4 As New SortedList(myHT, StringComparer.InvariantCultureIgnoreCase)
        Console.WriteLine("mySL4 (InvariantCultureIgnoreCase):")
        Try
            mySL4.Add("first", "Ola!")
        Catch e As ArgumentException
            Console.WriteLine(e)
        End Try
        PrintKeysAndValues(mySL4)

    End Sub 'Main

    Public Shared Sub PrintKeysAndValues(ByVal myList As SortedList)
        Console.WriteLine("        -KEY-   -VALUE-")
        Dim i As Integer
        For i = 0 To myList.Count - 1
            Console.WriteLine("        {0,-6}: {1}", _
                myList.GetKey(i), myList.GetByIndex(i))
        Next i
        Console.WriteLine()
    End Sub 'PrintKeysAndValues

End Class 'SamplesSortedList


'This code produces the following output.  Results vary depending on the system's culture settings.
'
'mySL1 (default):
'        -KEY-   -VALUE-
'        first : Ola!
'        FIRST : Hello
'        SECOND: World
'        THIRD : !
'
'mySL2 (case-insensitive comparer):
'System.ArgumentException: Item has already been added.  Key in dictionary: 'FIRST'  Key being added: 'first''   at System.Collections.SortedList.Add(Object key, Object value)
'   at SamplesSortedList.Main()
'        -KEY-   -VALUE-
'        FIRST : Hello
'        SECOND: World
'        THIRD : !
'
'mySL3 (case-insensitive comparer, Turkish culture):
'        -KEY-   -VALUE-
'        FIRST : Hello
'        first : Ola!
'        SECOND: World
'        THIRD : !
'
'mySL4 (InvariantCultureIgnoreCase):
'System.ArgumentException: Item has already been added.  Key in dictionary: 'FIRST'  Key being added: 'first''   at System.Collections.SortedList.Add(Object key, Object value)
'   at SamplesSortedList.Main()
'        -KEY-   -VALUE-
'        FIRST : Hello
'        SECOND: World
'        THIRD : !

' </Snippet1>
