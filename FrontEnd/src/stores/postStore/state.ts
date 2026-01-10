import { ref } from 'vue'
import type {
  CritiqueDto,
  PostDto,
  CreateOrEditCritiqueDto,
  CommentDto,
  AddedOrEditedComment,
} from '@/DTO'
import guid from '@/utils/guid'
import { useUserStore } from '../userStore'

const currentPost = ref<PostDto>()
// const currentCritique = ref<CritiqueDto>()
const selectedCritiqueId = ref<string>('')
const critiques = ref<Record<string, CritiqueDto>>({})
const deletedCommentIds = ref<string[]>([])
const addedOrEditedComments = ref<AddedOrEditedComment[]>([])
// const unsavedComments = ref<CommentDto[]>([])
// const deletedComments = ref<CommentDto[]>([])

const composedCritique = ref<CreateOrEditCritiqueDto>({
  userId: '',
  description: '',
  comments: [],
  deletedCommentIds: [],
  critiqueCanvas: '',
})

export function useState() {
  const userStore = useUserStore()
  composedCritique.value.userId = userStore.currentUserId
  return {
    currentPost,
    // currentCritique,
    selectedCritiqueId,
    critiques,
    composedCritique,
    deletedCommentIds,
    addedOrEditedComments,
    // unsavedComments,
    // deletedComments,
  }
}
