// Learn more about F# at http://fsharp.org

open System
open Terminal.Gui.Elmish
module Sample =
  type Model = {Value:int}
  type Msg =
    |Inc
    |Dec
    |Quit
  let init () = {Value=0}, Cmd.none
  let update msg (model:Model) =
    match msg with
    | Inc -> {model with Value = model.Value + 1}, Cmd.none
    | Dec -> {model with Value = model.Value - 1}, Cmd.none
    | Quit ->
      // does not work
      Terminal.Gui.Application.RequestStop() //Program.Quit();
      model, Cmd.none
  let view model dispatch =
    page [

      window[
        Styles [
          Pos (PercentPos 20.0, PercentPos 10.0)
          Dim (PercentDim 30.0, AbsDim 15)
        ]
        Title <| sprintf "Demo %i" model.Value

      ] [
        button [
          Styles [
            Pos (AbsPos 1, AbsPos 1)
          ]
          Text "Counter Up"
          OnClicked (fun () -> dispatch Inc)
        ]
        button [
          Styles [
            Pos (AbsPos 1, AbsPos 2)
          ]
          Text "Counter Down"
          OnClicked (fun () -> dispatch Dec)
        ]
        button [
          Styles[
            Pos (AbsPos 1, AbsPos 3)
          ]
          Text "Quit"
          OnClicked (fun () -> dispatch Quit)
        ]

      ]
    ]

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    Program.mkProgram Sample.init Sample.update Sample.view
    |> Program.run

    0 // return an integer exit code
