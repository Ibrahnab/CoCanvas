<template>
  <div v-if="reply" class="reply-wrapper pt-3 pb-3">
    <avatar-circle class="reply-image" :image="userImage" />
    <div class="reply-content-wrapper">
      <h5>{{ reply.username }}</h5>
      <div>{{ reply.text }}</div>
    </div>
  </div>
</template>
<script setup lang="ts">
import { watch, ref, onMounted } from 'vue'
import type { PropType } from 'vue'
import { getAxiosInstance } from '@/apiCaller'
import type { ReplyDto } from '@/DTO/critique'
import { AvatarCircle } from '@/components/common'

const axios = getAxiosInstance()

const userImage = ref<string>()

const props = defineProps({
  reply: {
    type: Object as PropType<ReplyDto>,
  },
  imageUrl: {
    type: String,
    default: '',
  },
})

async function loadData() {
  // TODO: Get the actual image of the user
  try {
    const result = await axios.get<Blob>('api/Posts/images/defaultProfilePicture.jpg', {
      responseType: 'blob',
    })
    console.log('img: ', result)
    userImage.value = URL.createObjectURL(result.data)
  } catch (error) {
    console.error('Failed to get user reply profileIcon: ', error)
  }
}

onMounted(() => {
  loadData()
})

watch(
  () => props.reply,
  (newValue) => {
    if (newValue) {
      loadData()
    }
  },
)
</script>

<style scoped lang="scss"></style>
