namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Card =

    module Classes =
        let [<Literal>] Container = "card"
        module Header =
            let [<Literal>] Container = "card-header"
            let [<Literal>] Icon = "card-header-icon"
            module Title =
                let [<Literal>] Container = "card-header-title"
                let [<Literal>] IsCentered = "is-centered"
        let [<Literal>] Image = "card-image"
        let [<Literal>] Content = "card-content"
        module Footer =
            let [<Literal>] Container = "card-footer"
            let [<Literal>] Item = "card-footer-item"

    /// Generate <div class="card"></div>
    let card (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Container [opts.CustomClass] []
        div (classes::opts.Props) children

    /// Generate <div class="card-header"></div>
    let header (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Header.Container [opts.CustomClass] []
        header (classes::opts.Props) children

    /// Generate <div class="card-content"></div>
    let content (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Content [opts.CustomClass] []
        div (classes::opts.Props) children

    /// Generate <div class="card-footer"></div>
    let footer (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Footer.Container [opts.CustomClass] []
        footer (classes::opts.Props) children

    module Header =

        module Title =

            type Option =
                /// Add `is-centered` class
                | IsCentered
                | Props of IHTMLProp list
                | CustomClass of string

            type internal Options =
                { IsCentered : bool
                  Props : IHTMLProp list
                  CustomClass : string option }
                static member Empty =
                    { IsCentered = false
                      Props = []
                      CustomClass = None }

        /// Generate <a class="card-header-icon"></a>
        let icon (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Header.Icon [opts.CustomClass] []
            a (classes::opts.Props) children

        /// Generate <p class="card-header-title"></p>
        let title (options: Title.Option list) children =
            let parseOption (result : Title.Options) opt =
                match opt with
                | Title.IsCentered -> { result with IsCentered = true }
                | Title.Props props -> { result with Props = props }
                | Title.CustomClass customClass -> { result with CustomClass = customClass |> Some }

            let opts = options |> List.fold parseOption Title.Options.Empty
            let classes = Helpers.classes
                            Classes.Header.Title.Container
                            [ opts.CustomClass ]
                            [ Classes.Header.Title.IsCentered, opts.IsCentered ]

            p (classes::opts.Props) children

    module Footer =

        /// Generate <a class="card-footer-item"></a>
        let item (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Footer.Item [opts.CustomClass] []
            a (classes::opts.Props) children
