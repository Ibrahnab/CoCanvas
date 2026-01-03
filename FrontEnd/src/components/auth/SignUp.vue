<template>
  <div class="form-wrapper">
    <ErrorBox :error-items="errorItems" />
    <form @submit.prevent="isValid">
      <TextBox placeholder="Username" v-model="username" />
      <TextBox placeholder="Email" v-model="email" />
      <TextBox placeholder="Password" type="password" v-model="password" />
      <TextBox placeholder="Confirm password" type="password" v-model="confirmPassword" />

      <div class="terms">
        <CheckBox
          v-model="acceptedTOS"
          description="I have read and accepted the terms and conditions"
        />
      </div>

      <div class="options">
        <SpinnerButton :spinner="showSpinner" :disabled="!acceptedTOS">Sign up</SpinnerButton>
        <button type="button" class="cancel" @click="onCancel">Cancel</button>
      </div>
    </form>
  </div>
</template>

<script lang="ts" setup>
import { TextBox, SpinnerButton, CheckBox, ErrorBox } from '@/components/common'
import { useRouter } from 'vue-router'
import { ref } from 'vue'
import { getAxiosInstance } from '@/apiCaller'
import axios from 'axios'

const username = ref('')
const email = ref('')
const password = ref('')
const confirmPassword = ref('')
const showSpinner = ref(false)
const acceptedTOS = ref(false)
const router = useRouter()
const errorItems = ref<string[]>([])
const api = getAxiosInstance()

function validate() {
  if (email.value === '') {
    errorItems.value.push('Enter a valid email address')
  }
  if (password.value === '') {
    errorItems.value.push('Enter a valid password')
  }
  if (password.value !== confirmPassword.value) {
    errorItems.value.push('Password does not match')
  }
}

async function isValid() {
  errorItems.value = []
  validate()
  if (errorItems.value.length === 0) {
    signUp()
  }
}

async function signUp() {
  showSpinner.value = true
  try {
    const dto = { username: username.value, email: email.value, password: password.value }
    await api.post('api/register', dto)
  } catch (error) {
    if (axios.isAxiosError(error)) {
      const errors = error.response?.data.errors
      errorItems.value = Object.values(errors)
    }
  } finally {
    showSpinner.value = false
  }
}

function onCancel() {
  router.push('/auth')
}
</script>

<style scoped lang="scss">
.form-wrapper {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.options {
  display: flex;
  justify-content: start;
  gap: 10px;
  flex-direction: row;
}

.cancel {
  background-color: rgb(183, 183, 183);
}
</style>
