import axios from 'axios'
import AuthService from './auth'
import NewsService from './news'
import ProjectsService from './projects'
import PaperService from './paper'
import MaterialService from './material'
import BookService from './book'
import FileService from './file'
import SkillService from './skill'
import ArtifactService from './artifact'
import ImageService from './image'

const httpClient = axios.create({
  baseURL: 'https://localhost:5052/api/'
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
  proj: ProjectsService(httpClient),
  paper: PaperService(httpClient),
  material: MaterialService(httpClient),
  book: BookService(httpClient),
  file: FileService(httpClient),
  skill: SkillService(httpClient),
  art: ArtifactService(httpClient),
  image: ImageService(httpClient)
}
