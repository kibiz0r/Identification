module IdentTests

open FSharp.Quotations
open Expecto
open FsUnit
open Identification

[<Tests>]
let tests =
  testList "Ident" [
    testCase "can express a simple Let" <| fun _ ->
      let letVar = IdentVar "myVar"
      let letValue = IdentValue 5
      let letBody = IdentVarGet letVar

      let letIdent = IdentLet (letVar, letValue, letBody)

      true |> should be True

  ]