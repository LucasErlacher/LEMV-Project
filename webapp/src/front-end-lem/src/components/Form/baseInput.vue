<template>
    <label class="block">
    <span class="text-lg font-medium text-gray-600">{{ label }}</span>
    <input
      v-bind="$attrs"
      :value="modelValue"
      :placeholder="placeholder"
      @input="$emit('update:modelValue', $event.target.value)"
      class="field w-full bg-gray-100 bg-opacity-50 rounded border border-green-300 focus:border-green-500 focus:bg-white focus:ring-2 focus:ring-green-200 text-base outline-none text-gray-700 py-1 px-3 leading-8 transition-colors duration-200 ease-in-out"
    >
    </label>
</template>

<script>
export default {
  props: {
    label: {
      type: String,
      default: ''
    },
    placeholder: {
      type: String,
      default: ''
    },
    modelValue: {
      type: [String, Number],
      default: ''
    }
  }
}
</script>
