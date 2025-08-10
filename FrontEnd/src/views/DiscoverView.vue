<template>
  <div>
    <SpinnerButton :spinner="showSpinnerSignout" @click="signOut">Sign Out</SpinnerButton>
    <UserPost />
  </div>
</template>
<script setup lang="ts">
import { TextBox, SpinnerButton, ErrorBox } from '@/components/common'
import { useRouter } from 'vue-router'
import UserPost from '@/components/post/UserPost.vue'
import { ref } from 'vue'

const router = useRouter()
const showSpinnerSignout = ref(false)
async function signOut() {
  try {
    localStorage.clear()
    router.push('/auth')
  } catch (error) {}
}
</script>

<style scoped lang="scss"></style>
