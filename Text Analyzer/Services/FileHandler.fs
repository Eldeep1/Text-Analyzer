module FileHandler

open System.IO
open System.Windows.Forms

let loadFileIntoTextBox (textBox: TextBox) =
    use openFileDialog = new OpenFileDialog(Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*")
    if openFileDialog.ShowDialog() = DialogResult.OK then
        textBox.Text <- File.ReadAllText(openFileDialog.FileName)
