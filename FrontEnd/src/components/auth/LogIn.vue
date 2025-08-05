<template>
  <div id="LoginAId" class="form-wrapper">
    <ErrorBox :error-items="errorItems" />
    <form @submit.prevent="signIn">
      <TextBox label="Email" v-model="email" />
      <TextBox label="Password" type="password" v-model="password" />
      <router-link to="/signup">Create a new account</router-link>

      <SpinnerButton :spinner="showSpinner">Log in</SpinnerButton>
    </form>
  </div>
</template>

<script lang="ts" setup>
import { TextBox, SpinnerButton, ErrorBox } from '@/components/common'
import { ref } from 'vue'
import * as api from '@/apiCaller'
import axios from 'axios'

const email = ref('')
const password = ref('')
const showSpinner = ref(false)
const errorItems = ref<string[]>([])

const apiCaller = api.getAxiosInstance()

async function signIn() {
  showSpinner.value = !showSpinner.value
  try {
    const loginDto = { email: email.value, password: password.value }
    const result = await apiCaller.post('/login', loginDto)

    localStorage.setItem('accessToken', result.data.accessToken)
    localStorage.setItem('refreshToken', result.data.refreshToken)

    // Re-initialize axios instance to add accesstoken
    api.initialize()

    const res2 = await apiCaller.get('/me')
    console.log('ME: ', res2)
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
