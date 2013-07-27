module GraphMan

open GraphMan.Common
open GraphMan.Common.Library
open GraphMan.Common.Types

open System
open System.Drawing
open System.Windows.Forms

let player  = Image.FromFile(@"D:\Working\Graphman\GraphMan\GraphMan\Images\pr.png")
let pellet  = Image.FromFile(@"D:\Working\Graphman\GraphMan\GraphMan\Images\p.png")
let wall    = Image.FromFile(@"D:\Working\Graphman\GraphMan\GraphMan\Images\bottom.png")
let blank   = Image.FromFile(@"D:\Working\Graphman\GraphMan\GraphMan\Images\blank.png" )

let render {World=world;Player=playerX,playerY,playerD;} = 
  let tileSize    = 13 //TODO: tweak the tile size
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
      let img   = match tile with
                  | Pellet  -> pellet
                  | Start   -> player
                  | Wall    -> wall
                  | Empty   -> blank
      graphics.DrawImage(img,x*tileSize,y*tileSize)
  
  boardImage

let [<Literal>] FAIL = -1
let [<Literal>] OKAY =  0

let world' = """*****
*..c*
*.*.*
*...*
*****"""

let fakeAI = 
  { new PlayerAI with
      member __.Name = "I.R. Baboon"
      member __.Decide(gameStat) = South }
    
[<EntryPoint>]
let main = function
  | [| world |] ->
    let world   = loadWorld world'
    use visual  = render world
    use viewer  = new Form(Text                  = "GraphMan"
                          ,Width                 = visual.Width
                          ,Height                = visual.Height
                          ,BackColor             = Color.White
                          ,BackgroundImage       = visual
                          ,BackgroundImageLayout = ImageLayout.Stretch)
    Application.Run(viewer)
    while true do 
       viewer.BackgroundImage <- render (advanceOneTurn fakeAI world)
    OKAY
  | _ ->  printfn "usage: GraphMan <world>"
          FAIL
