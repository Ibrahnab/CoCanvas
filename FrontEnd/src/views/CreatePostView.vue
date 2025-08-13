<template>
  <h1 class="mt-4 ms-4">Create Post</h1>
  <div class="ctr mt-5">
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
      <TextArea placeholder="Enter a description (Max 256 characters)"></TextArea>
      <TextBox class="textbox" placeholder="Add tags" />
      <SpinnerButton>Submit</SpinnerButton>
    </div>
  </div>
</template>
<script setup lang="ts">
import { TextBox, SpinnerButton, TextArea } from '@/components/common'
// TODO: Fix this import issue
import PictureInput from 'vue-picture-input'
</script>

<style scoped lang="scss">
.ctr {
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
