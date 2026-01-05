import { ref } from 'vue'
import type { CritiqueDto, PostDto, CreateCritiqueDto, CommentDto } from '@/DTO'
import { useUserStore } from '../userStore'

const currentPost = ref<PostDto>()
const currentCritique = ref<CritiqueDto>()
const selectedCritiqueId = ref<string>('')
const critiques = ref<Record<string, CritiqueDto>>({})
const unsavedComments = ref<CommentDto[]>([])
const deletedComments = ref<CommentDto[]>([])

const composedCritique = ref<CreateCritiqueDto>({
  userId: '',
  description: '',
  comments: [],
  critiqueCanvas: '',
})

export function useState() {
  const userStore = useUserStore()
  composedCritique.value.userId = userStore.currentUserId
  return {
    currentPost,
    currentCritique,
    selectedCritiqueId,
    critiques,
    composedCritique,
    unsavedComments,
    deletedComments,
  }
}
