namespace Identification

type IdentBuilder () =
  member this.Return value =
    {
      Value = value
      Expr = IdentBind ()
    }