<template>
  <main class="">
      <div class="flex flex-col items-center w-full mx-auto px-6 py-8 gap-1">
        <h1 class="text-4xl font-black text-black">Projetos</h1>
        <input
          id="search"
          v-model="state.searchPayload"
          type="search"
          class="field w-1/3 bg-gray-100 bg-opacity-50 rounded border border-green-300 focus:border-green-500 focus:bg-white focus:ring-2 focus:ring-green-200 text-base outline-none text-gray-700 py-1 px-3 leading-8 transition-colors duration-200 ease-in-out"
          placeholder="Filtrar..."
        />
        <card v-for="c in filterList()" :key="c.id" :title="c.title" :img="c.urlImage" :resume="c.resume" :authorName="c.authorname" :id="c.id" :redirect="redirect" resumeON="true" :tags="c.tags"/>
      </div>
  </main>
</template>

<script>
import card from '../../components/Card/LemCard.vue'
import services from '../../services'
import { reactive } from 'vue'

export default {
  components: { card },

  setup () {
    const redirect = 'ProjetoSinglePage'
    const cards = []
    const searchPayload = ''
    const flagFilter = false
    const state = reactive({
      cards,
      searchPayload
    })

    async function getProjects () {
      const { data, errors } = await services.proj.getProjects()
      console.log(data)
      if (!errors) {
        this.state.cards = data
      } else {
        console.log(errors)
      }
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
      redirect,
      flagFilter,
      getProjects,
      filterList
    }
  },

  mounted () {
    this.getProjects()
  }
}
</script>
