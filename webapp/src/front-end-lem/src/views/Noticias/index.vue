<template>
  <main class="flex-col ">
        <div class="flex flex-col items-center w-full mx-auto px-6 py-8 gap-1">
          <h1 class="text-4xl font-black text-black">Notícias</h1>
          <card v-for="c in cards" :key="c.id" :title="c.title" :urlImage="c.urlImage" :description="c.description" :authorName="c.authorName" :id="c.id"/>
        </div>
  </main>
</template>

<script>
import card from '../../components/Card/index.vue'
import services from '../../services'

export default {

  data () {
    return {
      cards: []
    }
  },

  methods: {
    async getNews () {
      const { data, errors } = await services.news.getNews()
      if (!errors) {
        this.cards = data
      } else {
        console.log('falha no acesso')
      }
    }
  },

  components: { card },
  mounted () {
    this.getNews()
  }
}
</script>
