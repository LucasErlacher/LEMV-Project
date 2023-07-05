// import { response } from "express"

export default httpClient => ({
  // login: async ({ matricula, senha }) => {
  //   await httpClient.post('/auth', {
  //     matricula,
  //     senha
  //   })
  //   let errors = null

  //   if (!response.data) {
  //     errors = {
  //       status: response.request.status,
  //       statusText: response.request.statusText
  //     }
  //   }
  //   return {
  //     data: { token: response.data.token },
  //     errors: null
  //   }
  // }

  login: async ({ matricula, senha }) => {
    // await httpClient.post('/auth', {
    //   matricula,
    //   senha
    // })
    if (matricula === 'lemv.admin' && senha === 'aelv@42') {
      return { data: { token: 'taliberado' }, errors: null }
    } else {
      return {
        data: {},
        errors: {
          status: 404,
          statusText: 'Login ou senha invalidos'
        }
      }
    }
  }
})
