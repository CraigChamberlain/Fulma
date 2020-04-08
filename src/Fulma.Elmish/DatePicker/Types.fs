namespace Fulma.Elmish.DatePicker

open System
open Fable.React.Props

module Types =

    type State =
        { Today : DateTime option
          InputFocused : bool
          ReferenceDate : DateTime
          AutoClose : bool
          ForceClose : bool
          TitleFormat : string
          ShowDeleteButton : bool  }

    let defaultState =
        { Today = None
          InputFocused = false
          ReferenceDate = DateTime.UtcNow
          AutoClose = false
          ForceClose = false
          TitleFormat = ""
          ShowDeleteButton = false  }

    type Config<'Msg> =
        { OnChange : State * (DateTime option) -> 'Msg
          Local : Date.Local.Localization
          DatePickerStyle : CSSProp list }

    let defaultConfig onChangeMsg =
        { OnChange = DatePickerChanged
          Local = Date.Local.englishUK
          DatePickerStyle = [ Position PositionOptions.Absolute
                              ZIndex 100
                              MaxWidth "450px" ] }

    type Msg =
        | NoOp

    type Model =
        { CurrentDate : DateTime }
