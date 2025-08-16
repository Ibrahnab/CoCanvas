<template>
  <div class="ctr2">
    <h3>Comments</h3>
    <!-- <CommentItem></CommentItem> -->
  </div>
</template>

<script setup lang="ts">
import CommentItem from './CanvasComment.vue'
</script>

<style scope lang="scss">
.ctr2 {
  display: flex;
  flex-direction: column;

  width: 500px;
  min-height: 300px;
  padding: 15px;
  // background-color: $color-gray-100;
  // border-radius: $radius-lg;
  border-left: solid 2px rgb(215, 215, 215);
}
</style>
