namespace Identification

open FSharp.Quotations
open FSharp.Quotations.Patterns

type ExprIdentifiedBuilder () =
  member this.Return ([<ReflectedDefinition true>] valueExpr : Expr<'Value>) =
    match valueExpr with
    | WithValue (value, _, expr) ->
      {
        Value = value :?> 'Value
        Identity = Known expr
      }
    | _ ->
      invalidArg "valueExpr" ""