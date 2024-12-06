open System
open System.Windows.Forms
open Home

[<STAThread>]
[<EntryPoint>]
let main argv =
    let form = Home.createMainForm()
    Application.Run(form)
    0
