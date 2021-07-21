
export default httpClient => ({
  login: async ({ matricula, senha }) => {
    const response = await httpClient.post('/auth', {
      matricula,
      senha
    })
    let errors = null

    if (!response.data) {
      errors = {
        status: response.request.status,
        statusText: response.request.statusText
      }
    }

    return {
      data: response.data,
      errors
    }
  }
})
