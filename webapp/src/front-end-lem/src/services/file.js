
export default httpClient => ({
  upload: async (selected) => {
    var formData = new FormData()
    formData.append('file', selected[0])
    const response = await httpClient.post('/files/upload', formData, {
      headers: {
        'Content-Type': 'multipart/form-data'
      }
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
  },
  download: async (id) => {
    const response = await httpClient.get('/files/download/' + id, { responseType: 'blob' })
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
