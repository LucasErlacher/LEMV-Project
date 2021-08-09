<template>
  <div class="relative bg-white py-6 px-6 rounded-3xl w-64 my-4 shadow-xl">
            <div class="mt-8">
                <p class="text-xl font-semibold my-2">{{nomeEtapa}}</p>
                <div class="flex space-x-2 text-gray-400 text-sm">
                     <p>{{descricao}}</p>
                </div>
                <div class="border-t-2 "></div>

                <div>
                    <div class="my-2">
                        <p class="font-semibold text-base mb-2">Materiais necessários:</p>
                    </div>
                    <div class="space-y-4">
                        <p v-for="material in materiais" :key="material.index" class="font-semibold text-gray-500 text-sm mb-1">{{material}}</p>
                    </div>
                </div>
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
