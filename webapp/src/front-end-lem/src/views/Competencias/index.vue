<template>
  <section class="text-gray-600 body-font overflow-hidden">
    <div class="flex flex-col items-center w-full mx-auto px-6 py-8 gap-1">
      <h1 class="text-4xl font-black text-black"> Base Nacional Comum Curricular</h1>
      <span class="text-lg w-2/4 font-medium mt-10 text-gray">
      "A Base Nacional Comum Curricular (BNCC) é um documento de caráter
      normativo que defineo conjunto orgânico e progressivo de
      aprendizagens essenciais que todos os alunos devem desenvolver
      ao longo das etapas e modalidades da Educação Básica."
      <a class="text-green-400" href="http://basenacionalcomum.mec.gov.br/">Base nacional comum MEC.</a>
      Inspirado na BNCC o LEM categoriza seus artefatos utilizando habilidades e competências.
      </span>
    </div>
    <div class="container px-5 py-24 mx-auto">
      <div class="-my-8 divide-y-2 divide-gray-100">
          <competence v-for="c in state.cards" :key="c.code" :abilities="c.abilities" :id="c._id" :description="c.description" :code="c.code"/>
      </div>
    </div>
</section>
</template>

<script>
import { reactive } from 'vue'
import competence from '../../components/Card/competence.vue'
import services from '../../services'

export default {
  components: { competence },

  data () {
    const cards = []
    const state = reactive({
      cards
    })

    return {
      state
    }
  },
  methods: {
    async getSkills () {
      const { data, errors } = await services.skill.getAll()
      if (!errors) {
        this.state.cards = data
        console.log(data)
      } else {
        console.log(errors)
      }
    }
  },

  mounted () {
    this.getSkills()
  }

}
</script>
