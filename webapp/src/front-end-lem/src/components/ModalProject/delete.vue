<template>
  <div class="flex justify-between">
    <h1 class="text-2xl font-black text-gray-800"> Tem certeza que deseja deletar?
    </h1>
    <button
    class="text-4xl text-gray-600 focus:outline-none"
    @click='close'>&times;
    </button>
  </div>

    <div>
      <h2 class="text-2xl font-black text-gray-500">Item de Id: {{ id }}</h2>
    </div>

  <div>
    <div class="mt-16">
      <form @submit.prevent="handleSubmit">

        <button :disabled="state.isLoading" @click="close"
        :class="{'opacity-50': state.isLoading}"
        class="px-8 py-3 mt-10 text-2x1 font-bold text-white rounded bg-brand-main focus:outline-nome"
        >
          Voltar
        </button>

        <button :disabled="state.isLoading"
        type="submit"
        :class="{'opacity-50': state.isLoading}"
        class="px-8 py-3 mt-10 text-2x1 font-bold text-white rounded bg-red-500 focus:outline-nome"
        >
          Deletar
        </button>
      </form>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { useToast } from 'vue-toastification'
import useModal from '../../hooks/useModal'
import services from '../../services'

export default {
  props: ['title', 'img', 'resume', 'details', 'id', 'resumeON'],

  setup (props) {
    console.log(props.id)
    const modal = useModal()
    const toast = useToast()

    const state = reactive({
      hasErrors: false,
      isLoading: false,
      reponse: Object
    })

    async function handleSubmit () {
      try {
        toast.clear()
        state.isLoading = true
        const { data, errors } = await services.proj.deleteOne(props.id)
        if (!errors) {
          state.isLoading = false
          state.reponse = data
          modal.close()
          toast.success(`Item ${props.id} deletado com sucesso`)
          return
        }
        state.isLoading = false
      } catch (error) {
        state.isLoading = false
        state.hasErrors = !!error
        toast.error('Ops, ocorreu um erro ao tentar deletar o item')
      }
    }

    return {
      state,
      handleSubmit,
      close: modal.close
    }
  }

}
</script>
