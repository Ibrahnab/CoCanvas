<template>
  <div>
    <div class="upper">
      <SpinnerButton :spinner="showSpinnerSignout" @click="signOut">Sign Out</SpinnerButton>
    </div>
    <div class="left"></div>
    <div class="content">
      <slot />
    </div>
  </div>
</template>

<script setup lang="ts">
import { TextBox, SpinnerButton, ErrorBox } from '@/components/common'
import { useRouter } from 'vue-router'
import { ref } from 'vue'
const showSpinnerSignout = ref(false)

const router = useRouter()

async function signOut() {
  try {
    localStorage.clear()
    router.push('/auth')
  } catch (error) {}
}
</script>

<style scoped lang="scss">
.upper {
  background-color: $color-gray-300;
  height: 65px;
  padding-left: 65px;
  position: fixed;
  width: 100%;
}

.left {
  background-color: white;
  border-right: solid gray 1px;
  height: 100%;
  position: fixed;
  width: 65px;
}

.content {
  padding-top: 80px;
  padding-left: 80px;
}
</style>
