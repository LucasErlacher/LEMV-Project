<template>
  <div class=" relative bg-white py-6 px-6 rounded-3xl w-3/4 h-96 my-4 shadow-xl">
    <div class="mt-8">
      <p class="text-xl font-semibold my-2">{{ nomeEtapa }}</p>
      <div class="flex space-x-2 text-gray-400 text-sm w-full">
        <p>{{ descricao }}</p>
      </div>
      <div class="border-t-2"></div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    nomeEtapa: String,
    descricao: String,
    materiais: {}
  },
  mounted () {
    console.log(this.props)
  }
}
</script>
