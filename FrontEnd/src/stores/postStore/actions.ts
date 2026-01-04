import { useState } from './state'
import type { CritiqueDto, PostDto } from '@/DTO'

export function useActions() {
  const state = useState()
  return {
    setPost: (post: PostDto) => {
      state.currentPost.value = post
    },
    setSelectedCritiqueId: (id: string) => {
      state.selectedCritiqueId.value = id
    },
    setSelectedCritique: (critique: CritiqueDto) => {
      state.currentCritique.value = critique
    },
  }
}
