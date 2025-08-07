import { ref } from 'vue'

const userName = ref<string>('')
const email = ref<string>('')

export const useState = () => {
  return {
    userName,
    email,
  }
}
