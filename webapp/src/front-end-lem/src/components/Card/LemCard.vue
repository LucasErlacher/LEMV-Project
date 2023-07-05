<template>
  <div class="bg-white w-80 max-w-3xl sm:w-full sm:p-4 h-auto sm:h-64 rounded-2xl shadow-lg flex flex-col sm:flex-row gap-5 select-none p-1">
    <div
        :style="{ backgroundImage: `url('${img}')` }"
        class="h-52 sm:h-50 sm:w-52 rounded-xl bg-gray-100 bg-center bg-cover hidden lg:block"
    ></div>
    <div class="flex sm:flex-1 flex-col gap-2 p-1">
        <h1 v-if="resumeON" class="text-lg sm:text-xl font-semibold  text-gray-600">
            {{ title }}
        </h1>
        <h1 v-else class="text-lg sm:text-sm font-semibold  text-gray-600">
            {{ title }}
        </h1>
        <p v-if="resumeON" class="text-gray-500 text-sm sm:text-base line-clamp-3">
            {{ resume }}
        </p>
        <div class="flex flex-wrap justify-between mt-auto">
          <div class="inline-grid grid-cols-2 gap-3">
            <div v-if="resumeON && authorName != ''">
              <h3 class="text-sm sm:text-x1 font-semibold  text-gray-600">
              {{'Autor'}}
              </h3>
              <span class='mr-auto text-brand-main flex items-center gap-1 sm:text-sm '>
              {{authorName}}
              </span>
            </div>
            <div v-if="resumeON && tags.length != 0" class="w-120">
                <h3 class="text-sm sm:text-x1 font-semibold  text-gray-600">
                {{'Palavras-chave'}}
                </h3>
                <span class='mr-auto w-20 text-brand-main flex items-center gap-1 sm:text-sm '>
                {{tags.toString()}}
                </span>
            </div>
          </div>
        <button v-on:click="pushPage()"
            class='ml-auto text-brand-main flex items-center gap-1 sm:text-lg border border-gray-300 px-3 py-1 rounded-full hover:bg-gray-50 transition-colors focus:bg-gray-100 focus:outline-none focus-visible:border-gray-500'>
            <span>mais</span>
        </button>
        </div>
    </div>
</div>
</template>

<script>
import { useRouter } from 'vue-router'

export default {
  props: {
    title: {
      default: '',
      type: String
    },
    img: {
      default: '/img/principal.aa4e4091.png',
      type: String
    },
    resume: {
      default: '',
      type: String
    },
    description: {
      default: ''
    },
    authorName: {
      default: ''
    },
    redirect: {

    },
    id: {
      default: ''
    },
    resumeON: {
      default: true
    },
    tags: {
      default: []
    }
  },
  setup (props) {
    const router = useRouter()

    function pushPage () {
      console.log(props)
      console.log(props.redirect)
      console.log(props.id)

      router.push({ name: props.redirect, params: { id: props.id } })
    }

    return {
      pushPage
    }
  }
}

</script>
