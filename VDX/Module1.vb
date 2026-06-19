Imports System.IO
Imports System.Windows.Forms

Module Module1
    Sub Main()
        Console.Title = "VDX Output"
        Console.WriteLine("==========================")
        Console.WriteLine("VDXO - Virtual Doc XP Output v1.0")
        Console.WriteLine("==========================")
        Console.WriteLine("Program started...")
        Console.WriteLine()

        Dim vd As New Vdx
        vd.VdxStart()

        Console.WriteLine()
        Console.WriteLine("Program finished. Press any key to exit...")
        Console.ReadKey()
    End Sub

    Public Class Vdx
        Public Property VdxPath As String
        Public Property IsActive As Boolean

        Public Sub VdxStart()
            Try
                Console.WriteLine("VdxStart() method called...")

                IsActive = True
                Console.WriteLine("IsActive set to: " & IsActive.ToString())

                Console.WriteLine("Waiting for user input...")
                Dim vdx = InputBox("Enter VDX path: ", "VDX")
                Console.WriteLine("User entered: '" & vdx & "'")

                If vdx = "" Then
                    Console.WriteLine("ERROR: Path is empty!")
                    MsgBox("This field cannot be empty!")
                    Return
                End If

                VdxPath = vdx
                Console.WriteLine("Path saved to VdxPath property: " & VdxPath)

                Console.WriteLine("Creating form instance...")
                Dim vdFr As New VdxForm
                Console.WriteLine("Form instance created successfully!")

                Console.WriteLine("Setting form controls...")
                vdFr.Label1.Text = "Is Active: " & IsActive.ToString()
                Console.WriteLine("Label1 set to: " & vdFr.Label1.Text)

                vdFr.Label2.Text = "Path: " & VdxPath
                Console.WriteLine("Label2 set to: " & vdFr.Label2.Text)

                vdFr.VdxFilePath = VdxPath
                vdFr.IsActive = IsActive
                Console.WriteLine("VdxFilePath property set to: " & vdFr.VdxFilePath)

                Console.WriteLine("Showing form...")
                vdFr.ShowDialog()

                Console.WriteLine("Form was closed by user.")

            Catch ex As Exception
                Console.WriteLine("ERROR OCCURRED: " & ex.Message)
                Console.WriteLine("Stack Trace: " & ex.StackTrace)
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Sub
    End Class
End Module