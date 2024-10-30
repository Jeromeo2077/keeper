<script setup>
import { Keep } from '@/models/Keep.js';


defineProps({ keep: { type: Keep, required: true } });

</script>


<template>
  <div class="keep-card">
    <img :src="keep.img" :alt="keep.name" class="img-fluid keep-img rounded border border-3 shadow" />
    <h2>{{ keep.name }}</h2>
  </div>
</template>


<style lang="scss" scoped>
h2 {
  position: absolute;
  top: 80%;
  left: 40%;
  transform: translate(-50%, -50%);
  color: white;
  text-shadow: 2px 2px 4px #000000;
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