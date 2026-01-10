import { useState } from './state'
import type { CritiqueDto, PostDto, CommentDto, AddedOrEditedComment } from '@/DTO'
import guid from '@/utils/guid'

export function useActions() {
  const state = useState()

  function setSelectedCritiqueId(id: string) {
    if (id === state.selectedCritiqueId.value) {
      state.selectedCritiqueId.value = ''
      return
    }
    console.log('setting to ', id)
    state.selectedCritiqueId.value = id
  }
  function setCritiques(critiques: CritiqueDto[]) {
    critiques.forEach((c) => {
      state.critiques.value[c.id] = c
    })
  }

  function addComment(comment: AddedOrEditedComment) {
    console.log('adding: ', comment)
    state.addedOrEditedComments.value.push(comment)
  }
  function removeUnsavedComment(id: string) {}

  // TODO: Simplify, by using record maybe
  function deleteComment(id: string) {}

  function clearStore() {}

  // TODO: Extend
  function initialize(post: PostDto) {
    state.currentPost.value = post
    setCritiques(post.critiques)
  }
  return {
    setSelectedCritiqueId,
    setCritiques,
    addComment,
    removeUnsavedComment,
    deleteComment,
    clearStore,
    initialize,
  }
}
