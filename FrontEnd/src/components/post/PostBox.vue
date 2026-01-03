<template>
  <div v-if="post" class="post-wrapper">
    <RateableUserHeader
      :rateable-item-id="post.id"
      :user-image-url="'defaultProfilePicture.jpg'"
      :username="post.username"
      :created-at="post.createdAt"
      :rating="post.rating"
    />
  </div>
</template>

<script setup lang="ts">
import { ref, watch, onMounted } from 'vue'
import type { PropType } from 'vue'
import type { PostDto } from '@/DTO/post'
import { TextBox, AvatarCircle } from '@/components/common'
import RateableUserHeader from './RateableUserHeader.vue'

const props = defineProps({
  post: {
    type: Object as PropType<PostDto>,
  },
})
</script>

<style scoped lang="scss">
.post-wrapper {
  padding: 10px;
  border-radius: $radius-md;
  box-shadow: 0 0 10px rgb(0, 0, 0, 0.3);

  &:hover {
    transition: all 0.5s ease;
    box-shadow: 0 0 10px rgba(94, 58, 255, 0.3);
  }
}
</style>
