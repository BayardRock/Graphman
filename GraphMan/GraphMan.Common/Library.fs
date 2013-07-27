﻿module GraphMan.Common.Library

open GraphMan.Common.Types
open System

let loadWorld (description: string) : GameState =
    let lines = description.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.None)                
    let nodes = 
        lines |> Seq.mapi (fun i line -> 
            line |> Seq.mapi (fun j c -> 
                    match c with
                    | 'c' -> Start
                    | '.' -> Pellet
                    | '*' -> Wall
                    | c -> failwith (sprintf "Unexpected char in map: %c" c)
                ) |> Seq.toArray 
            ) |> Seq.toArray

    let getPlayer nodes = 
        let mutable player = 0,0,North
        for i in 0 .. Array.length nodes do
            for j in 0 .. Array.length nodes.[i] do
            if nodes.[i].[j] = Start then player <- i,j,North
        player

    { World   = nodes
      Player  = getPlayer nodes
      PlayerScore = 0 }


// TODO: Wrap around edges
let internal applyPlayerBehavior (ai: PlayerAI) (state: GameState) =
    // Copy Gamestate before handing off to ensure the player doesn't change it
    let stateCopy = { state with World = state.World |> Array.map (Array.copy) }
    let decision = ai.Decide(stateCopy)
    let onx, ony, _ = state.Player    
    let nnx, nny = 
        match decision with
        | North -> onx, ony - 1
        | South -> onx, ony + 1
        | East -> onx - 1, ony
        | West -> onx + 1, ony

    if    nny < 0 || nny > state.World.Length - 1 
       || nnx < 0 || nnx > state.World.[nny].Length - 1 
       || state.World.[nny].[nnx] = Wall 
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
    let postCheckState = checkPlayerInteractions state
    postCheckState
