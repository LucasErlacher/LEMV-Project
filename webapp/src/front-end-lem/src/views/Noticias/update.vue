<template>
  <div class="flex justify-center w-full">
    <h1 class="text-4xl font-black text-gray-800"> Atualizar notícia
    </h1>
  </div>

  <div>
    <div class="mt-16 mx-2 md:mx-32 lg:mx-64">
      <form @submit.prevent="handleSubmit">
        <base-input
        v-model="state.news.title"
        label="Título"
        type="text"
        />

        <base-input-large
        v-model="state.news.resume"
        label="Resumo"
        />

        <base-input
        v-model="state.news.authorName"
        label="Nome do autor"
        type="text"
        />

        <base-input
        v-model="state.news.tags"
        label="Palavras-chaves"
        placeholder="tag, tag, tag (separado com vírgula)"
        type="text"
        />

        <label class="block">
          <span class="text-lg font-medium text-gray-600">Imagem</span>
          <div class="flex flex-col">
            <input ref="file" v-on:change="handleImageUpload()" type="file">
            <img :src="state.news.urlImage" alt="Preview" v-if="state.news.urlImage" width="50" height="50">
          </div>
        </label>

        <label class="block">
          <span class="text-lg font-medium text-gray-600">Mídia para download</span>
          <div class="flex flex-col">
            <input ref="mediafile" v-on:change="handleFileUpload()"  type="file">
            <i v-if="state.news.media" class="material-icons-outlined text-green-500">description</i>
          </div>
        </label>

        <base-input-large
        v-model="state.news.description"
        label="Descrição"
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
  props: ['title', 'img', 'resume', 'description', 'details', 'id', 'resumeON', 'urlImage'],

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
    route.params.data != null ? data = JSON.parse(route.params.data) : data = {}
    const partialTags = data.tags.toString() || ''
    const toast = useToast()

    const state = reactive({
      hasErrors: false,
      isLoading: false,

      skills,
      abilityOptions,
      currentAbilities,
      selectCompetence,
      partialTags,

      news: {
        id: route.params.id,
        title: data.title,
        description: data.description,
        authorName: data.details,
        resume: data.resume,
        urlImage: data.urlImage,
        media: data.media,
        tags: partialTags,
        skillId: -1,
        abilitieIds: []
      }
    })

    async function handleSubmit () {
      try {
        toast.clear()
        state.isLoading = true
        validSchema()
        const { data, errors } = await services.news.updateOne(state.news.id, state.news)
        if (!errors) {
          state.isLoading = false
          toast.success(`Item ${data.data.id} atualizado com sucesso!`)
          router.push({ name: 'AdministradorNoticias' })
        }
        state.isLoading = false
      } catch (error) {
        console.error(error)
        console.log({ send: state.news })
        state.isLoading = false
        state.hasErrors = !!error
        toast.error('Ops, ocorreu um erro ao tentar atualizar o item')
      }
    }

    async function handleImageUpload () {
      const { data, errors } = await services.image.upload(file.value.files)
      if (!errors) {
        console.log(data)
        toast.success('Imagem anexada com sucesso')
        state.news.urlImage = data.url
      } else {
        console.log(errors)
      }
    }

    async function handleFileUpload () {
      const { data, errors } = await services.file.upload(mediafile.value.files)
      if (!errors) {
        console.log(data)
        toast.success('Mídia anexada com sucesso')
        state.news.media = data.value
      } else {
        console.log(errors)
      }
    }

    function setSkillToSend () {
      state.news.skillId = state.selectCompetence.id
      state.news.abilitieIds = filterAbilityIds()
      if (state.news.abilitieIds.length === 0) {
        console.log(data.skill)
        if (data.skill) {
          const currentAbilities = data.skill.abilities.map((i) => i.id)
          state.news.skillId = data.skill.id
          state.news.abilitieIds = currentAbilities
        }
      }
    }

    // verifica se os campos obrigatórios estão preenchidos
    // e preparar o objeto para a API
    function validSchema () {
      try {
        state.news.tags = state.news.tags.split(',')
        setSkillToSend()
      } catch (error) {
        toast.warning(error)
      }
    }

    async function getSkills () {
      const { data, errors } = await services.skill.getAll()
      if (!errors) {
        this.state.skills = data
        this.state.news.skillId = data[0].id
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
      state.news.skillId = state.selectCompetence.id
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
      handleSubmit,
      handleFileUpload,
      handleImageUpload,
      mediafile,
      ref,
      file,
      updateSelectAbility,
      updateSelectCompetence,
      getSkills,
      validSchema
    }
  },
  mounted () {
    this.getSkills()
  }

}
</script>

<style>
.material-icons-outlined {
  font-family: 'Material Symbols Outlined', sans-serif;
  font-size: 30px;
}
</style>
