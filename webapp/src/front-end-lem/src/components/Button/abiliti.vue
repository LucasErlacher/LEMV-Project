<template>
    <div v-on:click="() => {state.visible = !state.visible}">
        <td class="px-4 py-3 text-lg text-gray-900">{{ability.code}}</td>
        <p v-if="state.visible" class="flex space-x-2 text-gray-400 text-sm w-full h-40">{{ability.description}}</p>
    </div>
</template>

<script>
import { reactive } from 'vue'

export default {
  props: ['ability'],

  setup () {
    const visible = false
    const state = reactive({
      visible
    })

    function changeVisibility () {
      state.visible = !state.visible
      console.log(state.visible)
    }

    return {
      state,
      changeVisibility
    }
  }
}
</script>
