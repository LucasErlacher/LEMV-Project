<template>
  <section class="text-gray-600 body-font overflow-hidden">
    <div class="container px-5 py-24 mx-auto">
      <div class="lg:w-4/5 mx-auto flex flex-wrap">
        <div class="lg:w-4/6 w-full lg:pr-10 lg:py-6 mb-6 lg:mb-0">
          <h1 class="text-gray-900 text-3xl title-font font-medium mb-4">
            {{ state.noticia.title }}
          </h1>
          <p class="leading-relaxed mb-4">{{ state.noticia.description }}</p>
          <download class="flex justify-end" v-if="state.noticia.media!=null" :name="state.noticia.media.fileName" :fileId="state.noticia.media.id" :format="state.noticia.media.format"/>
          <div class="flex border-t border-gray-200 py-2">
            <span class="text-gray-500">Autor</span>
            <span class="ml-auto text-gray-900">{{
              state.noticia.authorName
            }}</span>
          </div>
          <div>
            <h1 class="text-gray-900 text-1xl title-font font-medium mb-4">
              {{ "Palavras-chave" }}
            </h1>
            <p class="leading-relaxed mb-4">
              {{ state.noticia.tags ? formatKeyWord(state.noticia.tags) : "" }}
            </p>
          </div>
        </div>
        <div class="lg:w-2/6 w-full h-auto object-cover object-center rounded">
          <div class="h-64">
            <img
              alt="Imagem singlePage Noticia"
              :src="state.noticia.urlImage"
              style="width: 400px; height: 300px;"
              class="object-cover object-center"
            />
          </div>
          <skill-resume
            v-if="state.noticia.skill"
            :skill="state.noticia.skill"
          />
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { useRoute } from 'vue-router'
import { reactive } from 'vue'
import skillResume from '../../components/Card/skillResume.vue'

import services from '../../services'
import Download from '../../components/Button/download.vue'

export default {
  components: { skillResume, Download },

  setup () {
    const route = useRoute()
    const id = route.params.id
    const noticia = {}
    const img = '/img/principal.aa4e4091.png'
    const state = reactive({
      img,
      noticia
    })

    async function getSingleNew () {
      const { data, errors } = await services.news.getSingle(this.id)
      if (!errors) {
        state.noticia = data.data
      } else {
        console.log(errors)
      }
    }

    function formatKeyWord (lst) {
      return lst.toString().replace(',', ', ')
    }

    return {
      id,
      state,
      getSingleNew,
      formatKeyWord
    }
  },

  mounted () {
    this.getSingleNew()
  }
}

</script>
