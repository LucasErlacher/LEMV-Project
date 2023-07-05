<template>
  <div>
    <button @click="downloadFile" class="flex items-center justify-center hover:bg-gray-300 w-10 h-10 focus:outline-none">
      <i class="material-icons-outlined text-green-500">cloud_download</i>
    </button>
  </div>
</template>

<script>
import services from '../../services'

export default {
  props: ['fileId', 'format', 'name'],
  data () {
    return {
      // Adicione outras propriedades se necessário
    }
  },
  methods: {
    async downloadFile () {
      if (this.fileId) {
        const { data, errors } = await services.file.download(this.fileId)
        if (!errors) {
          const url = window.URL.createObjectURL(new Blob([data], { type: this.format }))
          const link = document.createElement('a')
          link.href = url
          link.setAttribute('download', this.name)
          document.body.appendChild(link)
          link.click()
          document.body.removeChild(link)
          window.URL.revokeObjectURL(url)
        } else {
          console.log('result')
          console.log(errors)
        }
      }
    }
  }
}
</script>

<style>
.material-icons-outlined {
  font-family: 'Material Symbols Outlined', sans-serif;
  font-size: 40px;
}
</style>
