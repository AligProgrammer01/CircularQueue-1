Imports System
' Code written by AligProgrammer
' Circular Queue that can hold 11 numbers
' version 1.0
Module Program
    Class Queue
        Private Const NullPointer As Integer = -1
        Private data(10) As Integer
        Private FrontQPtr As Integer
        Private RearQPtr As Integer

        Public Sub New()
            FrontQPtr = NullPointer
            RearQPtr = NullPointer

        End Sub


        Public Sub Enqueue(item As Integer)
            If isFull() = True Then
                Console.WriteLine("Queue is full!")
            Else
                If isEmpty() = True Then
                    FrontQPtr = 0
                    RearQPtr += 1
                    data(RearQPtr) = item
                    Console.WriteLine("Item enqueued successfully")
                Else
                    If RearQPtr = 10 And FrontQPtr > 0 Then
                        RearQPtr = 0
                        data(RearQPtr) = item
                        Console.WriteLine("Item enqueued successfully")
                    ElseIf RearQPtr < 10 Then
                        RearQPtr += 1
                        data(RearQPtr) = item
                        Console.WriteLine("Item enqueued successfully")
                    End If
                End If

            End If
        End Sub


        Public Function Dequeue() As Integer
            Dim temp As Integer
            If isEmpty() = True Then ' if queue is empty
                Console.WriteLine("Queue is empty!")
                Return NullPointer
            Else
                'Console.WriteLine(data(FrontQPtr))
                If FrontQPtr = 10 And RearQPtr <> 10 Then ' if rear before the front pointer
                    temp = FrontQPtr
                    FrontQPtr = 0
                    Return data(temp)

                ElseIf FrontQPtr = RearQPtr Then ' if last item of the queue
                    temp = FrontQPtr
                    FrontQPtr = NullPointer
                    RearQPtr = NullPointer
                    Return data(temp)
                Else ' any other case
                    temp = FrontQPtr
                    FrontQPtr += 1
                    Return data(temp)
                End If
            End If
        End Function


        Public Function isFull() As Boolean
            If FrontQPtr = 0 And RearQPtr = 10 Then
                Return True
            ElseIf FrontQPtr = RearQPtr + 1 Then
                Return True
            Else
                Return False
            End If
        End Function


        Public Function isEmpty() As Boolean
            If FrontQPtr = NullPointer Then
                Return True
            Else
                Return False
            End If
        End Function



    End Class
    Sub Main()
        Dim myqueue As New Queue()
        Dim userResponse As String
        Dim tempData As String

        While True
            Console.WriteLine("Choose a number: ")
            Console.WriteLine("1. Enqueue")
            Console.WriteLine("2. Dequeue")

            userResponse = Console.ReadLine()

            If userResponse = 1 Then
                Console.WriteLine("Enter the number you want to enqueue")
                tempData = Console.ReadLine()
                If IsNumeric(tempData) Then
                    myqueue.Enqueue(tempData)
                Else
                    Console.WriteLine("invalid entry")
                End If
            ElseIf userResponse = 2 Then
                Console.WriteLine(myqueue.Dequeue())
            Else
                Console.WriteLine("Invalid Option, enter again")
            End If

            Console.WriteLine("--------------------------")
        End While
    End Sub
End Module
