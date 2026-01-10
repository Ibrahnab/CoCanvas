<template>
  <div class="post-container mt-2">
    <div class="left-side">
      <UserPostCanvas
        :imageUrl="imageUrl"
        :critiques="critiques"
        :selected-critique="selectedCritique"
        :selected-critique-id="selectedCritiqueId"
        :myCritique="myCritique"
      />
    </div>
    <div class="right-side">
      <PostAndCritiquesPanel
        :post="postData"
        :selectedCritiqueId="selectedCritiqueId"
        @selected="selectedCritiqueId = $event"
      />
    </div>
  </div>
</template>

<script setup lang="ts">
import UserPostCanvas from '@/components/post/UserPostCanvas.vue'
import PostAndCritiquesPanel from '@/components/post/PostAndCritiquesPanel.vue'
import { getAxiosInstance } from '@/apiCaller'

import { useRoute, useRouter } from 'vue-router'
// import myImage from '@/assets/rkgk1.png'
import { ref, onMounted, onBeforeUnmount, watch } from 'vue'
import type { CritiqueDto, CommentDto, ReplyDto } from '@/DTO/critique'
import type { PostDto } from '@/DTO/post'
import mockCritiques from '@/mockData/mockCritiques'

import { useUserStore, usePostStore } from '@/stores'
import { storeToRefs } from 'pinia'

const router = useRouter()
const route = useRoute()

const userStore = useUserStore()
const postStore = usePostStore()

const axios = getAxiosInstance()

// TODO: Make into a map instead of array and look up selected with id
const critiques = ref<CritiqueDto[]>([]) // TODO: Get from backend
const selectedCritiqueId = ref<string>('')
const selectedCritique = ref<CritiqueDto>()
const myCritique = ref<CritiqueDto>()

const postData = ref<PostDto>()
const imageUrl = ref<string>('')

// TODO: Set the one with highest rating?
// function setSelectedCritique() {
//   if (critiques.value.length > 0) {
//     selectedCritique.value = critiques.value[0]
//     // selectedCritiqueId.value = critiques.value[0].id
//   }
// }

function mapData(post: PostDto) {
  postData.value = post
  imageUrl.value = post.imageUrl

  // TODO: Remove the temporary critique, just for testing purposes now

  const tempPost = { ...post }
  tempPost.critiques.push(...mockCritiques)
  postStore.initialize(tempPost)
  // postStore.setCritiques(tempPost.critiques)
}

async function getData() {
  const result = await axios.get<PostDto>(`api/posts/${route.params.id}`)
  // const imageUrl.value = await axios.get(`api/Posts/images/${result.data.imageUrl}`)
  mapData(result.data)

  const { currentUserId, userName } = storeToRefs(userStore) // TODO: Get from store
  // const currentUsername = 'Sample Name' // TODO: Get from store
  critiques.value = mockCritiques // TODO: Get from api
}

onMounted(() => {
  getData()
  // setSelectedCritique()
})
</script>

<style scoped lang="scss">
.post-container {
  display: flex;
  justify-content: center;
  gap: 20px;
}

.left-side {
}
.right-side {
}
</style>
