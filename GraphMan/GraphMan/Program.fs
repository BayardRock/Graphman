module GraphMan

open GraphMan.Common
open GraphMan.Common.Library
open GraphMan.Common.Types

open System
open System.Drawing
open System.Windows.Forms

let render {World=world;Player=playerX,playerY,playerD;} = 
  let tileSize    = 30 //TODO: tweak the tile size
  let boardHeight = Array.length world 
  let boardWidth  = ((Array.map Array.length) >> Array.max) world
  let visWidth
     ,visHeight   = tileSize * boardWidth
                  , tileSize * boardHeight
  let boardImage  = new Bitmap(visWidth,visHeight)
  use borderPen   = new Pen(Brushes.Black,2.0f)
  let borderRect  = Rectangle(1,1,visWidth - 2,visHeight - 2)
  use graphics    = Graphics.FromImage boardImage
    
  let drawTile (x,y) tile =
    let x1,y1 = tileSize * x,tileSize * y
    let x2,y2 = x1 + tileSize,y1 + tileSize
      
    if x = playerX && y = playerY
      then  graphics.DrawEllipse(borderPen,x1,y1,x2,y2)
      else  match tile with
            | Wall  -> graphics.DrawRectangle(borderPen,x1,y1,x2,y2)
            | _     -> ()

  // draw outer "bounds" of maze (with offset to prevent clipping)
  graphics.DrawRectangle(borderPen,borderRect) 
    
  // loop through rows and cells, drawing the walls of each cell
  world |> Array.iteri (fun y row  ->
    row |> Array.iteri (fun x tile -> drawTile (x,y) tile))

  boardImage

let [<Literal>] FAIL = -1
let [<Literal>] OKAY =  0

[<EntryPoint>]
let main = function
  | [| world |] -> 
    let world' = """*****
*..c*
*.*.*
*...*
*****"""
    use visual  = (loadWorld >> render) world'
    use viewer  = new Form(Text                  = "Maze Jam: Maze Viewer"
                          ,Width                 = visual.Width
                          ,Height                = visual.Height
                          ,BackColor             = Color.White
                          ,BackgroundImage       = visual
                          ,BackgroundImageLayout = ImageLayout.Center)
    Application.Run(viewer);
    OKAY
  | _ ->  printfn "usage: GraphMan <world>"
          FAIL
