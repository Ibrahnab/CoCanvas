<template>
  <div id="LoginAId">
    <form @submit.prevent="handleLogin">
      <label type="email">Email: </label>
      <input v-model="email" />

      <label>Password: </label>
      <input type="password" v-model="password" />
    </form>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue'
const email = ref('')
const password = ref('')

function handleLogin() {
  console.log('submitted!')
}
</script>

<style scoped lang="scss">
form {
  display: flex;
  justify-content: center;
  flex-direction: column;
  text-align: start;
  max-width: 20rem;
}

input {
  max-width: 100%;
  font-size: $font-size-xs;
}

label {
  font-size: $font-size-xs;
}
</style>
