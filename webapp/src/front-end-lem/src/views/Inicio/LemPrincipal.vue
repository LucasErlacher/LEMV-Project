<template>
<div class="flex items-center justify-center">
    <div class="flex space-x-10">
        <div class="img-principal hidden md:block"></div>
        <div class="flex flex-col mt-20">
            <h1 class="flex text-4xl font-black justify-center text-black">Bem vindo ao LEM-V!</h1>
            <p class="text-lg font-medium mt-10 text-gray">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla<br>
                 Nulla malesuada arcu at erat porttitor porttitor. Vestibulum<br>
                 vel sodales diam sed vehicula. Aliquam malesuada quam placerat<br>
                 ipsum non urna fermentum, id pharetra mauris porttitor.<br><br>
                 Integer tincidunt nibh lectus, eget ullamcorper est ullamcorper sed.<br>
                 convallis tincidunt pulvinar diam dictum dignissim. Suspendisse<br>
                 sit amet ornare lectus consequat. Donec placerat arcu ut tincidunt blandit.
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
