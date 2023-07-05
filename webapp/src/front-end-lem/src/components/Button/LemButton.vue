<template>
    <button class='ml-auto text-brand-main flex items-center gap-1 sm:text-lg border border-gray-300 px-3 py-1 rounded-full hover:bg-gray-50 transition-colors focus:bg-gray-100 focus:outline-none focus-visible:border-gray-500'>
      <span>{{value}}</span>
    </button>
</template>

<script>

export default {
  props: {
    value: String
  }
}
</script>
