namespace Identification

open FSharp.Quotations

type IdentBuilder () =
  member this.Return value =
    {
      Value = value
      Expr = IdentBind ()
    }

  member this.Run ([<ReflectedDefinition true>] runExpr : Expr<'Value>) =
    printfn "%O" runExpr
    Unchecked.defaultof<Ident<'Value>>