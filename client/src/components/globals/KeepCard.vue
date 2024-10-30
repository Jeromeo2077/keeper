<script setup>
import { Keep } from '@/models/Keep.js';
import ProfilePicture from './ProfilePicture.vue';


defineProps({ keep: { type: Keep, required: true } });

</script>


<template>
  <!-- <RouterLink :to="{ name: 'KeepDetails', params: { keepId: keep.id } }" :title="`Check out the ${keep.name} details!`"> -->
  <div class="keep-card">
    <img :src="keep.img" :alt="keep.name" class="img-fluid keep-img rounded border border-3 shadow" />
    <h3>{{ keep.name }}</h3>
    <span>
      <ProfilePicture :profile="keep.creator" />
    </span>
  </div>
  <!-- </RouterLink> -->
</template>


<style lang="scss" scoped>
h3 {
  position: absolute;
  top: 87%;
  left: 10%;
  color: white;
  text-shadow: 2px 2px 4px #000000;
  padding: 0;
}

span {
  position: absolute;
  top: 85%;
  right: 10%;
  padding: 0;
}

.keep-card {
  position: relative;
  break-inside: avoid;
  border-radius: 10px;
  margin: 5px;
}

.keep-img {
  width: 100%;
  aspect-ratio: 1/1;
  object-fit: cover;
}
</style>