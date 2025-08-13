<template>
  <img :src="image" />
</template>
<script setup lang="ts">
const props = defineProps({
  image: {
    type: String,
    default: '',
  },
})
</script>

<style scoped lang="scss">
img {
  width: 3.5rem;
  height: 3.5rem;
  background-size: cover;
  background-position: top center;
  border-radius: 50%;
}
</style>
