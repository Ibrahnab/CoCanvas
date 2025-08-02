<template>
  <div class="checkbox-wrapper">
    <input type="checkbox" :disabled="disabled" :value="modelValue" @change="onChange" />
    <p>{{ description }}</p>
  </div>
</template>

<script setup lang="ts">
defineProps({
  description: {
    type: String,
    default: '',
  },
  modelValue: {
    type: Boolean,
    default: false,
  },
  disabled: {
    type: Boolean,
    default: false,
  },
})

const emit = defineEmits(['update:modelValue'])

function onChange(event: Event) {
  const target = event.target as HTMLInputElement | null
  if (target) {
    emit('update:modelValue', target.checked)
  }
}
</script>

<style scoped lang="scss">
.checkbox-wrapper {
  display: flex;
  justify-content: center;
  align-items: flex-start;
}
</style>
