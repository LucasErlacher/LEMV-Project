<template>
    <header class="header flex items-center">
        <div class="flex flex-col w-4/5 max-w-6xl">
            <div class="flex items-center justify-between py-10">
                <div class="w-32 lg:w-30">
                    <router-link to="/"><img src="../../assets/images/logo.png" alt="logo" class="w-full"></router-link>
                </div>
                <div class="flex">
                    <div class="content-center hidden md:block md:ml-10 md:pr-20 md:space-x-10 mt-2">

                    <router-link to="/" class="font-medium text-brand-main hover:text-gray-900">Inicio</router-link>
                    <router-link to="/projetos" class="font-medium text-brand-main hover:text-gray-900">Projetos</router-link>
                    <router-link to="/noticias" class="font-medium text-brand-main hover:text-gray-900">Notícias</router-link>
                    <router-link to="/sobrenos" class="font-medium text-brand-main hover:text-gray-900">Sobre nós</router-link>
                    <router-link to="/contato" class="font-medium text-brand-main hover:text-gray-900">Contato</router-link>

                    </div>
                    <button
                    class="flex px-8 py-3 text-2x1 font-bold text-brand-main rounded bg-brand-graydark focus:outline-none"
                    @click="() => $emit('login')"
                    >
                    Entrar
                    </button>
                </div>
            </div>
    </div>
    </header>
</template>

<script>

export default {
  setup (_, { emit }) {
    return { emit }
  }
}
</script>
