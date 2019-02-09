module IdentificationTests

open FSharp.Quotations
open Expecto
open FsUnit
open Identification

[<Tests>]
let tests =
  testList "Identification" [
    testCase "foo" <| fun _ ->
      true |> should be False

    // testCase "overview" <| fun _ ->
    //   // Ident is an abstract representation of an identifiable value.
    //   // It must be interpreted and turned into an Identifiable with explicit metadata.
    //   let myIdent : Ident<int> = ident {
    //     return 5
    //   }

    //   // Identifiable includes the metadata.
    //   // exprIdentifiable turns an Ident into an Expr-based Identifiable.
    //   let myExprIdentifiable : Identifiable<int, Expr> = myIdent |> ExprIdentity.compile
    //   // The identifiable macro skips the abstract representation completely.
    //   let myExprIdentifiable' : Identifiable<int, Expr> = ExprIdentity.identifiable {
    //     return 5
    //   }

    //   // Then, an Identifiable can be converted into an Identified.
    //   // To do so usually requires some sort of context.
    //   // 
    //   // In this case, we are identifying ints as strings. However...
    //   // 
    //   // There is nothing inherent to the string identifier that tells us how
    //   // to interpret the identifier.
    //   // 
    //   // The string could be simply "5", or it could be "five",
    //   // or hex for a memory address that contains the value 5.
    //   let myStringIdentify identifiable =
    //     Unchecked.defaultof<Identified<_, _>>
    //   let myStringIdentified : Identified<int, string> = myExprIdentifiable |> myStringIdentify

    //   // In case you want to use an Expr as the Identity, you can skip the
    //   // previous steps and use the identified macro:
    //   let myExprIdentified : Identified<int, Expr> = ExprIdentity.identified {
    //     return 5
    //   }
    //   // Which is equivalent to this:
    //   let myExprIdentified : Identified<int, Expr> = myExprIdentifiable |> ExprIdentity.identify
    //   // And this:
    //   let myExprIdentified' : Identified<int, Expr> = myIdent |> ExprIdentity.compile |> ExprIdentity.identify
    //   // And this:
    //   let myExprIdentified'' : Identified<int, Expr> = myIdent |> ExprIdentity.compileAndIdentify

    //   // A value may or may not have a valid identity in a particular context.
    //   // 
    //   // This Known vs. Unknown behavior lends itself to monadic composition
    //   // However, there is no objective way to bind these constructs,
    //   // because the identity is specific to a context.
    //   match myExprIdentified with
    //   | KnownValue (value, identifier) ->
    //     value |> should equal 5
    //   | UnknownValue value ->
    //     failwith "UnknownValue"
  ]