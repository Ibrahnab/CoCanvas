<template>
  <div class="container">
    <font-awesome-icon :icon="[toggled ? 'fas' : 'far', icon]" :style="{ fontSize: size + 'px' }" />
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

defineProps({
  icon: {
    type: String,
    default: '',
  },
  size: {
    type: Number,
    default: 25,
  },
  toggled: {
    type: Boolean,
    default: false,
  },
})
</script>

<style scoped lang="scss">
.container {
  padding: 10px;
  border-radius: 10px;
}

.container:hover {
  background-color: $color-gray-200;
  cursor: pointer;
  transition: all 0.25s ease;
}
</style>
