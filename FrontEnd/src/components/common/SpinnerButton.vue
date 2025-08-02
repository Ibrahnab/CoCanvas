<template>
  <button @click="onClick">
    <div v-if="!spinner">
      <slot />
    </div>

    <div v-else>
      <VueSpinnerTail color="white" />
    </div>
  </button>
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

<style scoped lang="scss"></style>
