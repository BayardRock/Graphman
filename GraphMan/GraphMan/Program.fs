namespace GraphMan

open GraphMan.Common
open GraphMan.Common.Library
open GraphMan.Common.Types
open GraphMan.Drawing
open GraphMan.Resources

open System
open System.IO
open System.Threading
open System.Windows.Forms

module Program =
  //TODO: draw poster frame onto display
  //TODO: check for memory leaks on buffer image
  //TODO: enable game interrupt
  //TODO: enable game reset

  let playGame (viewer:GameViewer) (playerAI:PlayerAI) gameState =
    use buffer = prepareBuffer gameState
    let render = renderFrame buffer
    viewer.gamePicture.Image <- buffer

    let rec loop gameState =
      Application.DoEvents()
    
      if viewer.Visible && not <| checkLevelComplete gameState then
        let gameState = advanceOneTurn playerAI gameState
        viewer.scoreText.Text <- string gameState.PlayerScore
        render gameState
        Thread.Sleep(int viewer.throttleUpDown.Value)
        viewer.Invalidate(true)
        loop gameState
    
    loop gameState

  let rec configureApp playerAI gameState =
    let playerAI  = ref playerAI
    let gameState = ref gameState
    let viewer    = new GameViewer()
    let win32View = viewer :> IWin32Window
                           |> Some
    
    viewer.loadPlayerButton.Click.Add(fun _ -> 
      win32View 
      |> choosePlayerLib
      |> Option.iter (fun lib ->
           playerAI := (loadPlayerAI >> choosePlayer win32View) lib
           resetDisplay viewer playerAI))
    
    viewer.loadLevelButton.Click.Add(fun _ -> 
      win32View
      |> chooseLevelDef
      |> Option.iter (fun lvl ->
            gameState := loadLevelDef lvl
            resetDisplay viewer playerAI))

    viewer.startButton.Click.Add(fun _ ->             
      match !playerAI,!gameState with
      | Some playerAI 
       ,Some gameState -> playGame viewer playerAI gameState
      | _              -> MessageBox.Show(
                              viewer
                             ,"Please select a Player and a Level"
                             ,"GraphMan - Attention"
                             ,MessageBoxButtons.OK
                             ,MessageBoxIcon.Warning) 
                          |> ignore)
    
    resetDisplay viewer playerAI
    viewer

  (* _________________________________________________________________ *)
  
  let [<Literal>] OKAY =  0

  [<STAThread;EntryPoint>]
  let main args = 
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(true)

    let playerAI,gameState =
      match args with
      | [| playerLib
           levelDef |] -> choosePlayer None (loadPlayerAI playerLib)
                         ,loadLevelDef levelDef
      | _              -> None
                         ,None

    use viewer = configureApp playerAI gameState
    Application.Run(viewer)
    OKAY
