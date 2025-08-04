<template>
  <div class="errorBox" v-if="errorItems.length > 0">
    <div v-for="(description, index) in errorItems.flat()" :key="index">
      <p>- {{ description }}</p>
    </div>
  </div>
</template>

<script setup lang="ts">
defineProps({
  errorItems: {
    type: Array,
    default: () => [],
  },
})
</script>

<style scoped lang="scss">
.errorBox {
  padding: 0.5rem 5rem 0.5rem 5rem;
  background-color: rgb(246, 161, 161);
  border-radius: $radius-md;
  margin-bottom: 10px;
}
</style>
