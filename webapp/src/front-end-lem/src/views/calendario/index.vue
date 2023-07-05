<template>

  <div class="flex flex-col items-center w-full mx-auto px-6 py-8 gap-1">
      <h1 class="text-4xl font-black text-black">Calendário</h1>
      <div class="py-8">
        <iframe v-if="getWidth() > 1000" src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23ffffff&ctz=America%2FSao_Paulo&mode=WEEK&showTitle=0&showNav=1&showDate=1&showPrint=1&showTabs=1&showCalendars=0&showTz=1&src=MTc4YWYwYjYxNWI0MzI1YWNhZTEwNmZkNjVkZmUyNDg4Mjg1MmFmMzY4MjgwOGIyNjFlNzI1ZTY3Y2E5NWUzNEBncm91cC5jYWxlbmRhci5nb29nbGUuY29t&color=%238E24AA" style="border-width:0" width="1200" height="600" frameborder="0" scrolling="no"></iframe>
        <iframe v-else src="https://calendar.google.com/calendar/embed?height=500&wkst=1&bgcolor=%23ffffff&ctz=America%2FSao_Paulo&mode=WEEK&showTitle=0&showNav=0&showDate=0&showPrint=0&showTabs=0&showCalendars=0&showTz=0&src=MTc4YWYwYjYxNWI0MzI1YWNhZTEwNmZkNjVkZmUyNDg4Mjg1MmFmMzY4MjgwOGIyNjFlNzI1ZTY3Y2E5NWUzNEBncm91cC5jYWxlbmRhci5nb29nbGUuY29t&color=%238E24AA" style="border-width:0" width="400" height="500" frameborder="0" scrolling="no"></iframe>
      </div>
  </div>

</template>

<script>
import 'vue-cal/dist/vuecal.css'

export default {
  data () {
    function getWidth () {
      return window.screen.width
    }

    return {
      getWidth
    }
  }

}
</script>
