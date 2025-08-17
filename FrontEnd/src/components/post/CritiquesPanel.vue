<template>
  <div class="panel-container ps-2">
    <div class="critiques-container"><h3>Critiques</h3></div>
  </div>
</template>

<script setup lang="ts">
import CritiqueItem from './CritiqueItem.vue'
import { ref, onMounted, onBeforeUnmount, watch } from 'vue'
</script>

<style scope lang="scss">
.panel-container {
  display: flex;
  flex-direction: column;
}
.critiques-container {
  display: flex;
  flex-direction: column;

  width: 500px;
  min-height: 300px;
  padding: 15px;
  // background-color: $color-gray-100;
  // border-radius: $radius-lg;
  border-left: solid 2px rgb(173, 173, 173);
}
</style>
