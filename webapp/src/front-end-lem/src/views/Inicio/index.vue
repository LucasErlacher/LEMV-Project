<template>
<lem-principal/>

<div class="flex items-center justify-center">
    <div class="w-5/6 space-y-20">
      <div>
        <h2 class="flex text-4xl font-black justify-center text-black space-y-20">Últimas notícias</h2>
      </div>
      <carousel :noticias="state.cards" />
    </div>

</div>

<lem-footer/>

</template>

<script>
import LemPrincipal from './LemPrincipal.vue'
import LemFooter from '../../components/Footer/LemFooter.vue'
import carousel from '../../components/carousel/CarouselNoticias.vue'
import services from '../../services'
import { reactive } from 'vue'

export default {
  components: { LemPrincipal, LemFooter, carousel },

  data () {
    const cards = []
    const state = reactive({
      cards
    })

    return {
      state
    }
  },

  methods: {
    async getNews () {
      const { data, errors } = await services.news.getNews()
      if (!errors) {
        this.state.cards = data
      } else {
        console.log(errors)
      }
    },
    filtrar (value) {
      console.log(value)
    }
  },

  mounted () {
    this.getNews()
  }
}
</script>

<style>

</style>
