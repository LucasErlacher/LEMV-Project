<template>
  <main class="">
        <div class="flex flex-col items-center w-full mx-auto px-6 py-8 gap-1">
          <h1 class="text-4xl font-black text-black">Projetos</h1>
            <button @click="filter = !filter" class="focus:outline-none">
              <span class="inline">Filtrar: </span>
              <svg xmlns="http://www.w3.org/2000/svg" class=" inline h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 4a1 1 0 011-1h16a1 1 0 011 1v2.586a1 1 0 01-.293.707l-6.414 6.414a1 1 0 00-.293.707V17l-4 4v-6.586a1 1 0 00-.293-.707L3.293 7.293A1 1 0 013 6.586V4z" />
              </svg>
            </button>
            <div v-if="filter" class="grid grid-col-2 items-center md:grid-col-2">
              <form>
                <select v-model="categoria">
                  <option disabled value="">Categoria</option>
                  <option value="Geometria">Geometria</option>
                  <option value="Álgebra" >Álgebra</option>
                  <option value="Trigonometria">Trigonometria</option>
                  <option value="">Nenhuma</option>
                </select>
                <div>
                  <label type="text">Data Inicio: </label>
                  <input v-model="dataInicio" type="date">
                  <label type="text">Data Fim: </label>
                  <input v-model="dataFim" type="date">
                </div>
              </form>
              <button
                class="bg-gray-300 rounded-md px-3" @click="getProjects">Filtrar
              </button>
            </div>
          <card v-for="c in state.cards" :key="c.id" :title="c.title" :urlImage="c.urlImage" :description="c.description" :authorName="c.authorName" :id="c.id" :redirect="redirect"/>
        </div>
  </main>
</template>

<script>
import card from '../../components/Card/index.vue'
import services from '../../services'

export default {

  data () {
    const redirect = 'ProjetoSinglePage'
    const cards = []
    const filter = false
    const state = {
      cards
    }

    return {
      state,
      redirect,
      filter,
      categoria: '',
      dataInicio: '',
      dataFim: ''
    }
  },

  methods: {
    async getNews () {
      const { data, errors } = await services.proj.getProjects()
      if (!errors) {
        this.state.cards = data
        console.log(data)
      } else {
        console.log(errors)
      }
    }

  },

  components: { card },
  mounted () {
    this.getNews()
  }
}
</script>
