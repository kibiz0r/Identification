namespace Identification

// DSL-level type that carries a value and AST
type Ident<'Value> = {
  Value : 'Value
  Expr : IdentExpr
}