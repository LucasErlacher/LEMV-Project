<template>
  <div class="bg-white w-80 max-w-3xl sm:w-full sm:p-4 h-auto sm:h-64 rounded-2xl shadow-lg flex flex-col sm:flex-row gap-5 select-none p-1">
    <div
        :style="{backgroundImage: 'url(\'' + urlImage + '\')'}"
        class="h-52 sm:h-full sm:w-72 rounded-xl bg-gray-100 bg-center bg-cover"
    ></div>
    <div class="flex sm:flex-1 flex-col gap-2 p-1">
        <h1 class="text-lg sm:text-xl font-semibold  text-gray-600">
            {{title}}
        </h1>
        <p class="text-gray-500 text-sm sm:text-base line-clamp-3">
            {{description}}
        </p>
        <div class="flex gap-4 mt-auto">

        <span class='mr-auto text-brand-main flex items-center gap-1 sm:text-lg '>
        {{authorName}}
        </span>
        <button v-on:click="pushSinglePage()"
            class='ml-auto text-brand-main flex items-center gap-1 sm:text-lg border border-gray-300 px-3 py-1 rounded-full hover:bg-gray-50 transition-colors focus:bg-gray-100 focus:outline-none focus-visible:border-gray-500'
        >
            <span>Ler mais</span>
        </button>
        </div>
    </div>
</div>
</template>

<script>
import { useRouter } from 'vue-router'

export default {
  props: ['id', 'title', 'urlImage', 'description', 'authorName', 'redirect'],

  setup (props) {
    const router = useRouter()

    function pushSinglePage (id) {
      router.push({ name: props.redirect, params: { id: props.id } })
    }

    return {
      pushSinglePage
    }
  }
}

</script>
