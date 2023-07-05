<template>
    <div class="p-2 lg:w-1/3 md:w-1/2 w-full">
        <div class="h-full flex items-center border-gray-200 border p-4 rounded-lg">
            <img alt="team" class="w-16 h-16 bg-gray-100 object-cover object-center flex-shrink-0 rounded-full mr-4" :src="img">
            <div class="flex-grow">
            <h2 class="text-gray-900 title-font font-medium">{{title}}</h2>
            <p class="text-gray-500">{{resume}}</p>
            </div>
        <div v-if=download v-on:click="getFile()">
          <svg fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" class="w-9 h-9" viewBox="0 0 46 50">
            <path d="M24 32.35 14.35 22.7 16.5 20.55 22.5 26.55V8H25.5V26.55L31.5 20.55L33.65 22.7ZM11 40Q9.8 40 8.9 39.1Q8 38.2 8 37V29.85H11V37Q11 37 11 37Q11 37 11 37H37Q37 37 37 37Q37 37 37 37V29.85H40V37Q40 38.2 39.1 39.1Q38.2 40 37 40Z"></path>
          </svg>
        </div>
        </div>
    </div>
</template>

<script>
import services from '../../services'

export default {

  props: {
    id: String,
    title: String,
    resume: String,
    img: String,
    download: Boolean,
    type: String
  },

  methods: {
    async getFile () {
      switch (this.type) {
        case 'paper': {
          const { data, errors } = await services.file.download(this.id)
          if (!errors) {
            this.toDownloadFile(data)
          } else {
            console.log(errors)
          }
          break
        }
        case 'book': {
          const { data, errors } = await services.book.downloadSingle(this.id)
          if (!errors) {
            this.toDownloadFile(data)
          } else {
            console.log(errors)
          }
          break
        }
      }
    },
    async toDownloadFile (data) {
      var fileURL = window.URL.createObjectURL(new Blob([data]))
      var fileLink = document.createElement('a')

      fileLink.href = fileURL
      fileLink.setAttribute('download', 'file.pdf')
      document.body.appendChild(fileLink)

      fileLink.click()
    }
  }

}
</script>
