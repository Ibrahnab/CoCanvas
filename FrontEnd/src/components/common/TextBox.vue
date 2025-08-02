<template>
  <div class="textbox-wrapper">
    <label> {{ label }} </label>
    <input :type="type" :value="modelValue" @input="onInput" />
  </div>
</template>
<script setup lang="ts">
defineProps({
  label: {
    type: String,
  },
  modelValue: {
    type: String,
  },
  type: {
    type: String,
    default: 'text',
  },
})

const emit = defineEmits(['update:modelValue'])

function onInput(event: Event) {
  const target = event.target as HTMLInputElement | null
  if (target) {
    emit('update:modelValue', target.value)
  }
}
</script>

<style scoped lang="scss">
.textbox-wrapper {
  display: flex;
  flex-direction: column;
}

input {
  max-width: 100%;
  font-size: $font-size-xs;
}

label {
  font-size: $font-size-xs;
}
</style>
