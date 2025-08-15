<template>
  <div>
    <div class="upper">
      <!-- <SpinnerButton :spinner="showSpinnerSignout" @click="signOut">Sign Out</SpinnerButton> -->
      <TextBox icon="magnifying-glass" placeholder="Search" />
      <AvatarCircle :image="tall" />
    </div>
    <div class="left">
      <IconButton
        icon="compass"
        :onClick="() => router.push('/')"
        :toggled="route.fullPath.length === 1"
      />
      <IconButton
        icon="house"
        :onClick="() => router.push('/home')"
        :toggled="route.fullPath.includes('home')"
      />
      <IconButton
        icon="square-plus"
        :onClick="() => router.push('/create-post')"
        :toggled="route.fullPath.includes('create-post')"
      />
      <IconButton icon="bell" />
    </div>
    <div class="content">
      <slot />
    </div>
  </div>
</template>

<script setup lang="ts">
import { TextBox, SpinnerButton, IconButton, AvatarCircle } from '@/components/common'
import { useRouter, useRoute } from 'vue-router'
import { ref, onMounted } from 'vue'

const route = useRoute()
const router = useRouter()

import tall from '@/assets/tall1.png'
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons'

const showSpinnerSignout = ref(false)
const iconSize = 30

function goClick() {}

async function signOut() {
  try {
    localStorage.clear()
    router.push('/auth')
  } catch (error) {}
}

onMounted(() => {})
</script>

<style scoped lang="scss">
.upper {
  background-color: white;
  height: 65px;
  padding-left: 80px;
  position: fixed;
  width: 100%;
  display: flex;
  flex-direction: row;
  align-items: right;
  justify-content: right;
  gap: 20px;
  padding-top: 10px;
  padding-bottom: 10px;
  padding-right: 20px;
  box-shadow:
    rgba(17, 17, 26, 0.1) 0px 3px 16px,
    rgba(17, 17, 26, 0.1) 0px 3px 10px,
    rgba(17, 17, 26, 0.1) 0px 3px 10px;
  z-index: 1;
}

.left {
  background-color: white;
  border-right: solid $color-gray-300 1px;
  height: 100%;
  position: fixed;
  width: 75px;
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 50px;
  padding-top: 20px;
  z-index: 2;
}

.icon:hover {
  cursor: pointer;
}

.content {
  padding-top: 80px;
  padding-left: 90px;
  padding-right: 10px;
}
</style>
