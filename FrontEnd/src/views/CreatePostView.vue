<template>
  <h1>Create Post</h1>
  <div class="container mt-2">
    <div class="left">
      <picture-input
        class="pictureInput"
        width="375"
        height="375"
        ref="pictureInput"
      ></picture-input>
    </div>
    <div class="right">
      <TextBox class="textbox" placeholder="Enter a title" />
      <TextBox class="textbox" placeholder="Add tags" />
      <SpinnerButton>Submit</SpinnerButton>
    </div>
  </div>
</template>
<script setup lang="ts">
import { TextBox, SpinnerButton } from '@/components/common'
// TODO: Fix this import issue
import PictureInput from 'vue-picture-input'
</script>

<style scoped lang="scss">
.container {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: row;
  gap: 60px;
}

.left {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}

.right {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  width: 300px;
  gap: 20px;
}

.textbox {
  max-width: 300px;
}
</style>
