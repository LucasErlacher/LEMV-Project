export function validateEmpty (value) {
  if (!value) {
    return '*Campo obrigatório'
  }
  return true
}
