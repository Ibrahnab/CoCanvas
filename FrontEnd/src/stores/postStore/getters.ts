import { useState } from './state'
import { useUserStore } from '@/stores'
import { storeToRefs } from 'pinia'
import guid from '@/utils/guid'

export function useGetters() {
  const state = useState()
  const userStore = useUserStore()
  return {
    getSelectedCritique: () => {
      return state.critiques.value[state.selectedCritiqueId.value]
    },
    isSelectedCritiqueMine: () => {
      const { currentUserId } = storeToRefs(userStore)
      return (
        state.selectedCritiqueId.value === currentUserId.value ||
        state.selectedCritiqueId.value === guid.zero()
      )
    },
  }
}
