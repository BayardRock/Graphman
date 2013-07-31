module internal GraphMan.Drawing
//TODO: develop better graphics
  
open GraphMan.Common.Types
open GraphMan.Resources

open System
open System.Drawing

type GFX = My.Resources.Resources

//NOTE: preloading images to improve performance
let right   = GFX.pr
let left    = GFX.pl
let up      = GFX.pu
let down    = GFX.pd
let pellet  = GFX.dot
let wall    = GFX.bottom
let blank   = GFX.blank

let [<Literal>] tileSize = 25 //TOOD: tweak tile size

let prepareBuffer {World=(Dimensions(width,height));} =
  new Bitmap(tileSize * width,tileSize * height)

let renderFrame ( buffer  : Image) 
                { World   = world
                  Player  = playerX
                           ,playerY
                           ,playerD } =

  let (Dimensions(width,height)) = world
  
  use graphics = Graphics.FromImage(buffer)
  
  for y in 0 .. height - 1 do
    for x in 0 .. width - 1 do
  
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
                              //TODO: ghosts? fruit?
                              | _       -> blank
      if isPlayer then 
        //NOTE: this prevents "ghosting" of the player sprite
        graphics.DrawImage(blank,xPos,yPos,tileSize,tileSize)
   
      graphics.DrawImage(image,xPos,yPos,tileSize,tileSize)
 