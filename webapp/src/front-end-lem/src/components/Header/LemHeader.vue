<template>
<header class="text-gray-600 body-font">
  <div class="container mx-auto flex flex-wrap p-5 flex-col md:flex-row items-center">
    <a class="flex title-font font-medium items-center text-gray-900 mb-4 md:mb-0">
        <div class="w-32 lg:w-30">
            <router-link to="/"><img src="../../assets/images/logo.png" alt="logo" class="w-full"></router-link>
        </div>
    </a>
        <nav class="md:ml-auto flex flex-wrap items-center text-base justify-center">
            <div class="content-center pr-15 space-x-5 md:block md:ml-10 md:pr-20 md: flex flex-wrap space-x-10 mt-2">
                <router-link to="/" class="font-medium text-brand-main hover:text-gray-900">Inicio</router-link>
                <router-link to="/projetos" class="font-medium text-brand-main hover:text-gray-900">Projetos</router-link>
                <router-link to="/noticias" class="font-medium text-brand-main hover:text-gray-900">Notícias</router-link>
                <router-link to="/acervo" class="font-medium text-brand-main hover:text-gray-900">Acervo</router-link>
                <router-link to="/calendario" class="font-medium text-brand-main hover:text-gray-900">Calendário</router-link>
                <router-link to="/Competencias" class="font-medium text-brand-main hover:text-gray-900">BNCC</router-link>
            </div>
        </nav>
        <button
        class="flex px-8 py-3 text-2x1 font-bold text-brand-main rounded bg-brand-graydark focus:outline-none"
        @click="() => $emit('login')"
        >
        Entrar
        </button>
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
