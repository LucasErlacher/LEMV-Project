<template>
    <button @click="filter = !filter" class="focus:outline-none">
        <span class="inline">Filtrar: </span>
        <svg xmlns="http://www.w3.org/2000/svg" class=" inline h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 4a1 1 0 011-1h16a1 1 0 011 1v2.586a1 1 0 01-.293.707l-6.414 6.414a1 1 0 00-.293.707V17l-4 4v-6.586a1 1 0 00-.293-.707L3.293 7.293A1 1 0 013 6.586V4z" />
        </svg>
    </button>
    <div v-if="filter" class="grid grid-col-2 items-center md:grid-col-2">
        <form>
        <select v-model="categoria">
            <option disabled value="">Categoria</option>
            <option v-for="op in props.dropBox" :key="op.index" :value="op">
            <option value="">Nenhuma</option>
        </select>
        <div>
            <label type="text">Data Inicio: </label>
            <input v-model="dataInicio" type="date">
            <label type="text">Data Fim: </label>
            <input v-model="dataFim" type="date">
        </div>
        </form>
        <button
        class="bg-gray-300 rounded-md px-3" @click="() => $emit('filtrar', {categoria, dataInicio, dataFim})">Filtrar
        </button>
</template>

<script>
export default {
  props: {
    dropBox: Array
  },
  data () {
    const categoria = String
    const dataInicio = Date
    const dataFim = Date

    return {
      categoria,
      dataInicio,
      dataFim
    }
  },
  setup (_, { emit }) {
    return { emit }
  }

}
</script>
