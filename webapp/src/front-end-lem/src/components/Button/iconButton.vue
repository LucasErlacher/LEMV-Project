<template>
    <button>
    <link rel="stylesheet" href="https://fonts.sandbox.google.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />
        <svg fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" class="w-9 h-9" viewBox="0 0 46 50">
            <path :d=path></path>
        </svg>
    </button>
</template>

<script>

export default {
  props: ['path']

}
</script>
