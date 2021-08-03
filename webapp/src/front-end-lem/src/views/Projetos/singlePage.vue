<template>
  <section class="text-gray-600 body-font overflow-hidden">
  <div class="container px-5 py-24 mx-auto">
      <div class="lg:w-4/5 mx-auto flex flex-wrap">
          <div class="lg:w-4/6 w-full lg:pr-10 lg:py-6 mb-6 lg:mb-0">
            <h1 class="text-gray-900 text-3xl title-font font-medium mb-4">{{projeto.title}}</h1>
            <p class="leading-relaxed mb-4">{{projeto.text}}</p>
              <div class="flex border-t border-gray-200 py-2">
                <span class="text-gray-500">Autor</span>
                <span class="ml-auto text-gray-900">{{projeto.authorName}}</span>
              </div>
          </div>
        <img alt="Imagem Projeto" class="lg:w-2/6 w-full lg:h-auto h-64 object-cover object-center rounded" :src="projeto.urlImage">
      </div>
  </div>
</section>
</template>

<script>
import { useRoute } from 'vue-router'
import services from '../../services'
export default {

  data () {
    const projeto = {}
    return {
      projeto
    }
  },

  methods: {
    async getSingleProject () {
      const { data, errors } = await services.proj.getSingle(this.id)
      if (!errors) {
        this.projeto = data
      } else {
        console.log(errors)
      }
    }
  },

  setup () {
    const route = useRoute()
    const id = route.params.id

    return {
      id
    }
  },

  mounted () {
    this.getSingleProject()
  }

}
</script>
