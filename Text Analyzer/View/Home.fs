module Home

open System.Windows.Forms
open System.Drawing
open TextAnalysis
open FileHandler
open System

let createMainForm () =
    let form = new Form(Text = "Text Analyser", Width = 800, Height = 600)
    let label = new Label(Text = "Enter text", TextAlign = ContentAlignment.TopLeft)
    let textBox = new TextBox(Multiline = true, Width = 400, Height = 500)
    let uploadButton = new Button(Text = "Upload")
    let doneButton = new Button(Text = "Done")

    let mutable analysisResults = Map.empty

    uploadButton.Click.Add(fun _ -> 
        FileHandler.loadFileIntoTextBox textBox
    )

    doneButton.Click.Add(fun _ ->
        analysisResults <- TextAnalysis.analyzeText textBox.Text
        MessageBox.Show(sprintf "Analysis Complete. Results:\n%s" 
            (String.Join("\n", analysisResults |> Seq.map (fun kvp -> $"{kvp.Key}: {kvp.Value}")))) |> ignore
    )

    // Layout setup
    let tableLayoutPanel = new TableLayoutPanel(Dock = DockStyle.Fill)
    tableLayoutPanel.RowCount <- 3
    tableLayoutPanel.ColumnCount <- 3
    tableLayoutPanel.Controls.Add(label, 0, 0)
    tableLayoutPanel.Controls.Add(uploadButton, 1, 0)
    tableLayoutPanel.Controls.Add(doneButton, 2, 0)
    tableLayoutPanel.Controls.Add(textBox, 0, 1)
    tableLayoutPanel.SetColumnSpan(textBox, 2)
    form.Controls.Add(tableLayoutPanel)

    form
