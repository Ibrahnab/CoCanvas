<template>
  <h2 class="mt-2 ms-2">Post</h2>
  <div class="post-container">
    <div class="left-side">
      <UserPostCanvas
        :imageUrl="imageUrl"
        :critiques="critiques"
        :selectedCritique="selectedCritique"
        :selectedCritiqueId="selectedCritiqueId"
        :myCritique="myCritique"
      />
    </div>
    <div class="right-side">
      <PostAndCritiquesPanel
        :critiques="critiques"
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
import rkgk1 from '@/assets/rkgk1.png'

import { useRoute, useRouter } from 'vue-router'
// import myImage from '@/assets/rkgk1.png'
import { ref, onMounted, onBeforeUnmount, watch } from 'vue'
import type { CritiqueDto, CommentDto, ReplyDto } from '@/DTO/critique'
import type { PostDto } from '@/DTO/post'
import mockCritiques from '@/mockData/mockCritiques'

import { useUserStore } from '@/stores/userStore'
import { storeToRefs } from 'pinia'

import guid from '@/utils/guid'

const router = useRouter()
const route = useRoute()

const userStore = useUserStore()

const axios = getAxiosInstance()

// TODO: Make into a map instead of array and look up selected with id
const critiques = ref<CritiqueDto[]>([]) // TODO: Get from backend
const selectedCritiqueId = ref<string>('')
const selectedCritique = ref<CritiqueDto>()
const myCritique = ref<CritiqueDto>()

const postData = ref<PostDto>()
const imageUrl = ref<string>('')

// TODO: Set the one with highest rating?
function setSelectedCritique() {
  if (critiques.value.length > 0) {
    selectedCritique.value = critiques.value[0]
    // selectedCritiqueId.value = critiques.value[0].id
  }
}

function mapData(post: PostDto) {
  postData.value = post
  console.log('imageUrl: ')
  imageUrl.value = post.imageUrl
}

async function getData() {
  // TODO: Get from api

  const result = await axios.get<PostDto>(`api/posts/${route.params.id}`)
  // const imageUrl.value = await axios.get(`api/Posts/images/${result.data.imageUrl}`)
  mapData(result.data)

  const { currentUserId, userName } = storeToRefs(userStore) // TODO: Get from store
  // const currentUsername = 'Sample Name' // TODO: Get from store
  critiques.value = mockCritiques // TODO: Get from api

  const myCritIndex = critiques.value.findIndex((c) => c.userId === currentUserId.value)

  // If the viewing user hasn't made a critique on this post,
  // create an empty one to be filled and put in the beginning
  if (myCritIndex < 0) {
    critiques.value.unshift({
      id: guid.zero(),
      userId: currentUserId.value,
      username: userName.value,
      description: 'sample desc',
      published: true,
      replies: [],
      rating: 0,
      comments: [],
      createdAt: '2030-01-01T23:15:33.008Z',
    } as CritiqueDto)
    myCritique.value = critiques.value[0]
  } else {
    // Why even do this?
    myCritique.value = critiques.value[myCritIndex]
  }
}

onMounted(() => {
  getData()
  setSelectedCritique()
})
</script>

<style scope lang="scss">
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
