namespace Identification

type Ellipse = {
  RadiusX : float
  RadiusY : float
}

type Circle =
  private |
  Circle of Ellipse

type IdentVar =
| IdentVar of name : string

// DSL-level type
// Represents the AST of an ident {} expression
// Includes let! expressions in a more friendly form
// This type is consumed by an... IdentContext?
// ...in order to produce an Identifiable of a particular kind of Metadata
type IdentExpr =
| IdentBind of unit
| IdentLet of var : IdentVar * expr : IdentExpr * body : IdentExpr
| IdentValue of obj
| IdentVarGet of IdentVar
| IdentVarSet of IdentVar * IdentExpr
// etc.
