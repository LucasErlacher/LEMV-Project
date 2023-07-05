<template>
    <div class="py-8 flex flex-wrap md:flex-nowrap">
        <div class="md:flex-grow">
            <h2 class="text-2xl font-medium text-gray-900 title-font mb-2">{{code}}</h2>
            <p class="leading-relaxed">{{description}}</p>
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
                <abiliti v-for="a in abilities" :key="a.code" :code="a.code" :description="a.description" :id="a.id" :edit="edit"
                  @edit="$emit('edit', $event)"
                  @remove="$emit('remove',  $event)"
                />
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
  props: ['id', 'code', 'description', 'abilities', 'edit'],

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
