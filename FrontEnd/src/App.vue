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

import { onMounted, ref } from 'vue'

const email = ref('')

function getUserCredentials() {
  const token = localStorage.getItem('accessToken')
  console.log('accessToken: ', token)
}

onMounted(() => {
  getUserCredentials()
})
</script>

<style scoped></style>
