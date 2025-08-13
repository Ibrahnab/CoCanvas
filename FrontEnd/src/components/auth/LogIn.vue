<template>
  <div id="LoginAId" class="form-wrapper">
    <ErrorBox :error-items="errorItems" />
    <form @submit.prevent="signIn">
      <TextBox placeholder="Email" v-model="email" />
      <TextBox placeholder="Password" type="password" v-model="password" />
      <router-link to="/signup">Create a new account</router-link>

      <SpinnerButton :spinner="showSpinner">Log in</SpinnerButton>
    </form>

    <div v-if="retreivedEmail">
      <SpinnerButton :spinner="showSpinnerSignout" @click="signOut">Sign Out</SpinnerButton>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { TextBox, SpinnerButton, ErrorBox } from '@/components/common'
import { ref } from 'vue'
import * as api from '@/apiCaller'
import axios from 'axios'
import { useRouter } from 'vue-router'
import { useUserStore } from '@/stores/userStore'

const email = ref('')
const password = ref('')
const showSpinner = ref(false)
const errorItems = ref<string[]>([])
const router = useRouter()

const retreivedEmail = ref('')

const showSpinnerSignout = ref(false)

const apiCaller = api.getAxiosInstance()

const userStore = useUserStore()

async function signIn() {
  showSpinner.value = !showSpinner.value
  try {
    const loginDto = { email: email.value, password: password.value }
    const result = await apiCaller.post('/login', loginDto)

    localStorage.setItem('accessToken', result.data.accessToken)
    localStorage.setItem('refreshToken', result.data.refreshToken)

    // Re-initialize axios instance to add accesstoken
    api.initialize()

    const isLoggedIn = await userStore.getUserCredentials()
    if (isLoggedIn) {
      router.push('/')
    }
  } catch (error) {
    if (axios.isAxiosError(error)) {
      const status = error.response?.data.status

      if (status === 401) {
        errorItems.value.push('Login failed, email or password is incorrect')
      }
    }
  } finally {
    showSpinner.value = !showSpinner.value
  }
}

async function signOut() {
  showSpinnerSignout.value = true
  try {
    await apiCaller.post('/logout', {})
  } catch (error) {
    console.error(error)
  } finally {
    showSpinnerSignout.value = false
  }
}
</script>

<style scoped lang="scss">
.form-wrapper {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

input {
  max-width: 100%;
  font-size: $font-size-xs;
}

label {
  font-size: $font-size-xs;
}
</style>
