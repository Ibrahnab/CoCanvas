import { ref } from 'vue'

const bearerToken = ref('')
const refreshToken = ref('') // TODO: This should be stored in a httpOnly cookie?
const userName = ref('')
const expiresIn = ref('')
const email = ref('')

export const useState = () => {
  return {
    bearerToken,
    refreshToken,
    userName,
    expiresIn,
    email,
  }
}
