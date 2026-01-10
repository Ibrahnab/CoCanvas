import { useUserStore } from '@/stores'
import { storeToRefs } from 'pinia'
import { computed } from 'vue'
import { useState } from './state'
import type { AddedOrEditedComment, CommentDto } from '@/DTO'
import guid from '@/utils/guid'

export function useGetters() {
  const state = useState()
  const userStore = useUserStore()

  const getSelectedCritique = computed(() => {
    {
      return state.critiques.value[state.selectedCritiqueId.value]
    }
  })
  function getCritique(id: string) {
    return computed(() => {
      return state.critiques.value[id]
    })
  }
  function isCritiqueMine(id: string) {
    const { currentUserId } = storeToRefs(userStore)
    return currentUserId.value === state.critiques.value[id]?.userId || id === guid.zero()
  }
  function getUnsavedComments() {
    return computed(() => {
      if (!isCritiqueMine(state.selectedCritiqueId.value)) return []
      return state.addedOrEditedComments.value.filter((c) => c.clientId !== null)
    })
  }

  // TODO: This will trigger for all critique items, do pagination when rendering critiques
  function getAllComments(critId: string) {
    return computed(() => {
      if (critId === '') {
        return []
      }
      // const selectedCritiqueId = state.selectedCritiqueId.value
      let resultCommentList: (CommentDto | AddedOrEditedComment)[] = []
      // Get the comments saved in the critique, skip if composing critique
      if (critId !== guid.zero()) {
        resultCommentList = [...state.critiques.value[critId]?.comments]
      }
      // If no critique is selected
      if (critId === '') {
        return resultCommentList
      }

      if (isCritiqueMine(critId)) {
        const addedOrEditedComments = state.addedOrEditedComments.value.filter(
          (c) => c.clientId !== null,
        )
        resultCommentList = [...addedOrEditedComments, ...resultCommentList]
      }

      // Get added or edited comments, this applies only to the user who is viewing the posts
      return resultCommentList
    })
  }

  function getCurrentComments() {
    return computed(() => {
      return getAllComments(state.selectedCritiqueId.value).value
    })
  }

  return {
    getSelectedCritique,
    getCritique,
    isCritiqueMine,
    getUnsavedComments,
    getAllComments,
    getCurrentComments,
  }
}
