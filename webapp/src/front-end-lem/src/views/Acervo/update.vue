<template>
  <div class="flex justify-center w-full">
    <h1 class="text-4xl font-black text-gray-800"> Atualizar Acervo
    </h1>
  </div>

  <div>
    <div class="mt-16 mx-2 md:mx-32 lg:mx-64">
      <form @submit.prevent="handleSubmit">
        <base-input
        v-model="state.artifact.name"
        label="Nome"
        type="text"
        />

        <base-input-large
        v-model="state.artifact.resume"
        label="Resumo"
        />

        <base-input
        v-model="state.artifact.tags"
        label="Palavras-chaves"
        placeholder="tag, tag, tag (separado com vírgula)"
        type="text"
        />

        <label class="block">
          <span class="text-lg font-medium text-gray-600">Imagem</span>
          <div>
            <input ref="file" v-on:change="handleImageUpload()"  type="file">
              <img
              :src="urlImage"
              alt="Preview" v-for="urlImage in state.artifact.urlImages"
              :key="urlImage"
              width="50" height="50">
          </div>
        </label>

        <label class="block">
          <span class="text-lg font-medium text-gray-600">Mídia para download</span>
          <div>
            <input ref="mediafile" v-on:change="handleFileUpload()"  type="file">
              <i v-if="state.artifact.media" class="material-icons-outlined text-green-500">description</i>
          </div>
        </label>

        <base-input-large
        v-model="state.artifact.description"
        label="Texto Principal"
        />

        <label class="block">
          <span class="text-lg font-medium text-gray-600">Competências</span>
          <select-input :options="state.skills" @currentSelect="updateSelectCompetence($event)"/>
          <span class="text-lg font-medium text-gray-600">Habilidades</span>
          <checkbox :options="state.abilityOptions" @updateState="updateSelectAbility($event)"/>
        </label>

        <button :disabled="state.isLoading"
        type="submit"
        :class="{'opacity-50': state.isLoading}"
        class="px-8 py-3 mt-10 text-2x1 font-bold text-white rounded bg-brand-main focus:outline-nome"
        >
          Atualizar
        </button>
      </form>
    </div>
  </div>
</template>

<script>
import { reactive, ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useToast } from 'vue-toastification'
import services from '../../services'
import baseInput from '../../components/Form/baseInput.vue'
import baseInputLarge from '../../components/Form/baseInputLarge.vue'
import selectInput from '../../components/Form/selectInput.vue'
import Checkbox from '../../components/Form/checkbox.vue'

export default {
  components: { baseInput, baseInputLarge, selectInput, Checkbox },
  props: ['name', 'resume', 'text', 'details', 'id', 'resumeON', 'media'],

  setup (props) {
    const file = ref(null)
    const mediafile = ref(null)
    const route = useRoute()
    const router = useRouter()
    const skills = []
    const abilityOptions = []
    let selectCompetence // competencia selecionada
    const currentAbilities = [] // lista habilidades selecionadas

    let data
    route.params.data != null ? data = JSON.parse(route.params.data) : data = ''
    const partialTags = data.tags.toString()
    const toast = useToast()

    const state = reactive({
      hasErrors: false,
      isLoading: false,

      skills,
      abilityOptions,
      currentAbilities,
      selectCompetence,
      partialTags,

      artifact: {
        id: route.params.id,
        name: data.name,
        description: data.description,
        resume: data.resume,
        urlImages: data.urlImages,
        media: data.media,
        skillId: -1,
        abilitieIds: [],
        tags: partialTags
      }
    })

    async function handleSubmit () {
      try {
        toast.clear()
        state.isLoading = true
        validSchema()
        console.log(JSON.stringify(state.artifact))
        const { data, errors } = await services.art.updateOne(state.artifact.id, state.artifact)
        if (!errors) {
          state.isLoading = false
          toast.success(`Item ${data.data.id} atualizado com sucesso!`)
          router.push({ name: 'AdministradorAcervo' })
        }
        state.isLoading = false
      } catch (error) {
        console.error(error)
        state.isLoading = false
        state.hasErrors = !!error
        toast.error('Ops, ocorreu um erro ao tentar atualizar o item')
        router.push({ name: 'AdministradorAcervo' })
      }
    }

    async function handleFileUpload () {
      const { data, errors } = await services.file.upload(mediafile.value.files)
      if (!errors) {
        toast.success('Arquivo anexado com sucesso')
        state.artifact.media = data.value
      } else {
        console.log(errors)
      }
    }

    async function handleImageUpload () {
      const { data, errors } = await services.image.upload(file.value.files)
      if (!errors) {
        toast.success('Imagem anexada com sucesso')
        state.artifact.urlImages.push(data.url)
      } else {
        console.log(errors)
      }
    }

    function setSkillToSend () {
      state.artifact.skillId = state.selectCompetence.id
      state.artifact.abilitieIds = filterAbilityIds()
      if (state.artifact.abilitieIds.length === 0) {
        console.log(data.skill)
        if (data.skill) {
          const currentAbilities = data.skill.abilities.map((i) => i.id)
          state.artifact.skillId = data.skill.id
          state.artifact.abilitieIds = currentAbilities
        }
      }
    }

    // verifica se os campos obrigatórios estão preenchidos
    // e prepara o objeto para a API
    function validSchema () {
      try {
        state.artifact.tags = state.artifact.tags.split(',')
        // TODO valid schema
        setSkillToSend()
      } catch (error) {
        toast.warning(error)
      }
    }

    async function getSkills () {
      const { data, errors } = await services.skill.getAll()
      if (!errors) {
        this.state.skills = data
        this.state.artifact.skillId = data[0].id
        this.state.selectCompetence = data[0]
        this.state.abilityOptions = data[0].abilities
      } else {
        console.log(errors)
      }
    }

    function updateSelectCompetence (value) {
      console.log(`ID: ${value}`)
      console.log({ cards: state.skills })

      state.selectCompetence = state.skills.find(c => c.code === value)

      console.log(state.selectCompetence)
      state.artifact.skillId = state.selectCompetence.id
      state.abilityOptions = state.selectCompetence.abilities
    }

    function updateSelectAbility (value) {
      console.log({ event: value })
      state.currentAbilities = value
    }

    // a partir da lista de skills selecionadas retornando uma lista de ids das habilidades
    // correspondentes a competencia selecionada
    function filterAbilityIds () {
      const filterByCompetence = state.currentAbilities.filter((i) => state.selectCompetence.abilities.includes(i))
      return filterByCompetence.map((i) => i.id)
    }

    return {
      state,
      mediafile,
      handleSubmit,
      handleFileUpload,
      ref,
      file,
      updateSelectAbility,
      updateSelectCompetence,
      getSkills,
      validSchema,
      handleImageUpload
    }
  },
  mounted () {
    this.getSkills()
  }

}
</script>
