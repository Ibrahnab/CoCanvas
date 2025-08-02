<template>
  <div class="form-wrapper">
    <form @submit.prevent="signUp">
      <TextBox label="Email" v-model="email" />
      <TextBox label="Password" type="password" v-model="password" />
      <TextBox label="Password" type="password" v-model="confirmPassword" />

      <div class="options">
        <SpinnerButton :spinner="showSpinner" :disabled="true">Sign up</SpinnerButton>
        <button type="button" class="cancel" @click="onCancel">Cancel</button>
      </div>
    </form>
  </div>
</template>

<script lang="ts" setup>
import { TextBox, SpinnerButton } from '@/components/common'
import { useRouter } from 'vue-router'
import { ref } from 'vue'

const email = ref('')
const password = ref('')
const confirmPassword = ref('')
const showSpinner = ref(false)
const router = useRouter()

async function signUp() {
  showSpinner.value = !showSpinner.value
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
