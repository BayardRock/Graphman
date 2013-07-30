namespace GraphMan

open GraphMan.Common
open GraphMan.Common.Library
open GraphMan.Common.Types

open System
open System.Drawing
open System.Windows.Forms

module Program =

  //TODO: develop better graphics
  let player  = Image.FromFile(@"D:\Working\Graphman\GraphMan\GraphMan\Images\pr.png"    )
  let pellet  = Image.FromFile(@"D:\Working\Graphman\GraphMan\GraphMan\Images\p.png"     )
  let wall    = Image.FromFile(@"D:\Working\Graphman\GraphMan\GraphMan\Images\bottom.png")
  let blank   = Image.FromFile(@"D:\Working\Graphman\GraphMan\GraphMan\Images\blank.png" )
  //TODO: find a better way to manage resources

  let render {World=world;Player=playerX,playerY,playerD;} =
    let tileSize    = 25 //TODO: tweak the tile size
    let boardHeight = Array.length world 
    let boardWidth  = ((Array.map Array.length) >> Array.max) world
    let visWidth
       ,visHeight   = tileSize * boardWidth
                     ,tileSize * boardHeight
    let boardImage  = new Bitmap(visWidth,visHeight)
    use graphics    = Graphics.FromImage(boardImage)

    for y in 0 .. boardHeight - 1 do
      for x in 0 .. boardWidth - 1 do
        let tile  = world.[y].[x] 
        let img   = if x = playerX && y = playerY 
                      then  player
                      else  match tile with
                            | Pellet  -> pellet
                            | Wall    -> wall
                            | _       -> blank
        graphics.DrawImage(img,x*tileSize,y*tileSize,tileSize,tileSize)

    boardImage

  let game (viewer:Form) playerAI initialState =
    let rec loop state board =
      if viewer.Visible then
        let state = advanceOneTurn playerAI state
        let board = render state
        viewer.Paint.Add(fun e -> e.Graphics.DrawImage(board,0,0))
        viewer.Refresh()
        System.Threading.Thread.Sleep(300) 
        //TODO: find a better way to control the FPS
        Application.DoEvents()
        loop state board
    loop initialState (render initialState)

  let world' = """*****
*..c*
*.*.*
*...*
*****"""

  let fakeAI = 
    let rand = Random()
    { new PlayerAI with
        member __.Name = "I.R. Baboon"
        member __.Decide(gameStat) = 
          match rand.Next(1,5) with
          | 1 -> North
          | 2 -> South
          | 3 -> East
          | _ -> West }

  let [<Literal>] FAIL = -1
  let [<Literal>] OKAY =  0

  [<STAThread;EntryPoint>]
  let main = function
    | [| playerLib;worldDef; |] ->  
      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(true)                                  
      let player  = fakeAI //TODO: load playerAI from playerLib
      let world   = loadWorld world' //worldDef
      use viewer  = 
        new Form(Text   = sprintf "GraphMan - Player: %s" player.Name
                ,Width  = 200
                ,Height = 200)
      viewer.Show()
      game viewer player world
      //TODO: detect game completion
      OKAY
    | _ -> printfn "usage: GraphMan <assembly> <world>"; FAIL
