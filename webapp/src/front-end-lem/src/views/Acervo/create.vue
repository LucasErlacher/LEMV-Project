<template>
  <div class="flex justify-center w-full">
    <h1 class="text-4xl font-black text-gray-800"> Criar acervo
    </h1>
  </div>

  <div>
    <div class="mt-16 mx-2 md:mx-32 lg:mx-64">
      <form
       v-on:uploadImg="setMedia($event)"
       @submit.prevent="handleSubmit">
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
  props: ['name', 'tags', 'description', 'resume', 'authorName', 'id', 'resumeON', 'medias'],

  setup (props) {
    const file = ref(null)
    const mediafile = ref(null)
    const toast = useToast()
    const router = useRouter()
    const skills = []
    const abilityOptions = []
    let selectCompetence // competencia selecionada
    const currentAbilities = [] // lista abilidades selecionadas
    const partialTags = ''

    const state = reactive({
      skills,
      abilityOptions,
      currentAbilities,
      selectCompetence,
      file: file,
      hasErrors: false,
      isLoading: false,

      artifact: {
        id: props.id,
        name: props.name,
        description: props.description,
        authorName: props.authorName,
        resume: props.resume,
        media: props.media,
        urlImages: [],
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
        console.log(state.artifact)
        const { data, errors } = await services.art.createOne(state.artifact)
        if (!errors) {
          state.isLoading = false
          toast.success(`Item ${data.data.id} criado com sucesso!`)
          router.push({ name: 'AdministradorAcervo' })
        }
        state.isLoading = false
      } catch (error) {
        state.isLoading = false
        state.hasErrors = !!error
        toast.error('Ops, ocorreu um erro ao tentar criar o item')
        router.push({ name: 'AdministradorAcervo' })
      }
    }

    async function handleImageUpload () {
      const { data, errors } = await services.image.upload(file.value.files)
      if (!errors) {
        toast.success('Imagem anexada com sucesso')
        state.artifact.urlImages.push(data.url)
      } else {
        toast.error('Falha ao salvar a imagem')
        console.log(errors)
      }
    }

    function setSkillToSend () {
      state.artifact.skillId = state.selectCompetence.id
      state.artifact.abilitieIds = filterAbilityIds()
    }

    // verifica se os campos obrigatórios estão preenchidos
    // e prepara o objeto para a API
    function validSchema () {
      try {
        state.artifact.tags = state.artifact.tags.split(',')
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

    async function handleFileUpload () {
      const { data, errors } = await services.file.upload(mediafile.value.files)
      if (!errors) {
        toast.success('Arquivo anexado com sucesso')
        state.artifact.media = data.value
      } else {
        console.log(errors)
      }
    }

    return {
      state,
      handleSubmit,
      handleFileUpload,
      handleImageUpload,
      file,
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
