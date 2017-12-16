namespace Identification

open FSharp.Quotations
open FSharp.Quotations.Patterns

type ExprIdentifiableBuilder () =
  member this.Return ([<ReflectedDefinition true>] valueExpr : Expr<'Value>) =
    match valueExpr with
    | WithValue (value, _, expr) ->
      {
        Value = value :?> 'Value
        Metadata = expr
      }
    | _ ->
      invalidArg "valueExpr" ""