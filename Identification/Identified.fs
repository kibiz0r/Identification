namespace Identification

type Identified<'Value, 'Identifier> = {
  Value : 'Value
  Identity : Identity<'Identifier>
}
