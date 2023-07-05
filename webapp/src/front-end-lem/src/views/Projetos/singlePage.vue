<template>
<section class="text-gray-600 body-font overflow-hidden">
   <div class="container px-5 py-24 mx-auto">
      <div class="lg:w-4/5 mx-auto flex flex-wrap">
         <div class="lg:w-4/6 w-full lg:pr-10 lg:py-6 mb-6 lg:mb-0">
            <h1 class="text-gray-900 text-3xl title-font font-medium mb-4">{{state.project.title}}</h1>
            <p class="leading-relaxed mb-4">{{state.project.description}}</p>
            <download class="flex justify-end  mb-4" v-if="state.project.media!=null" :name="state.project.media.fileName" :fileId="state.project.media.id" :format="state.project.media.format"/>
            <div class="flex border-t border-gray-200 py-2">
               <span class="text-gray-500">Autor</span>
               <span class="ml-auto text-gray-900">{{state.project.authorname}}</span>
            </div>
            <div>
              <h1 class="text-gray-900 text-1xl title-font font-medium mb-4"> {{'Palavras-chave'}}</h1>
              <p class="leading-relaxed mb-4">{{state.project.tags ? formatKeyWord(state.project.tags) : ''}}</p>
            </div>
            <div class="py-24">
                <h1 class="text-gray-900 text-3xl title-font font-medium mb-4">Tutorial</h1>
                <carousel :manual="state.project.manual"/>
            </div>
         </div>
         <div class="lg:w-2/6 w-full lg:h-auto object-cover object-center rounded">
            <div class="h64">
               <img
               alt="Imagem project"
               :src="state.project.urlImage"
               style="width: 400px; height: 300px;"
               class="object-cover object-center"
               >
            </div>
            <skill-resume v-if="state.project.skill" :skill="state.project.skill"/>
         </div>
      </div>
   </div>
</section>
</template>
<script>
import { useRoute } from 'vue-router'
import services from '../../services'
import { reactive } from 'vue'
import carousel from '../../components/carousel/index.vue'
import skillResume from '../../components/Card/skillResume.vue'
import Download from '../../components/Button/download.vue'

export default {
  components: { carousel, skillResume, Download },

  setup () {
    const img = '/img/principal.aa4e4091.png'
    const route = useRoute()
    const project = {}
    const id = route.params.id
    const state = reactive({
      img,
      project
    })

    async function getSingleProject () {
      const { data, errors } = await services.proj.getSingle(this.id)
      if (!errors) {
        console.log('data.data.media')
        state.project = data.data
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
      getSingleProject,
      formatKeyWord
    }
  },

  mounted () {
    this.getSingleProject()
  }

}
</script>
