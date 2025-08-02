<template>
  <div>
    <button>
      <slot />
    </button>
  </div>
</template>
<script lang="ts" setup>
defineProps({
  text: {
    type: String,
  },
})
</script>

<style scoped lang="scss">
button {
  width: fit-content;
  border-radius: $radius-lg;
  border-style: none;
  padding-left: 1rem;
  padding-right: 1rem;
  padding-top: 0.3rem;
  padding-bottom: 0.3rem;
  transition: all 0.5s ease-out;
  background-color: $color-primary;
  font-size: $font-size-xs;
  font-weight: $font-weight-bold;
  color: white;
}

button:hover {
  background-color: $color-primary-dark;
  cursor: pointer;
}
</style>
