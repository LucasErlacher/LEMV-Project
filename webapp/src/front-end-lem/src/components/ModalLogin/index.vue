<template>
  <div class="flex justify-between">
    <h1 class="text-2xl font-black text-gray-800"> Login
    </h1>
    <button
    class="text-4xl text-gray-600 focus:outline-none"
    @click='close'>&times;
    </button>
  </div>

  <div>
    <div class="mt-16">
      <form @submit.prevent="handleSubmit">
        <label class="block">
          <span class="text-lg font-medium text-gray-600">Matrícula</span>

          <input
          id="matricula-field"
          v-model="state.matricula.value"
          type="text"
          :class="{'border-brand-danger': !!state.matricula.errorMensage}"
          class="clock w-full px-4 py-3 mt-1 text-lg bg-gray-100 border-transparent rounded"
          placeholder="Matrícula">

          <span v-if="!!state.matricula.errorMessage"
          class="block font-medium text-brand-danger">
          {{ state.matricula.errorMessage }}
          </span>
        </label>
        <label class="block">
          <span class="text-lg font-medium text-gray-600">Senha</span>

          <input
          v-model="state.senha.value"
          type="password"
          :class="{'border-brand-danger': !!state.senha.errorMensage}"
          class="clock w-full px-4 py-3 mt-1 text-lg bg-gray-100 border-transparent rounded"
          placeholder="Senha">

          <span v-if="!!state.senha.errorMessage"
          class="block font-medium text-brand-danger">
          {{ state.senha.errorMessage }}
          </span>
        </label>
        <button :disabled="state.isLoading"
        type="submit"
        :class="{'opacity-50': state.isLoading}"
        class="px-8 py-3 mt-10 text-2x1 font-bold text-white rounded bg-brand-main focus:outline-nome"
        >
          Entrar
        </button>
      </form>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { useRouter } from 'vue-router'
import { useField } from 'vee-validate'
import { useToast } from 'vue-toastification'
import useModal from '../../hooks/useModal'
import { validateEmpty } from '../../utils/validators'
import services from '../../services'

export default {
  setup () {
    const router = useRouter()
    const modal = useModal()
    const toast = useToast()

    const {
      value: matriculaValue,
      errorMessage: matriculaErrorMenssage
    } = useField('matricula', validateEmpty)

    const {
      value: senhaValue,
      errorMessage: senhaErrorMenssage
    } = useField('senha', validateEmpty)

    const state = reactive({
      hasErrors: false,
      isLoading: false,
      matricula: {
        value: matriculaValue,
        errorMessage: matriculaErrorMenssage
      },
      senha: {
        value: senhaValue,
        errorMessage: senhaErrorMenssage
      }
    })

    async function handleSubmit () {
      try {
        toast.clear()
        state.isLoading = true
        const { data, errors } = await services.auth.login({
          matricula: state.matricula.value,
          senha: state.senha.value
        })
        if (!errors) {
          window.localStorage.setItem('token', data.token)
          router.push({ name: 'Administrador' })
          state.isLoading = false
          modal.close()
          toast.success('Bem vindo!')
          return
        }
        if (errors.status === 404) {
          toast.error('Matrícula não encontrada')
        }
        if (errors.status === 401) {
          toast.error('Matrícula ou senha invalidas')
        }
        if (errors.status === 400) {
          toast.error('Ops, ocorreu um erro ao tentar realizar o login')
        }
        state.isLoading = false
      } catch (error) {
        state.isLoading = false
        state.hasErrors = !!error
        toast.error('Ops, ocorreu um erro ao tentar realizar o login')
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
