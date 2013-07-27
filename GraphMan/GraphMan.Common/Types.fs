namespace GraphMan.Common.Types 

open System
open System.Text

module Vals = 
    let PelletPoints = 10

type Node = 
    | Empty
    | Pellet
    | Wall
    | Start
    
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

type Direction = 
    | North
    | South
    | East
    | West

type GameState = 
    {
        World : Node [][]
        Player: int * int * Direction
        PlayerScore: int
    }

type PlayerAI = 
    abstract Name: string
    abstract Decide: GameState -> Direction
