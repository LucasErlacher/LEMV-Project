<template>
  <div class="flex justify-center w-full">
    <h1 class="text-4xl font-black text-gray-800"> Criar notícia
    </h1>
  </div>

  <div>
    <div class="mt-16 mx-2 md:mx-32 lg:mx-64">
      <form
       v-on:uploadImg="setMedia($event)"
       @submit.prevent="handleSubmit">
        <base-input
        v-model="state.news.title"
        label="Título"
        type="text"
        />

        <base-input-large
        v-model="state.news.resume"
        label="Resumo"
        />

        <base-input-large
        v-model="state.news.description"
        label="Descrição"
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
          <div>
            <input ref="image" v-on:change="handleImageUpload()"  type="file">
            <img :src="state.news.urlImage" alt="Preview" v-if="state.news.urlImage" width="50" height="50">
          </div>
        </label>

        <label class="block">
          <span class="text-lg font-medium text-gray-600">Mídia para download</span>
          <div>
            <input ref="mediafile" v-on:change="handleMediaUpload()"  type="file">
            <i v-if="state.news.media" class="material-icons-outlined text-green-500">description</i>
          </div>
        </label>

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
          Criar
        </button>

      </form>
    </div>
  </div>
</template>

<script>
import { reactive, ref } from 'vue'
import { useRouter } from 'vue-router'
import { useToast } from 'vue-toastification'
import services from '../../services'
import baseInput from '../../components/Form/baseInput.vue'
import baseInputLarge from '../../components/Form/baseInputLarge.vue'
import selectInput from '../../components/Form/selectInput.vue'
import Checkbox from '../../components/Form/checkbox.vue'

export default {
  components: { baseInput, baseInputLarge, selectInput, Checkbox },
  props: ['title', 'img', 'resume', 'details', 'id', 'resumeON', 'media', 'description'],

  setup (props) {
    const image = ref(null)
    const mediafile = ref(null)
    const toast = useToast()
    const router = useRouter()
    const skills = []
    const abilityOptions = []
    let selectCompetence // competencia selecionada
    const currentAbilities = [] // lista habilidades selecionadas

    const state = reactive({
      skills,
      abilityOptions,
      currentAbilities,
      selectCompetence,
      image: image,
      mediafile: mediafile,
      hasErrors: false,
      isLoading: false,

      news: {
        id: props.id,
        title: props.title,
        resume: props.resume,
        description: props.description,
        authorName: props.authorName,
        urlImage: props.url,
        tags: props.tags,
        media: props.media,
        skillId: -1,
        abilitieIds: []
      }
    })

    async function handleSubmit () {
      try {
        toast.clear()
        state.isLoading = true
        validSchema()
        console.log(state.news)
        const { data, errors } = await services.news.createOne(state.news)
        if (!errors) {
          state.isLoading = false
          toast.success(`Item ${data.data.id} criado com sucesso!`)
          router.push({ name: 'AdministradorNoticias' })
        }
        state.isLoading = false
      } catch (error) {
        console.log(state.news)
        state.isLoading = false
        state.hasErrors = !!error
        toast.error('Ops, ocorreu um erro ao tentar criar o item')
        router.push({ name: 'AdministradorNoticias' })
      }
    }

    async function handleImageUpload () {
      const { data, errors } = await services.image.upload(image.value.files)
      if (!errors) {
        toast.success('Imagem anexada com sucesso')
        state.news.urlImage = data.url
      } else {
        console.log(errors)
      }
    }

    async function handleMediaUpload () {
      const { data, errors } = await services.file.upload(mediafile.value.files)
      if (!errors) {
        toast.success('Media anexada com sucesso')
        state.news.media = data.value
      } else {
        console.log(errors)
      }
    }

    function setSkillToSend () {
      state.news.skillId = state.selectCompetence.id
      state.news.abilitieIds = filterAbilityIds()
    }

    // verifica se os campos obrigatórios estão preenchidos
    // e prepara o objeto para a API
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
      handleImageUpload,
      handleMediaUpload,
      image,
      mediafile,
      getSkills,
      updateSelectCompetence,
      updateSelectAbility,
      filterAbilityIds,
      setSkillToSend,
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
