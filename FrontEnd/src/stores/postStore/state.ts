import { ref } from 'vue'
import type {
  CritiqueDto,
  PostDto,
  CreateOrEditCritiqueDto,
  CommentDto,
  AddedOrEditedComment,
} from '@/DTO'
import guid from '@/utils/guid'
import { storeToRefs } from 'pinia'

import { useUserStore } from '../userStore'

const currentPost = ref<PostDto>()
const selectedCritiqueId = ref<string>('')
const critiques = ref<Record<string, CritiqueDto>>({})
const deletedCommentIds = ref<string[]>([])
const addedOrEditedComments = ref<AddedOrEditedComment[]>([])

const composedCritique = ref<CreateOrEditCritiqueDto>({
  userId: '',
  description: '',
  comments: [],
  deletedCommentIds: [],
  critiqueCanvas: '',
})

export function useState() {
  const userStore = useUserStore()

  const { currentUserId } = storeToRefs(userStore)
  composedCritique.value.userId = currentUserId.value
  return {
    currentPost,
    selectedCritiqueId,
    critiques,
    composedCritique,
    deletedCommentIds,
    addedOrEditedComments,
  }
}
