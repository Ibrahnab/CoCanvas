import { useState } from './state'

export const useGetters = () => {
  const state = useState()

  const getUserName = () => {
    return state.userName
  }

  return {
    getUserName,
  }
}
