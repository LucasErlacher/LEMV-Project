<template>
  <main class="flex-col ">
        <div class="flex flex-col items-center w-full mx-auto px-6 py-8 gap-1">
          <h1 class="text-4xl font-black text-black"> Administrador: Projetos</h1>
          <input
            id="search"
            v-model="state.searchPayload"
            type="search"
            class="field w-1/3 bg-gray-100 bg-opacity-50 rounded border border-green-300 focus:border-green-500 focus:bg-white focus:ring-2 focus:ring-green-200 text-base outline-none text-gray-700 py-1 px-3 leading-8 transition-colors duration-200 ease-in-out"
            placeholder="Filtrar..."
          />
          <icon-button @click="createProject()"
            path="M22.5 34H25.5V25.5H34V22.5H25.5V14H22.5V22.5H14V25.5H22.5ZM9 42Q7.8 42 6.9 41.1Q6 40.2 6 39V9Q6 7.8 6.9 6.9Q7.8 6 9 6H39Q40.2 6 41.1 6.9Q42 7.8 42 9V39Q42 40.2 41.1 41.1Q40.2 42 39 42ZM9 39H39Q39 39 39 39Q39 39 39 39V9Q39 9 39 9Q39 9 39 9H9Q9 9 9 9Q9 9 9 9V39Q9 39 9 39Q9 39 9 39ZM9 39Q9 39 9 39Q9 39 9 39V9Q9 9 9 9Q9 9 9 9Q9 9 9 9Q9 9 9 9V39Q9 39 9 39Q9 39 9 39Z"
          />
          <card v-for="c in filterList()"
          @list="getProject()"
          :key="c.id"
          :id="c.id"
          :title="c.title"
          :media="c.media"
          :urlImage="c.urlImage"
          :resume="c.resume"
          :authorName="c.authorName"
          :description="c.description"
          :manual="c.manual"
          :tags="c.tags"
          :skill="c.skill"
          resumeON="true"
          @ProjectUpdate="pushtoUpdateProject($event.id, $event)"
          @ProjectDelete="deleteProject($event)"
          />
        </div>
  </main>
</template>

<script>
import card from '../../components/Card/projectUpdate.vue'
import { reactive } from 'vue'
import services from '../../services'
import useModal from './../../hooks/useModal'
import IconButton from '../../components/Button/iconButton.vue'
import { useRouter } from 'vue-router'

export default {
  components: { card, IconButton },

  setup () {
    const router = useRouter()

    const payload = {}
    const searchPayload = ''
    const modal = useModal()
    const cards = []
    const state = reactive({
      cards,
      payload,
      searchPayload
    })

    async function getProject () {
      const { data, errors } = await services.proj.getProjects()
      if (!errors) {
        this.state.cards = data
      } else {
        console.log(errors)
      }
    }

    function updateProject (props) {
      modal.open({
        component: 'ModalUpdateProject',
        status: true,
        props: props
      })
    }

    function createProject () {
      router.push({ name: 'ProjetoCreatePage' })
    }

    function pushtoUpdateProject (id, project) {
      router.push({ name: 'ProjetoUpdatePage', params: { id: id, data: JSON.stringify(project) } })
    }

    function deleteProject (props) {
      modal.open({
        component: 'ModalDeleteProject',
        status: true,
        props: props
      })
    }

    function filterList () {
      if (this.searchPayload !== '') {
        return this.state.cards.filter((item) =>
          `${item.titulo} ${item.nomeAutor}`.toLowerCase()
            .includes(this.state.searchPayload.toLowerCase())
        )
      } else {
        return this.state.cards
      }
    }

    return {
      state,
      updateProject,
      deleteProject,
      createProject,
      pushtoUpdateProject,
      getProject,
      filterList
    }
  },

  mounted () {
    this.getProject()
  }
}
</script>
