<template>
  <h1 class="mt-4 ms-4">Create Post</h1>
  <div class="ctr mt-5">
    <div class="left">
      <picture-input
        class="pictureInput"
        width="375"
        :crop="false"
        ref="pictureInputRef"
        @change="updateImage"
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

      <SpinnerButton :spinner="showSpinner" @click="createPost">Submit</SpinnerButton>
    </div>
  </div>
</template>
<script setup lang="ts">
import { TextBox, SpinnerButton, TextArea, ErrorBox } from '@/components/common'
import { getAxiosInstance } from '@/apiCaller'
import { ref, computed, onMounted } from 'vue'
import { useUserStore } from '@/stores/userStore'
// TODO: Fix this import issue
import PictureInput from 'vue-picture-input'

const api = getAxiosInstance()

const pictureInputRef = ref(null)
const image = ref<string | Blob>()

const userStore = useUserStore()

userStore.getUserCredentials()

const title = ref('')
const description = ref('')
const tags = ref('')

const showSpinner = ref(false)

// TODO: add limit
const splitTags = computed(() => tags.value.split(','))

// TODO: Move this to utilities?
function base64ToBlob(base64: string, mimeType = 'image/png'): Blob {
  const byteString = atob(base64.split(',')[1]) // decode base64
  const arrayBuffer = new ArrayBuffer(byteString.length)
  const intArray = new Uint8Array(arrayBuffer)
  for (let i = 0; i < byteString.length; i++) {
    intArray[i] = byteString.charCodeAt(i)
  }
  return new Blob([intArray], { type: mimeType })
}

function updateImage(newImage: string) {
  if (newImage) {
    image.value = base64ToBlob(newImage, 'image/png')
  } else {
    console.log('FileReader API not supported: use the <form>, Luke!')
  }
}

function valid() {
  return image.value ? true : false
}

async function createPost() {
  if (valid()) {
    showSpinner.value = true
    const formData = new FormData()
    formData.append('title', title.value)
    formData.append('description', description.value)
    formData.append('userId', userStore.currentUserId)
    splitTags.value.forEach((tag) => formData.append('tags', tag))
    if (image.value instanceof Blob) {
      formData.append('image', image.value, 'upload.png')
    }

    try {
      const response = await api.post('api/Posts', formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      })
      // TODO: Create success visual
      console.log(response)
    } catch (error) {
      console.error(error)
    } finally {
      showSpinner.value = false
    }
  }
}

onMounted(() => {})
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
