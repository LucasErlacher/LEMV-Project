<template>
    <div class="py-8 flex flex-wrap md:flex-nowrap">
        <div class="md:flex-grow">
            <h2 class="text-2xl font-medium text-gray-900 title-font mb-2">{{code}}</h2>
            <p class="leading-relaxed">{{description}}</p>
            <div class="flex space-x-4 py-4">
                <button v-on:click="() => $emit('competenceUpdate', $props)"
                    class='ml-auto text-brand-main flex items-center gap-1 sm:text-lg border border-gray-300 px-3 py-1 rounded-full hover:bg-yellow-500 hover:text-white transition-colors focus:bg-gray-100 focus:outline-none focus-visible:border-gray-500'>
                    <span>Atualizar</span>
                </button>
                <button v-on:click="() => $emit('competenceDelete',  $props)"
                    class='ml-auto text-brand-main flex items-center gap-1 sm:text-lg border border-gray-300 px-3 py-1 rounded-full hover:bg-red-500 hover:text-white transition-colors focus:bg-gray-100 focus:outline-none focus-visible:border-gray-500'>
                    <span>Deletar</span>
                </button>
            </div>
            <div v-if="!state.visibleAbilities">
                <a class="text-green-500 inline-flex items-center mt-4">Visualizar habilidades
                    <button v-on:click="changeVisibleAbilities()">
                        <svg class="w-4 h-4 ml-2" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M5 12h14"></path>
                            <path d="M12 5l7 7-7 7"></path>
                        </svg>
                    </button>
                </a>
            </div>
            <div v-else>
                <abiliti v-for="a in abilities" :key="a.code" :code="a.code" :description="a.description" :id="a.id"/>
                <svg v-on:click="changeVisibleAbilities()" class="w-4 h-4 ml-2" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round">
                    <path d="M5 12h14"></path>
                    <path d="M12 5l7 7-7 7"></path>
                </svg>
            </div>
        </div>
    </div>
</template>

<script>
import abiliti from './abiliti.vue'
import { reactive } from 'vue'
export default {
  components: { abiliti },
  props: ['id', 'code', 'description', 'abilities'],

  setup () {
    const visibleAbilities = false
    const state = reactive({
      visibleAbilities
    })

    function changeVisibleAbilities () {
      state.visibleAbilities = !state.visibleAbilities
    }

    return {
      state,
      changeVisibleAbilities
    }
  }

}
</script>
