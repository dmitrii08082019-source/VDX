Imports System.IO
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class VdxForm
    Public Property VdxFilePath As String
    Public IsActive As Boolean = True

    ' История навигации
    Private navigationHistory As New List(Of String)()
    Private currentHistoryIndex As Integer = -1

    Private Sub VdxForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Центрируем форму
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Настраиваем колонки ListView
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True

        ' Добавляем начальный путь в историю
        If Not String.IsNullOrEmpty(VdxFilePath) Then
            AddToHistory(VdxFilePath)
            LoadDirectoryContents(VdxFilePath)
        End If

        ' Обновляем состояние кнопок
        UpdateNavigationButtons()

        Console.WriteLine("VdxForm loaded successfully!")
    End Sub

    Private Sub AddToHistory(ByVal path As String)
        ' Если мы не в конце истории, обрезаем будущие записи
        If currentHistoryIndex < navigationHistory.Count - 1 Then
            navigationHistory.RemoveRange(currentHistoryIndex + 1, navigationHistory.Count - currentHistoryIndex - 1)
        End If

        ' Добавляем путь в историю
        navigationHistory.Add(path)
        currentHistoryIndex = navigationHistory.Count - 1

        UpdateNavigationButtons()
    End Sub

    Private Sub UpdateNavigationButtons()
        ButtonBack.Enabled = (currentHistoryIndex > 0)
        ButtonForward.Enabled = (currentHistoryIndex < navigationHistory.Count - 1)
    End Sub

    Private Sub LoadDirectoryContents(ByVal path As String)
        Try
            ' Очищаем ListView
            ListView1.Items.Clear()

            ' Проверяем, что путь существует
            If Not Directory.Exists(path) Then
                Label1.Text = "Is Active: " & IsActive.ToString() & " | Path not found!"
                Return
            End If

            ' Обновляем Label2
            Label2.Text = "Path: " & path
            VdxFilePath = path

            ' Получаем все директории и файлы
            Dim directories As String() = Directory.GetDirectories(path)
            Dim files As String() = Directory.GetFiles(path)

            ' Устанавливаем прогресс
            ProgressBar1.Maximum = directories.Length + files.Length
            ProgressBar1.Value = 0

            ' Добавляем папки
            For Each dir As String In directories
                Dim dirInfo As New DirectoryInfo(dir)
                Dim item As New ListViewItem(dirInfo.Name)
                item.SubItems.Add("Folder")
                item.SubItems.Add(dirInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm"))
                item.SubItems.Add("Yes")
                item.Tag = dir
                ListView1.Items.Add(item)
                ProgressBar1.Value += 1
                Application.DoEvents()
            Next

            ' Добавляем файлы
            For Each file As String In files
                Dim fileInfo As New FileInfo(file)
                Dim item As New ListViewItem(fileInfo.Name)
                item.SubItems.Add("File")
                item.SubItems.Add(fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm"))
                item.SubItems.Add("Yes")
                item.Tag = file
                ListView1.Items.Add(item)
                ProgressBar1.Value += 1
                Application.DoEvents()
            Next

            ' Обновляем статус
            Label1.Text = "Is Active: " & IsActive.ToString() & " | Items: " & ListView1.Items.Count

        Catch ex As Exception
            MsgBox("Error loading directory: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ' Кнопка "Check Path"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(VdxFilePath) Then
            MsgBox("Path is not specified!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        If Directory.Exists(VdxFilePath) Then
            MsgBox("✓ Directory exists!" & vbCrLf & "Path: " & VdxFilePath,
                   MsgBoxStyle.Information, "Result")
            AddToHistory(VdxFilePath)
            LoadDirectoryContents(VdxFilePath)
        ElseIf File.Exists(VdxFilePath) Then
            MsgBox("✓ File exists!" & vbCrLf & "Path: " & VdxFilePath,
                   MsgBoxStyle.Information, "Result")
        Else
            MsgBox("✗ Path not found!" & vbCrLf & "Path: " & VdxFilePath,
                   MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    ' Кнопка "Назад" (<)
    Private Sub ButtonBack_Click(sender As Object, e As EventArgs) Handles ButtonBack.Click
        If currentHistoryIndex > 0 Then
            currentHistoryIndex -= 1
            Dim path As String = navigationHistory(currentHistoryIndex)
            VdxFilePath = path
            LoadDirectoryContents(path)
            UpdateNavigationButtons()
        End If
    End Sub

    ' Кнопка "Вперед" (>)
    Private Sub ButtonForward_Click(sender As Object, e As EventArgs) Handles ButtonForward.Click
        If currentHistoryIndex < navigationHistory.Count - 1 Then
            currentHistoryIndex += 1
            Dim path As String = navigationHistory(currentHistoryIndex)
            VdxFilePath = path
            LoadDirectoryContents(path)
            UpdateNavigationButtons()
        End If
    End Sub

    ' Кнопка "New" - создание новой папки или файла
    Private Sub ButtonNew_Click(sender As Object, e As EventArgs) Handles ButtonNew.Click
        If String.IsNullOrEmpty(VdxFilePath) OrElse Not Directory.Exists(VdxFilePath) Then
            MsgBox("Current path is not valid!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        Dim choice As Integer = MsgBox("Click YES to create a Folder, NO to create a File, CANCEL to abort.",
                                       MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question, "Create New")

        If choice = MsgBoxResult.Cancel Then
            Return
        End If

        Dim name As String = InputBox("Enter name for new item:", "Create New")

        If String.IsNullOrEmpty(name) Then
            MsgBox("Name cannot be empty!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        Try
            Dim fullPath As String = Path.Combine(VdxFilePath, name)

            If choice = MsgBoxResult.Yes Then
                ' Создаем папку
                Directory.CreateDirectory(fullPath)
                MsgBox("✓ Folder created successfully!", MsgBoxStyle.Information, "Success")
            Else
                ' Создаем файл
                If File.Exists(fullPath) Then
                    MsgBox("File already exists!", MsgBoxStyle.Exclamation, "Error")
                    Return
                End If
                File.Create(fullPath).Close()
                MsgBox("✓ File created successfully!", MsgBoxStyle.Information, "Success")
            End If

            ' Обновляем содержимое
            LoadDirectoryContents(VdxFilePath)

        Catch ex As Exception
            MsgBox("Error creating item: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ' Кнопка "Delete" - удаление выбранного элемента
    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Please select an item to delete!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)
        Dim fullPath As String = selectedItem.Tag.ToString()

        Dim confirm As Integer = MsgBox("Are you sure you want to delete:" & vbCrLf & vbCrLf &
                                        fullPath & vbCrLf & vbCrLf &
                                        "This action cannot be undone!",
                                        MsgBoxStyle.YesNo Or MsgBoxStyle.Critical Or MsgBoxStyle.DefaultButton2,
                                        "Confirm Delete")

        If confirm = MsgBoxResult.No Then
            Return
        End If

        Try
            If Directory.Exists(fullPath) Then
                ' Удаляем папку со всем содержимым
                Directory.Delete(fullPath, True)
                MsgBox("✓ Folder deleted successfully!", MsgBoxStyle.Information, "Success")
            ElseIf File.Exists(fullPath) Then
                ' Удаляем файл
                File.Delete(fullPath)
                MsgBox("✓ File deleted successfully!", MsgBoxStyle.Information, "Success")
            Else
                MsgBox("Item no longer exists!", MsgBoxStyle.Exclamation, "Error")
                Return
            End If

            ' Обновляем содержимое
            LoadDirectoryContents(VdxFilePath)

        Catch ex As Exception
            MsgBox("Error deleting item: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ' Двойной клик по элементу ListView
    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)
            Dim fullPath As String = selectedItem.Tag.ToString()

            If Directory.Exists(fullPath) Then
                ' Если папка - открываем её
                VdxFilePath = fullPath
                AddToHistory(fullPath)
                LoadDirectoryContents(fullPath)
            ElseIf File.Exists(fullPath) Then
                ' Если файл - спрашиваем, что делать
                Dim choice As Integer = MsgBox("Open file in Explorer?" & vbCrLf & vbCrLf & fullPath,
                                               MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "File Selected")
                If choice = MsgBoxResult.Yes Then
                    Process.Start("explorer.exe", "/select,""" & fullPath & """")
                End If
            End If
        End If
    End Sub

    ' Обработка клавиш
    Private Sub VdxForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.Z Then
            ' Ctrl+Z = Back
            ButtonBack.PerformClick()
            e.Handled = True
        ElseIf e.Control AndAlso e.KeyCode = Keys.Y Then
            ' Ctrl+Y = Forward
            ButtonForward.PerformClick()
            e.Handled = True
        ElseIf e.KeyCode = Keys.Delete Then
            ' Delete = Delete selected item
            ButtonDelete.PerformClick()
            e.Handled = True
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            ' Ctrl+N = New
            ButtonNew.PerformClick()
            e.Handled = True
        End If
    End Sub

    ' Обработчик нажатия Enter на элементе ListView
    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ListView1_DoubleClick(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub ButtonNewVdx_Click(sender As Object, e As EventArgs) Handles ButtonNewVdx.Click
        If String.IsNullOrEmpty(VdxFilePath) OrElse Not Directory.Exists(VdxFilePath) Then
            MsgBox("Current path is not valid!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        ' Запрашиваем имя VDX файла
        Dim vdxName As String = InputBox("Enter VDX file name (without extension):", "Create New VDX", "Document")

        If String.IsNullOrEmpty(vdxName) Then
            MsgBox("Name cannot be empty!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        ' Добавляем расширение .vdx если его нет
        If Not vdxName.EndsWith(".vdx", StringComparison.OrdinalIgnoreCase) Then
            vdxName &= ".vdx"
        End If

        Try
            Dim fullPath As String = Path.Combine(VdxFilePath, vdxName)

            ' Проверяем, не существует ли уже такой файл
            If File.Exists(fullPath) Then
                Dim overwrite As Integer = MsgBox("File already exists!" & vbCrLf & vbCrLf &
                                              fullPath & vbCrLf & vbCrLf &
                                              "Do you want to overwrite it?",
                                              MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2,
                                              "File Exists")
                If overwrite = MsgBoxResult.No Then
                    Return
                End If
            End If

            ' Создаем пустой VDX файл
            File.Create(fullPath).Close()

            MsgBox("✓ VDX file created successfully!" & vbCrLf & vbCrLf & fullPath,
               MsgBoxStyle.Information, "Success")

            ' Обновляем содержимое
            LoadDirectoryContents(VdxFilePath)

        Catch ex As Exception
            MsgBox("Error creating VDX file: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub
End Class