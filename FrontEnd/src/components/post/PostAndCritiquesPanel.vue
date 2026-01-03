<template>
  <div class="panel-container">
    <!-- TODO: Make smaller components out of this structure -->
    <h3 class="">Critiques</h3>
    <div class="critiques-container">
      <div v-for="(critique, critIndex) in critiques" :key="critIndex">
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
import type { CritiqueDto } from '@/DTO/critique'

import type { PropType } from 'vue'
import CritiqueItem from '@/components/post/CritiqueItem.vue'

const emit = defineEmits(['selected'])

function setSelected(critiqueId: string) {
  if (props.selectedCritiqueId === critiqueId) {
    emit('selected', '')
    return
  }
  emit('selected', critiqueId)
}

const props = defineProps({
  critiques: {
    type: Object as PropType<CritiqueDto[]>,
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
  width: 500px;
  min-height: 300px;
  transition: all 0.25s;
}
</style>
