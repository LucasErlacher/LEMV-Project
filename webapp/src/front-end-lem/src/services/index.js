import axios from 'axios'
import AuthService from './auth'
import NewsService from './news'
import ProjectsService from './projects'

const API_ENVS = {
  prod: '',
  dev: '',
  local: 'https://60b27e9662ab150017ae2453.mockapi.io/lemv/1/'

}

const httpClient = axios.create({
  baseURL: API_ENVS.local
})

httpClient.interceptors.response.use((response) => {
  return response
}, (error) => {
  const canThrowAnError = error.request.status === 0 ||
    error.request.status === 500

  if (canThrowAnError) {
    throw new Error(error.message)
  }

  return error
})

export default {
  auth: AuthService(httpClient),
  news: NewsService(httpClient),
  proj: ProjectsService(httpClient)
}
