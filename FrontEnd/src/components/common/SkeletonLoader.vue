<template>
  <div>
    <slot />
  </div>
</template>

<script setup lang="ts">
// TODO: Complete this later, consider Suspense tag as wrapper btw
defineProps({
  hasLoded: {
    type: Boolean,
  },
})
</script>

<style scoped lang="scss"></style>
