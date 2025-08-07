<template>
  <div>
    <SpinnerButton :spinner="showSpinnerSignout" @click="signOut">Sign Out</SpinnerButton>
  </div>
</template>

<script setup lang="ts">
import { TextBox, SpinnerButton, ErrorBox } from '@/components/common'
import { ref } from 'vue'
import { useUserStore } from '@/stores/userStore'
import { useRouter } from 'vue-router'

const router = useRouter()
const showSpinnerSignout = ref(false)

async function signOut() {
  try {
    localStorage.clear()
    router.push('/')
  } catch (error) {}
}
</script>
