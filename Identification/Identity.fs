namespace Identification

type Identity<'Identifier> =
| Known of 'Identifier
| Unknown
with
  member this.Identifier =
    match this with
    | Known identifier -> identifier
    | Unknown -> invalidOp ""