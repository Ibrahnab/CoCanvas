<template>
  <div class="comment-container" :style="{ top: posY + 'px', left: posX + 'px' }">
    <div class="comment-bubble p-2" ref="comment-bubble" @click="onClickBubble">
      <font-awesome-icon class="icon" icon="comment" :style="{ color: 'white' }" />
    </div>
    <div v-if="toggled" class="group">
      <span
        contenteditable="true"
        class="input"
        ref="input"
        style="min-width: 200px; max-width: 200px"
        @input="onInput"
      >
        {{ modelValue }}
      </span>

      <div class="tools-container">
        <SpinnerButton class="save-button" @click="onDelete">
          <font-awesome-icon class="send-icon" icon="trash"></font-awesome-icon>
        </SpinnerButton>
        <SpinnerButton class="save-button" @click="onSend">
          <font-awesome-icon class="send-icon" icon="paper-plane"></font-awesome-icon>
        </SpinnerButton>
      </div>
    </div>
  </div>
</template>
<script setup lang="ts">
import { ref, useTemplateRef, onMounted } from 'vue'

import { SpinnerButton } from '@/components/common'

const input = useTemplateRef('input')
const commentBubble = useTemplateRef('comment-bubble')
const toggled = ref(false)

const emit = defineEmits(['update:modelValue', 'send', 'delete'])
const props = defineProps({
  modelValue: {
    type: String,
    default: '',
  },
  placeholder: {
    type: String,
    default: '',
  },
  posX: {
    type: Number,
    default: 0,
  },
  posY: {
    type: Number,
    default: 0,
  },
})

function onInput(event: Event) {
  const target = event.target as HTMLInputElement | null
  if (target) {
    emit('update:modelValue', target.value)
  }
}

function onClickBubble() {
  toggled.value = !toggled.value
}

function onSend() {
  emit('send')
}

function onDelete() {
  emit('delete')
}

onMounted(() => {
  if (input.value) {
    // TODO: Fix, this is not focusing
    input.value.focus()
  }
})
</script>

<style scoped lang="scss">
.comment-container {
  display: flex;
  flex-direction: row;
  position: absolute;
  padding: 5px;
}

.tools-container {
  display: flex;
  flex-direction: row;
  gap: 5px;
}

.save-button {
  width: fit-content;
  height: fit-content;
  padding-left: 0.5rem;
  padding-right: 0.5rem;
  padding-top: 0;
  padding-bottom: 0;
  border-radius: 10px;
}

.send-icon {
  font-size: $font-size-xs;
}

.comment-bubble {
  background-color: rgb(46, 199, 202);
  border-radius: 50%;
  cursor: pointer;
  width: fit-content;
  height: fit-content;

  box-shadow: 0 0 10px rgb(0, 0, 0, 0.3);
}

.group {
  margin-left: 5px;
  display: flex;
  line-height: 28px;
  flex-direction: column;
  justify-content: start;
  gap: 5px;
  align-items: end;
  background-color: $color-gray-650;
  border-radius: $radius-md;
  padding: 5px;
  box-shadow: 0 5px 10px rgb(0, 0, 0, 0.3);
}

.input {
  width: 100%;
  height: auto;
  line-height: 18px;
  padding: 0 0.5rem;
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
  cursor: text;
}

.input:focus,
input:hover {
  outline: none;
  border-color: rgba(234, 76, 137, 0.4);

  box-shadow: 0 0 0 4px rgb(234 76 137 / 10%);
}
</style>
