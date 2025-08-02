<template>
  <div id="LoginAId" class="form-wrapper">
    <form @submit.prevent="signIn">
      <TextBox label="Email" v-model="email" />
      <TextBox label="Password" type="password" v-model="password" />
      <router-link to="/signup">Create a new account</router-link>

      <SpinnerButton :spinner="showSpinner">Log in</SpinnerButton>
    </form>
  </div>
</template>

<script lang="ts" setup>
import { TextBox, SpinnerButton } from '@/components/common'
import { ref } from 'vue'
import axios from 'axios'

const email = ref('')
const password = ref('')
const showSpinner = ref(false)

async function signIn() {
  showSpinner.value = !showSpinner.value
  try {
    const result = await axios.get('https://localhost:5003/WeatherForecast')
    console.log('result: ', result)
  } finally {
    showSpinner.value = !showSpinner.value
  }
}
</script>

<style scoped lang="scss">
.form-wrapper {
  display: flex;
  justify-content: center;
}

form {
  display: flex;
  justify-content: center;
  flex-direction: column;
  gap: 10px;
  text-align: start;
  max-width: 50rem;
  width: 20rem;
}

input {
  max-width: 100%;
  font-size: $font-size-xs;
}

label {
  font-size: $font-size-xs;
}
</style>
