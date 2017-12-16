namespace Identification

open FSharp.Quotations

module ExprIdentity =
  let identifiable = ExprIdentifiableBuilder ()

  let identified = ExprIdentifiedBuilder ()

  let compile ident =
    {
      Value = ident.Value
      Metadata = Unchecked.defaultof<Expr>
    }

  let identify (identifiable : Identifiable<_, _>) =
    {
      Value = identifiable.Value
      Identity = Known identifiable.Metadata
    }

  let compileAndIdentify ident = compile ident |> identify