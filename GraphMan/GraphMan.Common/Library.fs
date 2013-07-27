module GraphMan.Common.Library

open GraphMan.Common.Types
open System

let loadWorld (description: string) : GameState =
    let lines = description.Split(Environment.NewLine.ToCharArray()
                                 ,StringSplitOptions.RemoveEmptyEntries)                
    let nodes = 
        [| for line in lines do 
                yield [| for char in line do
                            yield match char with
                                  | 'c' -> Start
                                  | '.' -> Pellet
                                  | '*' -> Wall
                                  | bad -> failwith (sprintf "Unexpected char in map: %c" bad) 
                      |]
        |]

    let getPlayer nodes = 
        let mutable player = 0,0,North
        for i in 0 .. (Array.length nodes) - 1 do
            for j in 0 .. (Array.length nodes.[i]) - 1 do
            if nodes.[i].[j] = Start then player <- i,j,North
        player

    { World       = nodes
      Player      = getPlayer nodes
      PlayerScore = 0 }


// TODO: Wrap around edges
let internal applyPlayerBehavior (ai: PlayerAI) (state: GameState) =
    // Copy Gamestate before handing off to ensure the player doesn't change it
    let stateCopy = { state with World = state.World |> Array.map (Array.copy) }
    let decision = ai.Decide(stateCopy)

    // Convert player decision to offsets
    let onx, ony, _ = state.Player    
    let nnx, nny = 
        match decision with
        | North -> onx, ony - 1
        | South -> onx, ony + 1
        | East -> onx - 1, ony
        | West -> onx + 1, ony

    // Test for wrap around and fix
    let nny = if nny < 0 then state.World.Length - 1
              elif nny > state.World.Length - 1 then 0
              else nny

    let nnx = if nnx < 0 then state.World.[nny].Length - 1
              elif nnx > state.World.[nny].Length - 1 then 0
              else nnx 

    // Change position if the move is valid, always change direction
    if state.World.[nny].[nnx] = Wall 
    then { state with Player = onx, ony, decision }
    else { state with Player = nnx, nny, decision }
    
let internal checkPlayerInteractions (state: GameState) =
    // Check for pellet and eat (increase score)
    let px,py,_ = state.Player
    if state.World.[py].[px] = Pellet then 
        state.World.[py].[px] <- Empty
        { state with PlayerScore = state.PlayerScore + Vals.PelletPoints }
    else state

let advanceOneTurn (ai: PlayerAI) (state: GameState) = 
    let postAIstate = applyPlayerBehavior ai state
    let postCheckState = checkPlayerInteractions postAIstate
    postCheckState
