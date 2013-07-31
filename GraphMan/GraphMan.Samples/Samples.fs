namespace GraphMan.Samples

open GraphMan.Common.Types
open System

type Baboon() =
  interface PlayerAI with
    member __.Name = "I.R. Baboon"
    member __.Decide(_) = West

module Library =

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
