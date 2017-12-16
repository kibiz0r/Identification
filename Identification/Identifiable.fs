namespace Identification

// Core type that carries a value and metadata about the value
type Identifiable<'Value, 'Metadata> = {
  Value : 'Value
  Metadata : 'Metadata
}