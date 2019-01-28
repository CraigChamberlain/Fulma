namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Notification =

    type Option =
        | Color of IColor
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    /// Generate <div class="notification"></div>
    let notification (options : Option list) children =
        let parseOption (result : GenericOptions) opt =
            match opt with
            | Color color -> ofColor color |> result.AddClass
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "notification").ToReactElement(div, children)

    /// Generate <button class="delete"></button>
    let delete (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "delete").ToReactElement(button, children)
