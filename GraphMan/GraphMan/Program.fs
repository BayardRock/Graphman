namespace GraphMan

open GraphMan.Common
open GraphMan.Common.Library
open GraphMan.Common.Types
open GraphMan.Resources

open System
open System.Drawing
open System.IO
open System.Threading
open System.Windows.Forms

type Baboon() =
  interface PlayerAI with
    member __.Name = "I.R. Baboon"
    member __.Decide(_) = West

module Program =

  (* _ TEST __________________________________________________________ *)

  let weaselAI = 
    let rand = Random()
    { new PlayerAI with
        member __.Name = "I.M. Weasel"
        member __.Decide(gameStat) = 
          match rand.Next(1,5) with
          | 1 -> North
          | 2 -> South
          | 3 -> East
          | _ -> West }

  (* _________________________________________________________________ *)

  (* _ GRAPHICS ______________________________________________________ *)

  //TODO: develop better graphics
  let right   = Image.FromFile(@"C:\Development\Graphman\GraphMan\GraphMan\Images\pr.png"    )
  let left    = Image.FromFile(@"C:\Development\Graphman\GraphMan\GraphMan\Images\pl.png"    )
  let up      = Image.FromFile(@"C:\Development\Graphman\GraphMan\GraphMan\Images\pu.png"    )
  let down    = Image.FromFile(@"C:\Development\Graphman\GraphMan\GraphMan\Images\pd.png"    )
  let pellet  = Image.FromFile(@"C:\Development\Graphman\GraphMan\GraphMan\Images\dot.png"   )
  let wall    = Image.FromFile(@"C:\Development\Graphman\GraphMan\GraphMan\Images\bottom.png")
  let blank   = Image.FromFile(@"C:\Development\Graphman\GraphMan\GraphMan\Images\blank.png" )
  //TODO: find a better way to manage resources

  (* _________________________________________________________________ *)

  //MAYBE: only redraw parts of board which have changed?

  let render (buffer:Image) 
             tileSize
             (boardWidth,boardHeight)
             {World=world;Player=playerX,playerY,playerD;} =
    //TODO: render player name and score
    use graphics = Graphics.FromImage(buffer)
    for y in 0 .. boardHeight - 1 do
      for x in 0 .. boardWidth - 1 do
        let xPos,yPos = x * tileSize,y * tileSize
        let tile      = world.[y].[x] 
        let isPlayer  = x = playerX && y = playerY 
        let image     = if isPlayer
                          then  match playerD with
                                | North -> up
                                | South -> down
                                | East  -> right
                                | West  -> left
                          else  match tile with
                                | Pellet  -> pellet
                                | Wall    -> wall
                                | _       -> blank
        if isPlayer then 
          graphics.DrawImage(blank,xPos,yPos,tileSize,tileSize)
        graphics.DrawImage(image,xPos,yPos,tileSize,tileSize)
    
  let runGame playerAI gameState =
    let {World=world} = gameState 
    let tileSize      = 25
    let boardHeight   = Array.length world 
    let boardWidth    = ((Array.map Array.length) >> Array.max) world
    let visWidth
       ,visHeight     = tileSize * boardWidth
                       ,tileSize * boardHeight
    use buffer        = new Bitmap(visWidth,visHeight)
    use viewer        = new GameViewer(
                                 Width                 = visWidth
                                ,Height                = visHeight
                                ,BackgroundImage       = buffer
                                ,BackgroundImageLayout = ImageLayout.Center)
    viewer.Show()
    let rec loop state =
      Application.DoEvents()
      if viewer.Visible then
        let state = advanceOneTurn playerAI state
        render buffer tileSize (boardWidth,boardHeight) state
        //TODO: check for level completion
        Thread.Sleep(100) //MAYBE: better way to slow down the action?
        viewer.Invalidate()
        loop state
    //MAYBE: halt game until user-initated event?
    loop gameState

  let [<Literal>] FAIL = -1
  let [<Literal>] OKAY =  0

  [<STAThread;EntryPoint>]
  let main = function
    | [| playerLib;worldDef; |] ->  
      let player  = loadPlayerAI playerLib |> Seq.head
      let world   = (File.ReadAllText >> loadWorld) worldDef
      runGame player world
      OKAY
    | _ -> printfn "usage: GraphMan <assembly> <world>"; FAIL
