<template>
  <RouterView />
</template>

<script setup lang="ts">
import { RouterLink, RouterView, useRouter } from 'vue-router'

// import { getAxiosInstance } from '@/apiCaller'
// import type { UserResponse } from '@/models/User'

import { onMounted, ref } from 'vue'
import { useUserStore } from '@/stores/userStore'

const userStore = useUserStore()
const router = useRouter()

// const email = ref('')
// const apiCaller = getAxiosInstance()

// async function getUserCredentials() {
//   const token = localStorage.getItem('accessToken')
//   console.log('accessToken: ', token)
//   if (token) {
//     try {
//       const result: UserResponse = await apiCaller.get('api/auth/me')
//       userStore.email = email

//       console.log('email: ', email.value)
//     } catch (error) {
//       // TODO: show popup
//       console.error(error)
//     }
//   }
// }

onMounted(async () => {
  console.log(userStore.email)
  try {
    const loggedIn = await userStore.getUserCredentials()
    if (loggedIn) {
      router.push('/home')
    }
  } catch (error) {
    console.log('error: ', error)
  }
})
</script>

<style scoped></style>
