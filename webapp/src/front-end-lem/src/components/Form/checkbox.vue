<template>
  <li v-for="(option, index) in options" :key="index">
      <input :id="option.id" :value="option" v-model="checked" @change="$emit('updateState', checked)" type="checkbox"/>
      <label>{{option.code + ': ' + option.description}}<span></span></label>
  </li>

</template>

<script>
export default {
  props: ['options'],
  emits: ['updateState'],

  data () {
    return {
      checked: []
    }
  }
}
</script>
