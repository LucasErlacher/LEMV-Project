<template>
<select @change="this.$emit('currentSelect', $event.target.value)" class="field w-full bg-gray-100 bg-opacity-50 rounded border border-green-300 focus:border-green-500 focus:bg-white focus:ring-2 focus:ring-green-200 text-base outline-none text-gray-700 py-1 px-3 leading-8 transition-colors duration-200 ease-in-out">
  <option disabled value="">Opções...</option>
  <option v-for=" option in options" :key=option>
    {{option.code}}
  </option>
</select>
</template>

<script>
export default {
  props: ['options'],

  setup (props) {
    function onChange (e) {
      this.$emit('currentSelect', e.target.value)
    }

    return {
      onChange
    }
  }

}
</script>

<style>

</style>
