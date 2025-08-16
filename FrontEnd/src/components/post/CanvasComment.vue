<template>
  <div class="group">
    <span
      contenteditable="true"
      class="input"
      ref="input"
      style="min-width: 200px; max-width: 200px"
    >
    </span>
  </div>
</template>
<script setup lang="ts">
import { ref, useTemplateRef, onMounted } from 'vue'

const input = useTemplateRef('input')

const emit = defineEmits(['update:modelValue'])
defineProps({
  modelValue: {
    type: String,
  },
  placeholder: {
    type: String,
    default: '',
  },
})

function onInput(event: Event) {
  const target = event.target as HTMLInputElement | null
  if (target) {
    emit('update:modelValue', target.value)
  }
}

onMounted(() => {
  console.log('mounted comment', input.value)
  if (input.value) {
    // TODO: Fix, this is not focusing
    input.value.focus()
  }
})
</script>

<style scoped lang="scss">
.group {
  display: flex;
  line-height: 28px;
  align-items: center;
  position: relative;
  background-color: $color-gray-650;
  border-radius: $radius-md;
  padding: 5px;
  box-shadow: 0 5px 10px rgb(0, 0, 0, 0.3);
}

.input {
  width: 100%;
  height: auto;
  line-height: 28px;
  padding: 0 1rem;
  border: 2px solid transparent;
  border-radius: 8px;
  outline: none;
  font-size: $font-size-xs;
  color: #ffffff;
  transition: 0.3s ease;
}

.input::placeholder {
  color: #9e9ea7;
}

span.input[contenteditable] {
  display: inline-block;
}
span.input[contenteditable]:empty::before {
  content: 'Add a comment';
  color: gray;
  display: inline-block;
}

.input:focus,
input:hover {
  outline: none;
  border-color: rgba(234, 76, 137, 0.4);

  box-shadow: 0 0 0 4px rgb(234 76 137 / 10%);
}

.icon {
  position: absolute;
  left: 1rem;
  fill: #9e9ea7;
  width: 1rem;
  height: 1rem;
}
</style>
