<template>
  <div
    class="compose-container"
    :class="{ toggled: selectedCritiqueId === guid.zero() }"
    @click="setSelected"
  >
    <!-- TOOD: Maybe remove and just use CritiqueItem -->
    <TextArea
      :placeholder="'Write your general feedback here, add specific comments from the toolbox'"
    ></TextArea>
    <SpinnerButton class="mt-3">Publish</SpinnerButton>
  </div>
</template>

<script lang="ts" setup>
import { TextBox, TextArea, SpinnerButton } from '@/components/common'
import type { CreateCritiqueDto } from '@/DTO'
import { useUserStore, usePostStore } from '@/stores'
import { getAxiosInstance } from '@/apiCaller'
import { storeToRefs } from 'pinia'
import guid from '@/utils/guid'

const userStore = useUserStore()
const postStore = usePostStore()
const axios = getAxiosInstance()

const { selectedCritiqueId } = storeToRefs(postStore)

async function publishCritique() {
  try {
    // TODO: Implement endpoint in backend for creating one
  } catch (error) {}
}

function setSelected() {
  postStore.setSelectedCritiqueId(guid.zero())
}
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

.toggled {
  box-shadow: 0 0 10px rgba(94, 58, 255, 0.3);
}
</style>
