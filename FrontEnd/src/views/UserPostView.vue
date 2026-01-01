<template>
  <h2 class="mt-2 ms-2">Post</h2>
  <div class="post-container">
    <div class="left-side">
      <UserPostCanvas
        :imageUrl="myImage"
        :critiques="critiques"
        :selectedCritique="selectedCritique"
        :selectedCritiqueId="selectedCritiqueId"
        :myCritique="myCritique"
      />
    </div>
    <div class="right-side">
      <CritiquesPanel
        :critiques="critiques"
        :selectedCritiqueId="selectedCritiqueId"
        @selected="selectedCritiqueId = $event"
      />
    </div>
  </div>
</template>

<script setup lang="ts">
import UserPostCanvas from '@/components/post/UserPostCanvas.vue'
import CritiquesPanel from '@/components/post/CritiquesPanel.vue'
import rkgk1 from '@/assets/rkgk1.png'

import { useRoute, useRouter } from 'vue-router'
import myImage from '@/assets/rkgk1.png'
import { ref, onMounted, onBeforeUnmount, watch } from 'vue'
import type { Critique, Comment, Reply } from '@/models/critique'
import mockCritiques from '@/mockData/mockCritiques'

import guid from '@/utils/guid'

const router = useRouter()
const route = useRoute()

// TODO: Make into a map instead of array and look up selected with id
const critiques = ref<Critique[]>([]) // TODO: Get from backend
const selectedCritiqueId = ref<string>('')
const selectedCritique = ref<Critique>()
const myCritique = ref<Critique>()

// TODO: Set the one with highest rating?
function setSelectedCritique() {
  if (critiques.value.length > 0) {
    selectedCritique.value = critiques.value[0]
    // selectedCritiqueId.value = critiques.value[0].id
  }
}

function getData() {
  // TODO: Get from api

  const currentUserId = guid.zero() // TODO: Get from store
  const currentUsername = 'Sample Name' // TODO: Get from store
  critiques.value = mockCritiques // TODO: Get from api

  const myCritIndex = critiques.value.findIndex((c) => c.userId === currentUserId)

  if (myCritIndex < 0) {
    critiques.value.unshift({
      id: guid.zero(),
      userId: currentUserId,
      username: currentUsername,
      description: 'sample desc',
      published: true,
      replies: [],
      rating: 0,
      canvasJson: '',
      comments: [],
    } as Critique)
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
