<template>
  <div class="bg-white w-80 max-w-3xl sm:w-full sm:p-4 h-auto sm:h-64 rounded-2xl shadow-lg flex flex-col sm:flex-row gap-5 select-none p-1">
    <div
        :style="{ backgroundImage: `url('${urlImage}')` }"
        class="h-52 sm:h-full sm:w-52 rounded-xl bg-gray-100 bg-center bg-cover hidden lg:block"
    ></div>
    <div class="flex sm:flex-1 flex-col gap-2 p-1">
        <h1 class="text-lg sm:text-xl font-semibold  text-gray-600">
            {{title}}
        </h1>
        <p v-if="resumeON" class="text-gray-500 text-sm sm:text-base line-clamp-3">
            {{resume}}
        </p>
        <div class="flex gap-4 mt-auto">
        <span class='mr-auto text-brand-main flex items-center gap-1 sm:text-lg '>
        {{authorName}}
        </span>
        <button v-on:click="() => $emit('projectUpdate', $props)"
            class='ml-auto text-brand-main flex items-center gap-1 sm:text-lg border border-gray-300 px-3 py-1 rounded-full hover:bg-yellow-500 hover:text-white transition-colors focus:bg-gray-100 focus:outline-none focus-visible:border-gray-500'>
            <span>Atualizar</span>
        </button>
        <button v-on:click="() => $emit('projectDelete',  $props)"
            class='ml-auto text-brand-main flex items-center gap-1 sm:text-lg border border-gray-300 px-3 py-1 rounded-full hover:bg-red-500 hover:text-white transition-colors focus:bg-gray-100 focus:outline-none focus-visible:border-gray-500'>
            <span>Deletar</span>
        </button>
        </div>
    </div>
</div>
</template>

<script>

import { reactive } from 'vue'
import services from '../../services'

export default {
  props: ['title', 'resume', 'authorName', 'description', 'id', 'resumeON', 'manual', 'media', 'urlImage', 'tags', 'skill'],

  setup (props) {
    const img = '/img/principal.aa4e4091.png'
    const state = reactive({
      img
    })

    async function downloadImg () {
      if (props.media != null) {
        const { data, errors } = await services.file.download(props.media.id)
        if (!errors) {
          var fileURL = window.URL.createObjectURL(new Blob([data]))
          this.state.img = fileURL
        } else {
          console.log('result')
          console.log(errors)
        }
      }
    }

    async function toDownloadFile (data, format) {
      var fileURL = window.URL.createObjectURL(new Blob([data]))
      var fileLink = document.createElement('a')

      fileLink.href = fileURL
      fileLink.setAttribute('download', format)
      document.body.appendChild(fileLink)

      fileLink.click()
    }

    return {
      downloadImg,
      toDownloadFile,
      state
    }
  },

  mounted () {
  }
}

</script>
