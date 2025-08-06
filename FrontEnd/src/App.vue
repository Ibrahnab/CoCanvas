<template>
  <header>
    <div class="">
      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/about">About</RouterLink>
        <RouterLink to="/auth">Login</RouterLink>
        <span>{{ email }}</span>
      </nav>
    </div>
  </header>

  <RouterView />
</template>

<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'

import { getAxiosInstance } from '@/apiCaller'
import type { AxiosResponse } from 'axios'

import { onMounted, ref } from 'vue'

const email = ref('')
const apiCaller = getAxiosInstance()

interface UserResponse extends AxiosResponse {
  email: string
}

async function getUserCredentials() {
  const token = localStorage.getItem('accessToken')
  console.log('accessToken: ', token)
  if (token) {
    try {
      const result: UserResponse = await apiCaller.get('api/auth/me')
      email.value = result.data.email
      console.log('email: ', email.value)
    } catch (error) {
      console.error(error)
    }
  }
}

onMounted(() => {
  getUserCredentials()
})
</script>

<style scoped></style>
