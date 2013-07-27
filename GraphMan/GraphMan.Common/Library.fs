module GraphMan.Common.Library

open GraphMan.Common.Types
open System

let Load (description: string) : GameState =
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
    Player  = getPlayer nodes }
