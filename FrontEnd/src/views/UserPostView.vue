<template>
  <h2 class="mt-2 ms-2">Post</h2>
  <div class="ctr">
    <div class="left">
      <UserPostCanvas /> <span>{{ route.params.id }}</span>
    </div>
    <div class="right">
      <CommentsPanel />
    </div>
  </div>
</template>

<script setup lang="ts">
import UserPostCanvas from '@/components/post/UserPostCanvas.vue'
import CommentsPanel from '@/components/post/CommentsPanel.vue'

import { useRoute, useRouter } from 'vue-router'

const router = useRouter()
const route = useRoute()
</script>

<style scope lang="scss">
.ctr {
  display: flex;
  align-items: top;
  justify-content: center;
  gap: 20px;
}

.left {
}
.right {
}
</style>
