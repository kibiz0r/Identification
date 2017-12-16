namespace Identification

[<AutoOpen>]
module Identification = 
    let ident = IdentBuilder ()

    let (|KnownValue|UnknownValue|) (identified : Identified<'Value, 'Identifier>) =
      let value = identified.Value
      match identified.Identity with
      | Known identifier ->
        KnownValue (value, identifier)
      | Unknown ->
        UnknownValue value