<template>
  <div id="LoginAId" class="form-wrapper">
    <form @submit.prevent="handleLogin">
      <TextBox label="Email" v-model="email" />
      <TextBox label="Password" type="password" v-model="password" />

      <SpinnerButton>Log in</SpinnerButton>
    </form>
  </div>
</template>

<script lang="ts" setup>
import { TextBox, SpinnerButton } from '@/components/common'
import { ref } from 'vue'
const email = ref('')
const password = ref('')

function handleLogin() {
  console.log('submitted!')
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
