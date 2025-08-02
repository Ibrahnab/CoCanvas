<template>
  <div>
    <button @click="onClick">
      <div v-if="!spinner">
        <slot />
      </div>

      <div v-else>
        <VueSpinnerTail color="white" />
      </div>
    </button>
  </div>
</template>
<script lang="ts" setup>
import { VueSpinnerTail } from 'vue3-spinners'
defineProps({
  text: {
    type: String,
  },
  spinner: {
    type: Boolean,
    default: false,
  },
})

const emit = defineEmits(['click'])

function onClick() {
  emit('click')
}
</script>

<style scoped lang="scss">
button {
  width: fit-content;
  min-width: 90px;
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

.hidden {
  display: none;
}
</style>
