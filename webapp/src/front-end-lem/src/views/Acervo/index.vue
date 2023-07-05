<template>
  <main class="flex-col ">
        <div class="flex flex-col items-center w-full mx-auto px-6 py-8 gap-1">
          <h1 class="text-4xl font-black text-black">Acervo</h1>
          <input
            id="search"
            v-model="state.searchPayload"
            type="search"
            class="field w-1/3 bg-gray-100 bg-opacity-50 rounded border border-green-300 focus:border-green-500 focus:bg-white focus:ring-2 focus:ring-green-200 text-base outline-none text-gray-700 py-1 px-3 leading-8 transition-colors duration-200 ease-in-out"
            placeholder="Filtrar..."
          />
          <card v-for="c in filterList()" :key="c.id" :id="c.id" :title="c.name" :authorName="c.authorName" :tags="c.tags" :resume="c.resume" :redirect="redirect" :img="c.urlImages[0]" resumeON="true"/>
        </div>
  </main>
</template>

<script>
import card from '../../components/Card/LemCard.vue'
import { reactive } from 'vue'
import services from '../../services'

export default {
  components: { card },

  setup () {
    const redirect = 'AcervoSinglePage'
    const searchPayload = ''
    const cards = []
    const state = reactive({
      cards,
      searchPayload
    })

    function filterList () {
      if (this.state.searchPayload !== '') {
        console.log(this.state.searchPayload)
        return this.state.cards.filter((item) =>
          `${item.name} ${item.authorName} ${item.tags}`.toLowerCase()
            .includes(this.state.searchPayload.toLowerCase())
        )
      } else {
        return this.state.cards
      }
    }

    async function getAcervo () {
      const { data, errors } = await services.art.getArtifacts()
      if (!errors) {
        console.log(data)
        this.state.cards.push(...data)
      } else {
        console.log(errors)
      }
    }

    return {
      getAcervo,
      filterList,
      state,
      redirect
    }
  },

  mounted () {
    this.getAcervo()
  }
}
</script>
