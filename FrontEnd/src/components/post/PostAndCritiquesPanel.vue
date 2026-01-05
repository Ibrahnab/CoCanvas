<template>
  <div v-if="post" class="panel-container">
    <h3>{{ post.title }}</h3>
    <div class="post-container">
      <PostBox :post="post" />
    </div>
    <h3 class="my-2">Critiques</h3>
    <CritiqueCompose />
    <div class="critiques-container">
      <div v-for="(critique, critIndex) in post.critiques" :key="critIndex">
        <CritiqueItem
          :critique="critique"
          :selected-critique-id="selectedCritiqueId"
          @selected="setSelected($event)"
        />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { CritiqueDto, PostDto } from '@/DTO'

import type { PropType } from 'vue'
import CritiqueItem from '@/components/post/CritiqueItem.vue'
import PostBox from '@/components/post/PostBox.vue'
import CritiqueCompose from '@/components/post/CritiqueCompose.vue'

const emit = defineEmits(['selected'])

function setSelected(critiqueId: string) {
  if (props.selectedCritiqueId === critiqueId) {
    emit('selected', '')
    return
  }
  emit('selected', critiqueId)
}

const props = defineProps({
  post: {
    type: Object as PropType<PostDto>,
  },
  selectedCritiqueId: {
    type: String,
  },
})
</script>

<style scoped lang="scss">
.panel-container {
  display: flex;
  flex-direction: column;
  border-left: solid 1px rgb(209, 209, 209);
  gap: 10px;
  padding: 20px;
  cursor: pointer;
  height: 80vh;
  overflow-y: auto;
}
.critiques-container {
  display: flex;
  flex-direction: column;
  gap: 15px;
  width: 600px;
  min-height: 300px;
  transition: all 0.25s;
}
</style>
