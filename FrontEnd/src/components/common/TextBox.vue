<template>
  <div class="group">
    <font-awesome-icon v-if="icon !== ''" class="icon" :icon="icon" />
    <input
      class="input"
      :style="{ paddingLeft: (icon !== '' ? 2.5 : 1) + 'rem' }"
      :type="type"
      :placeholder="placeholder"
      :value="modelValue"
      @input="onInput"
    />
  </div>
</template>
<script setup lang="ts">
defineProps({
  label: {
    type: String,
  },
  icon: {
    type: String,
    default: '',
  },
  modelValue: {
    type: String,
  },
  placeholder: {
    type: String,
    default: '',
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
.group {
  display: flex;
  line-height: 28px;
  align-items: center;
  position: relative;
}

.input {
  width: 100%;
  height: 40px;
  line-height: 28px;
  padding: 0 1rem;
  border: 2px solid transparent;
  border-radius: 8px;
  outline: none;
  background-color: #f3f3f4;
  color: #0d0c22;
  transition: 0.3s ease;
}

.input::placeholder {
  color: #9e9ea7;
}

.input:focus,
input:hover {
  outline: none;
  border-color: rgba(234, 76, 137, 0.4);
  background-color: #fff;
  box-shadow: 0 0 0 4px rgb(234 76 137 / 10%);
}

.icon {
  position: absolute;
  left: 1rem;
  fill: #9e9ea7;
  width: 1rem;
  height: 1rem;
}

label {
  font-size: $font-size-xs;
}
</style>
