
<template>
  <swiper
    :navigation="true"
    :slidesPerView="1"
    :spaceBetween="30"
    :pagination="{
      clickable: true,
    }"
    class="mySwiper"
  >
    <swiper-slide v-for="img in imgs" :key="img.index">
      <img
        alt="Imagem singlePage artefact"
        :src="img"
        style="width: 400px; height: 300px"
        class="object-cover object-center"
      />
    </swiper-slide>
  </swiper>
</template>

<script>
// Import Swiper Vue.js components
import { Swiper, SwiperSlide } from 'swiper/vue'
import 'swiper/components/pagination/pagination.min.css'
import 'swiper/components/navigation/navigation.min.css'

// Import Swiper styles
import 'swiper/swiper.scss'

// import Swiper core and required modules
import SwiperCore, {
  Pagination,
  Navigation
} from 'swiper/core'

SwiperCore.use([Pagination, Navigation])

export default {
  props: {
    imgs: {}
  },
  components: {
    Swiper,
    SwiperSlide
  },
  mounted () {
  }

}
</script>
<style scoped>
  #app { height: 70% }
html,
body {
  position: relative;
  height: 70%;
}

body {
  background: #eee;
  font-family: Helvetica Neue, Helvetica, Arial, sans-serif;
  font-size: 14px;
  color: #000;
  margin: 0;
  padding: 0;
}

.swiper-container {
  width: 90%;
  height: 70%;
}

.swiper-slide {
  text-align: center;
  font-size: 18px;
  background: #fff;

  /* Center slide text vertically */
  display: -webkit-box;
  display: -ms-flexbox;
  display: -webkit-flex;
  display: flex;
  -webkit-box-pack: center;
  -ms-flex-pack: center;
  -webkit-justify-content: center;
  justify-content: center;
  -webkit-box-align: center;
  -ms-flex-align: center;
  -webkit-align-items: center;
  align-items: center;
}

.swiper-slide img {
  display: block;
  width: 90%;
  height: 70%;
  object-fit: cover;
}

</style>
