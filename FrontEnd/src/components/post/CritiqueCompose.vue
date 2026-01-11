<template>
  <div
    class="compose-container"
    :class="{ toggled: selectedCritiqueId === guid.zero() }"
    @click="setSelected"
  >
    <TextArea
      :placeholder="'Write your general feedback here, add specific comments from the toolbox'"
    ></TextArea>

    <!-- TODO: Make a component and extend  -->
    <div class="comment-wrapper" v-for="(comment, comIndex) in comments" :key="comIndex">
      <div class="pb-2">
        {{ comment.text }}
      </div>
    </div>
    <SpinnerButton class="mt-3" @click="publishCritique">Publish</SpinnerButton>
  </div>
</template>

<script lang="ts" setup>
import { TextBox, TextArea, SpinnerButton } from '@/components/common'
// import type { CreateCritiqueDto } from '@/DTO'
import { useUserStore, usePostStore } from '@/stores'
import { getAxiosInstance } from '@/apiCaller'
import { storeToRefs } from 'pinia'
import guid from '@/utils/guid'
import { watch } from 'vue'

const userStore = useUserStore()
const postStore = usePostStore()
const axios = getAxiosInstance()

const { selectedCritiqueId } = storeToRefs(postStore)
const comments = postStore.getAllComments(guid.zero())

async function publishCritique() {
  try {
    // TODO: Implement endpoint in backend for creating one

    await axios.post(`api/Posts/${'asd'}/critiques`)
  } catch (error) {}
}

function setSelected() {
  console.log('setting selected')
  postStore.setSelectedCritiqueId(guid.zero())
}

// watch(comments.value, (newValue) => {
//   console.log('new state value: ', newValue)
// })
</script>

<style lang="scss" scoped>
.compose-container {
  padding: 10px;
  border-radius: $radius-md;
  height: auto;
  box-shadow: 0 0 10px rgb(0, 0, 0, 0.3);

  &:hover {
    transition: all 0.5s ease;
    box-shadow: 0 0 10px rgba(94, 58, 255, 0.3);
  }
}

.comment-wrapper {
  display: flex;
  flex-direction: column;
  background-color: $color-gray-200;
  padding: 10px;
  margin-top: 10px;
  border-radius: 10px;
}

.toggled {
  box-shadow: 0 0 10px rgba(94, 58, 255, 0.3);
}
</style>
