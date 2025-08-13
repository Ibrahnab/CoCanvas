<template>
  <h1>Create Post</h1>
  <div class="container">
    <TextBox placeholder="Enter a title" />
    <picture-input class="pictureInput" width="375" height="375" ref="pictureInput"></picture-input>
    <SpinnerButton>Submit</SpinnerButton>
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
  flex-direction: column;
  gap: 20px;
}
</style>
