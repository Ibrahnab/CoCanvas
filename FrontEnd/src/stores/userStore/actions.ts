import { getAxiosInstance } from '@/apiCaller'
import type { UserResponse } from '@/models/User'
import { useState } from './state'

export const useActions = () => {
  const state = useState()
  const apiCaller = getAxiosInstance()

  async function getUserCredentials() {
    const token = localStorage.getItem('accessToken')
    if (token) {
      try {
        const result: UserResponse = await apiCaller.get('api/auth/me')

        state.currentUserId.value = result.data.id
        state.email.value = result.data.email
        state.userName.value = result.data.email
        return true
      } catch (error) {
        throw error
      }
    }
  }
  return { getUserCredentials }
}
