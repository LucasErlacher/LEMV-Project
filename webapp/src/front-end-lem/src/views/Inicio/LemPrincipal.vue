<template>
<div class="flex items-center justify-center">
    <div class="flex space-x-10">
        <div class="img-principal hidden md:block"></div>
        <div class="flex flex-col mt-20">
            <h1 class="flex text-4xl font-black justify-center text-black">Bem vindo ao LEM-V!</h1>
            <p class="text-lg font-medium mt-10 text-gray">
                No dia 30 de agosto de 1989 foi criado o Laboratório de Ensino de <br>
                Matemática (LEM) da Escola Técnica Federal do Espírito Santo (ETFES).<br>
                O LEM contribui no desenvolvimento profissional dos professores<br>
                ou futuros professores de matemática, do IFES ou de outras instituições.<br><br>
                A consulta ao nosso acervo poderá ser realizada, com acesso a<br>
                 alguns projetos e atividades, a partir deste ambiente.
            </p>
        </div>
    </div>

</div>
</template>

<script>
export default {

}
</script >

<style lang="postcss" scoped>
.img-principal {
    position: flex;
    width: 512px;
    height: 606px;
    left: 161px;
    top: 226px;
}
@media (min-width: 640px) {
    .img-principal {
        background-image: url(../../assets/images/principal.png);
        background-size: 500px;
        background-position: 90% 100%;
        background-repeat: no-repeat;
    }
}
</style>
