namespace GraphMan.Common.Types 

open System
open System.Text

type Node = 
    | Empty
    | Pellet
    | Wall
    | Player
    
// Le test map
// '.' is pellet
// 'c' is pacman
// '*' is wall
// Array edges without walls wrap around
//*****
//*..c*
//*.*.*
//*...*
//*****

type GameState = 
    {
        World: Node [][]
    }
    with static member Load (description: string) : GameState =
                let lines = description.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.None)                
                { World = 
                    lines |> Seq.mapi (fun i line -> 
                        line |> Seq.mapi (fun j c -> 
                                match c with
                                | 'c' -> Player
                                | '.' -> Pellet
                                | '*' -> Wall
                                | c -> failwith (sprintf "Unexpected char in map: %c" c)
                            ) |> Seq.toArray 
                        ) |> Seq.toArray
                }

type Direction = 
    | North
    | South
    | East
    | West

type PlayerAI = 
    abstract Name: string
    abstract Decide: GameState -> Direction

