<template>
  <!-- Add messagebox covering the whole page -->
  <NavHeader>
    <Router-View />
  </NavHeader>
</template>

<script setup lang="ts">
import { TextBox, SpinnerButton, ErrorBox } from '@/components/common'
import { ref } from 'vue'
import NavHeader from '@/components/nav/NavHeader.vue'
import UserPost from '@/views/UserPostView.vue'
import { useUserStore } from '@/stores/userStore'
import { useRouter, RouterView } from 'vue-router'

const router = useRouter()
const showSpinnerSignout = ref(false)

async function signOut() {
  try {
    localStorage.clear()
    router.push('/')
  } catch (error) {}
}
</script>
