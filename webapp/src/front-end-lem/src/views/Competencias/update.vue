<template>
  <div class="flex justify-center w-full">
    <h1 class="text-4xl font-black text-gray-800"> Atualizar Competência</h1>

  </div>

  <div>
    <div class="mt-16 mx-2 md:mx-32 lg:mx-64">
      <form
       @submit.prevent="handleSubmit">
        <base-input
        v-model="state.skill.code"
        label="Código"
        type="text"
        />

        <base-input-large
        v-model="state.skill.description"
        label="Descrição"
        />
          <div class="mt-4 mx-4">
            <span class="text-lg font-medium text-gray-600"> Habilidades </span>
            <form @submit.prevent="handleAbiliti">
              <base-input
              v-model="state.pAbilities.code"
              label="Código"
              type="text"
              />

              <base-input
              v-model="state.pAbilities.description"
              label="Descrição"
              type="text"
              />

              <button :disabled="state.isLoading"
              type="submit"
              :class="{'opacity-50': state.isLoading}"
              class="px-8 py-3 mt-5 text-2x1 font-bold text-white rounded bg-brand-main focus:outline-nome"
              >
              Add
              </button>
            </form>
        </div>

        <button :disabled="state.isLoading"
        type="submit"
        :class="{'opacity-50': state.isLoading}"
        class="px-8 py-3 mt-10 text-2x1 font-bold text-white rounded bg-brand-main focus:outline-nome"
        >
          Atualizar
        </button>

      </form>
      <div class="w-50">
      <competence
      @edit="editAbility($event)"
      @remove="removeAbility($event)"
      :code="state.skill.code" :description="state.skill.description" :abilities="state.skill.abilities" edit="true"/>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive, ref } from 'vue'
import Competence from '../../components/Card/competence.vue'
import { useRouter, useRoute } from 'vue-router'
import { useToast } from 'vue-toastification'
import services from '../../services'
import baseInput from '../../components/Form/baseInput.vue'
import baseInputLarge from '../../components/Form/baseInputLarge.vue'

export default {
  components: { baseInput, baseInputLarge, Competence },
  props: ['id', 'code', 'description', 'abilities'],

  setup (props) {
    const file = ref(null)
    const route = useRoute()
    let data
    route.params.data != null ? data = JSON.parse(route.params.data) : data = ''
    const toast = useToast()
    const router = useRouter()

    const state = reactive({
      file: file,
      hasErrors: false,
      isLoading: false,
      abilities: [],
      pAbilities: {
        code: '',
        description: ''
      },

      skill: {
        id: data.id,
        code: data.code,
        description: data.description,
        abilities: data.abilities
      }

    })

    function addAbility (ability) {
      for (let index = 0; index < state.skill.abilities.length; index++) {
        const element = state.skill.abilities[index]
        if (element.code === ability.code) {
          state.skill.abilities[index].description = ability.description
          return
        }
      }
      state.skill.abilities.push({ ...ability })
    }

    function handleAbiliti () {
      var ability = { ...state.pAbilities }
      addAbility(ability)
      state.pAbilities = {
        code: '',
        description: ''
      }
    }

    async function handleSubmit () {
      try {
        toast.clear()
        state.isLoading = true
        const { data, errors } = await services.skill.updateOne(state.skill)
        if (!errors) {
          state.isLoading = false
          toast.success(`Competência ${data.data.id} atualizada com sucesso!`)
          router.push({ name: 'AdministradorCompetencias' })
        }
        state.isLoading = false
      } catch (error) {
        state.isLoading = false
        state.hasErrors = !!error
        toast.error('Ops, ocorreu um erro ao tentar atualizar o item')
        router.push({ name: 'AdministradorCompetencias' })
      }
    }

    function editAbility (ability) {
      state.pAbilities.code = ability.code
      state.pAbilities.description = ability.description
    }

    function removeAbility (ability) {
      state.skill.abilities = state.skill.abilities.filter(item => item.code !== ability.code)
    }

    return {
      state,
      handleSubmit,
      handleAbiliti,
      editAbility,
      removeAbility,
      addAbility
    }
  }

}
</script>
