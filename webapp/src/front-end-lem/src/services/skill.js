
export default httpClient => ({
  getAll: async () => {
    const response = await httpClient.get('/skills')
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
  },
  getSingle: async (id) => {
    const response = await httpClient.get('/skills/' + id)
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
  },
  updateOne: async (skill) => {
    const response = await httpClient.put('/skills/', skill)
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
  },
  createOne: async (skill) => {
    const response = await httpClient.post('/skills/', skill)
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
  },

  deleteOne: async (id) => {
    const response = await httpClient.delete('/skills/' + id)
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
