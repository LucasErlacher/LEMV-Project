<template>
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" rel="stylesheet">
  <lem-header
  @login="handleLogin"/>
  <modal-factory/>
  <router-view/>
</template>
<script>
import { onMounted } from 'vue'
import { useRouter } from 'vue-router'
import ModalFactory from './components/ModalFactory'
import LemHeader from './components/Header/LemHeader'
import useModal from './/hooks/useModal'

export default {
  components: { LemHeader, ModalFactory },
  setup () {
    const router = useRouter()
    const modal = useModal()

    onMounted(() => {
      const token = window.localStorage.getItem('token')
      if (!token) { router.push({ name: 'Inicio' }) }
    })

    function handleLogin () {
      modal.open({
        component: 'ModalLogin'
      })
    }

    return { handleLogin }
  }
}

</script>
<style lang="postcss">
.header {
    @apply bg-brand-gray w-full flex justify-center;
    height: 89px;
}
.material-icons-outlined {
  font-family: 'Material Symbols Outlined', sans-serif;
  font-size: 30px;
}
</style>
