<template>
<main class="flex-col" @list="getSkills">
  <div class="flex flex-col items-center w-full mx-auto px-6 py-8 gap-1">
      <h1 class="text-4xl font-black text-black"> Administrador: Competências</h1>
      <icon-button @click="pushCreateSkill()"
      path="M22.5 34H25.5V25.5H34V22.5H25.5V14H22.5V22.5H14V25.5H22.5ZM9 42Q7.8 42 6.9 41.1Q6 40.2 6 39V9Q6 7.8 6.9 6.9Q7.8 6 9 6H39Q40.2 6 41.1 6.9Q42 7.8 42 9V39Q42 40.2 41.1 41.1Q40.2 42 39 42ZM9 39H39Q39 39 39 39Q39 39 39 39V9Q39 9 39 9Q39 9 39 9H9Q9 9 9 9Q9 9 9 9V39Q9 39 9 39Q9 39 9 39ZM9 39Q9 39 9 39Q9 39 9 39V9Q9 9 9 9Q9 9 9 9Q9 9 9 9Q9 9 9 9V39Q9 39 9 39Q9 39 9 39Z"
      />
      <div class="container px-5 py-24 mx-auto">
      <div class="-my-8 divide-y-2 divide-gray-100">
          <competence-update v-for="c in state.cards"
          :key="c.code"
          :abilities="c.abilities"
          :id="c.id"
          :description="c.description"
          :code="c.code"
            @competenceUpdate="pushtoUpdateSkill($event.id, $event)"
            @competenceDelete="deleteSkill($event)"
          />
      </div>
    </div>
  </div>
</main>

</template>

<script>
import { reactive } from 'vue'
import services from '../../services'
import CompetenceUpdate from '../../components/Card/competenceUpdate.vue'
import useModal from './../../hooks/useModal'
import IconButton from '../../components/Button/iconButton.vue'
import { useRouter } from 'vue-router'

export default {
  components: { CompetenceUpdate, IconButton },

  data () {
    const router = useRouter()
    const modal = useModal()
    const cards = []
    const state = reactive({
      cards
    })

    async function getSkills () {
      console.log('foi')
      const { data, errors } = await services.skill.getAll()
      if (!errors) {
        this.state.cards = data
        console.log(data)
      } else {
        console.log(errors)
      }
    }

    async function deleteSkill (props) {
      modal.open({
        component: 'ModalDeleteSkill',
        status: true,
        props: props
      })
    }

    function pushCreateSkill () {
      router.push({ name: 'CompetenciasCreatePage' })
    }

    function pushtoUpdateSkill (id, skill) {
      console.log('push to update page')
      router.push({ name: 'CompetenciasUpdatePage', params: { id: id, data: JSON.stringify(skill) } })
    }

    return {
      state,
      getSkills,
      pushCreateSkill,
      pushtoUpdateSkill,
      deleteSkill
    }
  },

  mounted () {
    this.getSkills()
  }

}
</script>
