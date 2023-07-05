<template>
    <div class="py-4 px-32 flex flex-wrap md:flex-nowrap">
        <div class="md:flex-grow">
            <h3 class="text-2xl font-regular text-gray-900 title-font mb-2">{{code}}</h3>
            <p class="leading-relaxed">{{description}}</p>
        </div>
        <div v-if="edit">
            <button v-on:click="() => $emit('edit', $props)"
                class='ml-auto text-brand-main flex items-center gap-1 sm:text-lg border border-gray-300 px-3 py-1 rounded-full hover:bg-yellow-500 hover:text-white transition-colors focus:bg-gray-100 focus:outline-none focus-visible:border-gray-500'>
                <span>Atualizar</span>
            </button>
            <button v-on:click="() => $emit('remove',  $props)"
                class='ml-auto text-brand-main flex items-center gap-1 sm:text-lg border border-gray-300 px-3 py-1 rounded-full hover:bg-red-500 hover:text-white transition-colors focus:bg-gray-100 focus:outline-none focus-visible:border-gray-500'>
                <span>Deletar</span>
            </button>
        </div>
    </div>
</template>

<script>
export default {
  props: ['id', 'code', 'description', 'edit']

}
</script>
