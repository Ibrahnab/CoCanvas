import { ref } from 'vue'
import type { CritiqueDto, PostDto } from '@/DTO'

const currentPost = ref<PostDto>()
const currentCritique = ref<CritiqueDto>()
const selectedCritiqueId = ref<string>('')

export function useState() {
  return {
    currentPost,
    currentCritique,
    selectedCritiqueId,
  }
}
