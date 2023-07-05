<template>
<section class="text-gray-600 body-font">
  <div class="container px-5 py-24 mx-auto">
    <div class="w-full mx-auto overflow-auto">
      <table class="table-auto w-full text-left whitespace-no-wrap">
        <thead>
          <tr>
            <th class="px-4 py-3 title-font tracking-wider font-medium text-gray-900 text-sm bg-gray-100 rounded-tl rounded-bl">{{skill.code}}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="a in skill.abilities" :key="a.code">
            <abiliti :ability="a"/>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</section>
</template>

<script>
import abiliti from '../Button/abiliti.vue'

export default {
  components: { abiliti },
  props: ['skill']
}

</script>
