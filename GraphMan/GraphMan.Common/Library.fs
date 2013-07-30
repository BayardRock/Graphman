module GraphMan.Common.Library

open GraphMan.Common.Types
open Microsoft.FSharp.Reflection
open System
open System.Reflection

//MAYBE: take dir path instead of dll path
let loadPlayerAI (assemblyPath: string) =

  let (|Concrete|_|) (i:Type) (t:Type) = 
    match i.IsGenericTypeDefinition 
       && t.IsGenericType
       && not <| t.ContainsGenericParameters
       && t.GetGenericTypeDefinition() = i with
    | false -> None
    | true  -> Some t

  let (|Interface|_|) (i:Type) (t:Type) = 
    if t.IsInterface
      then  match t with 
            | Concrete i iface -> Some iface
            | _                -> None
      else  match t.GetInterface(i.FullName) with
            | null  -> None
            | iface -> Some iface

  let (|IsPlayerAI|) t = 
    let playerAI = typeof<PlayerAI>
    match t with 
    | Interface playerAI _  -> true
    | _                     -> false

  let (|HasDefaulCtor|) (t:Type) =
    if t.GetConstructor(Type.EmptyTypes) <> null then true else false
    
  let loadClasses = Seq.filter(|IsPlayerAI|)
                 >> Seq.filter(|HasDefaulCtor|)
                 >> Seq.map   (Activator.CreateInstance)
                 >> Seq.cast<PlayerAI>

  let loadObjects = Seq.filter (FSharpType.IsModule)
                 >> Seq.collect(fun t -> t.GetProperties())
                 >> Seq.filter (fun p -> p.PropertyType = typeof<PlayerAI>)
                 >> Seq.map    (fun p -> p.GetValue(null))
                 >> Seq.cast<PlayerAI> 
  
  let allTypes = Assembly.LoadFile(assemblyPath).GetTypes()
  Seq.concat [ loadClasses allTypes; loadObjects allTypes; ]

let loadWorld (description: string)  =
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
            if nodes.[i].[j] = Start then 
              player <- i,j,North
              nodes.[i].[j] <- Pellet //TODO: is this correct?
        player

    { World       = nodes
      Player      = getPlayer nodes
      PlayerScore = 0 }

//TODO: Wrap around edges
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

let checkLevelComplete {World=world} =
  world |> Seq.forall (fun row -> 
    row |> Seq.forall (function | Wall 
                                | Empty -> true 
                                | _     -> false))
