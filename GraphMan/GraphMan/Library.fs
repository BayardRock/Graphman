[<AutoOpen>] 
module internal GraphMan.Library

open GraphMan.Common.Types
open GraphMan.Common.Library
open GraphMan.Resources

open System.IO
open System.Windows.Forms

type PlayerItem = { Key: string; Value: PlayerAI }
  with  override self.ToString() = self.Key
        static member New(ai:PlayerAI) = { Key=ai.Name; Value=ai; }

let (|Dimensions|) level = 
  let height  = Array.length level
  let width   = ((Array.map Array.length) >> Array.max) level
  Dimensions(width,height)

let chooseFile title filter parent =
  use fileChooser = new OpenFileDialog(Title=title,Filter=filter)
  let fileChoice  = match parent with
                    | Some(parent)  ->  fileChooser.ShowDialog(parent)
                    | None          ->  fileChooser.ShowDialog()
  match fileChoice with
  | DialogResult.OK ->  Some(fileChooser.FileName)
  | _               ->  None

let choosePlayerLib : (IWin32Window option -> string option) =
  chooseFile "GraphMan - Select a Player" 
             "Library (*.exe;*.dll)|*.exe;*.dll|All files (*.*)|*.*"

let chooseLevelDef : (IWin32Window option -> string option) =
  chooseFile "GraphMan - Select a Level" 
             "Graph Files (*.graph)|*.graph|All files (*.*)|*.*"
  
let choosePlayer parent players =
  use playerChooser = new PlayerList()
  playerChooser.StartPosition <-
    if Option.isNone parent then FormStartPosition.CenterScreen
                            else FormStartPosition.CenterParent
  players 
  |> Seq.map  (PlayerItem.New)
  |> Seq.iter (playerChooser.playersList.Items.Add >> ignore)
  let playerChoice =  match parent with
                      | Some(parent)  ->  playerChooser.ShowDialog(parent)
                      | None          ->  playerChooser.ShowDialog()
  match playerChoice with
  | DialogResult.OK ->  let {Key=_;Value=player} = 
                          downcast playerChooser.playersList.SelectedItem
                        Some(player)
  | _               ->  None

let loadPlayerLib = loadPlayerAI

let loadLevelDef  = File.ReadAllText >> loadWorld >> Some
