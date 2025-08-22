import { ref } from 'vue'

const currentUserId = ref<string>('')
const userName = ref<string>('')
const email = ref<string>('')

export const useState = () => {
  return {
    currentUserId,
    userName,
    email,
  }
}
