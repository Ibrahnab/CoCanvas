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
      <TextBox v-model="title" class="textbox" placeholder="Enter a title" />
      <TextArea
        v-model="description"
        placeholder="Enter a description (Max 256 characters)"
      ></TextArea>
      <TextBox v-model="tags" class="textbox" placeholder="Add tags" />
      <div class="tags-wrapper">
        <span v-for="(tag, index) in splitTags" :key="index"> #{{ tag }} </span>
      </div>

      <SpinnerButton>Submit</SpinnerButton>
    </div>
  </div>
</template>
<script setup lang="ts">
import { TextBox, SpinnerButton, TextArea } from '@/components/common'
import { getAxiosInstance } from '@/apiCaller'
import { ref, computed, onMounted } from 'vue'
import { useUserStore } from '@/stores/userStore'
// TODO: Fix this import issue
import PictureInput from 'vue-picture-input'

const api = getAxiosInstance()

const image = ref('')

const userStore = useUserStore()

userStore.getUserCredentials()

const title = ref('')
const description = ref('')
const tags = ref('')

// TODO: add limit
const splitTags = computed(() => tags.value.split(','))

async function createPost() {}

onMounted(() => {
  console.log(userStore.currentUserId)
})
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

.tags-wrapper {
  display: flex;
  flex-direction: row;
  gap: 10px;
}
</style>
