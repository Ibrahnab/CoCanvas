<template>
  <RouterView />
</template>

<script setup lang="ts">
import { RouterView, useRouter } from 'vue-router'

import { onMounted } from 'vue'
import { useUserStore } from '@/stores/userStore'

const userStore = useUserStore()
const router = useRouter()

onMounted(async () => {
  try {
    const loggedIn = await userStore.getUserCredentials()
    if (!loggedIn) {
      router.push('/auth')
    }
  } catch (error) {
    // TODO: discard refresh + access tokens, keep for now for debugging
    console.log('error: ', error)
  }
})
</script>

<style scoped></style>
