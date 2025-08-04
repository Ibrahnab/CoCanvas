<template>
  <div class="form-wrapper">
    <form @submit.prevent="signUp">
      <TextBox label="Email" v-model="email" />
      <TextBox label="Password" type="password" v-model="password" />
      <TextBox label="Confirm password" type="password" v-model="confirmPassword" />

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
import { TextBox, SpinnerButton, CheckBox } from '@/components/common'
import { useRouter } from 'vue-router'
import { ref } from 'vue'
import { getAxiosInstance } from '@/apiCaller'

const email = ref('')
const password = ref('')
const confirmPassword = ref('')
const showSpinner = ref(false)
const acceptedTOS = ref(false)
const router = useRouter()
const api = getAxiosInstance()

async function signUp() {
  showSpinner.value = true

  try {
    const response = await api.get('/WeatherForecast')
    console.log('response: ', response)
  } catch (error) {
    console.error(error)
  } finally {
    showSpinner.value = false
  }
}

function onCancel() {
  router.push('auth')
}
</script>

<style scoped lang="scss">
.form-wrapper {
  display: flex;
  justify-content: center;
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
