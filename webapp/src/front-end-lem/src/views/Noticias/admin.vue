<template>
  <main class="flex-col ">
        <div class="flex flex-col items-center w-full mx-auto px-6 py-8 gap-1">
          <h1 class="text-4xl font-black text-black"> Administrador: Notícias</h1>
          <input
            id="search"
            v-model="state.searchPayload"
            type="search"
            class="field w-1/3 bg-gray-100 bg-opacity-50 rounded border border-green-300 focus:border-green-500 focus:bg-white focus:ring-2 focus:ring-green-200 text-base outline-none text-gray-700 py-1 px-3 leading-8 transition-colors duration-200 ease-in-out"
            placeholder="Filtrar..."
          />
          <icon-button @click="pushCreateNews()"
            path="M22.5 34H25.5V25.5H34V22.5H25.5V14H22.5V22.5H14V25.5H22.5ZM9 42Q7.8 42 6.9 41.1Q6 40.2 6 39V9Q6 7.8 6.9 6.9Q7.8 6 9 6H39Q40.2 6 41.1 6.9Q42 7.8 42 9V39Q42 40.2 41.1 41.1Q40.2 42 39 42ZM9 39H39Q39 39 39 39Q39 39 39 39V9Q39 9 39 9Q39 9 39 9H9Q9 9 9 9Q9 9 9 9V39Q9 39 9 39Q9 39 9 39ZM9 39Q9 39 9 39Q9 39 9 39V9Q9 9 9 9Q9 9 9 9Q9 9 9 9Q9 9 9 9V39Q9 39 9 39Q9 39 9 39Z"
          />
          <card v-for="c in filterList()"
          @list="getNews()"
          :key="c.id"
          :title="c.title"
          :media="c.media"
          :resume="c.resume"
          :description="c.description"
          :details="c.authorName"
          :urlImage="c.urlImage"
          :tags="c.tags"
          :id="c.id"
          :skill="c.skill"
          resumeON="true"
          @newsUpdate="pushtoUpdateNews($event.id, $event)"
          @newsDelete="deleteNews($event)"
          />
        </div>
  </main>
</template>

<script>
import card from '../../components/Card/newsUpdate.vue'
import { reactive } from 'vue'
import services from '../../services'
import useModal from './../../hooks/useModal'
import IconButton from '../../components/Button/iconButton.vue'
import { useRouter } from 'vue-router'

export default {
  components: { card, IconButton },

  setup () {
    const router = useRouter()
    const searchPayload = ''
    const modal = useModal()
    const cards = []
    const state = reactive({
      cards,
      searchPayload
    })

    async function getNews () {
      const { data, errors } = await services.news.getNews()
      if (!errors) {
        this.state.cards = data
      } else {
        console.log(errors)
      }
    }

    function updateNews (props) {
      modal.open({
        component: 'ModalUpdateNews',
        status: true,
        props: props
      })
    }

    function createNews (props) {
      modal.open({
        component: 'ModalCreateNews',
        status: true,
        props: props
      })
    }

    function deleteNews (props) {
      modal.open({
        component: 'ModalCancel',
        status: true,
        props: props
      })
    }

    function pushCreateNews () {
      router.push({ name: 'NoticiasCreatePage' })
    }

    function pushtoUpdateNews (id, news) {
      router.push({ name: 'NoticiasUpdatePage', params: { id: id, data: JSON.stringify(news) } })
    }

    function filterList () {
      if (this.searchPayload !== '') {
        return this.state.cards.filter((item) =>
          `${item.title} ${item.authorName}`.toLowerCase()
            .includes(this.state.searchPayload.toLowerCase())
        )
      } else {
        return this.state.cards
      }
    }

    return {
      state,
      updateNews,
      deleteNews,
      createNews,
      pushCreateNews,
      pushtoUpdateNews,
      getNews,
      filterList
    }
  },

  mounted () {
    this.getNews()
  }
}
</script>
