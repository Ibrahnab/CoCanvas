import { useState } from './state'
import type { CritiqueDto, PostDto, CommentDto } from '@/DTO'
import guid from '@/utils/guid'

export function useActions() {
  const state = useState()
  return {
    setPost: (post: PostDto) => {
      state.currentPost.value = post
    },
    setSelectedCritiqueId: (id: string) => {
      if (id === state.selectedCritiqueId.value) {
        state.selectedCritiqueId.value = ''
        return
      }
      state.selectedCritiqueId.value = id
    },
    setSelectedCritique: (critique: CritiqueDto) => {
      state.currentCritique.value = critique
    },
    setCritiques: (critiques: CritiqueDto[]) => {
      critiques.forEach((c) => {
        state.critiques.value[c.id] = c
      })
    },
    addComment: (comment: CommentDto) => {
      console.log('adding: ', comment)
      // if (state.selectedCritiqueId.value === guid.zero()) {
      //   state.composedCritique.value.comments.push(comment)
      // } else {
      //   state.critiques.value[state.selectedCritiqueId.value].comments.push(comment)
      // }
      state.unsavedComments.value.push(comment)
    },
    removeUnsavedComment: (id: string) => {
      state.unsavedComments.value.filter((comment) => comment.id !== id)
    },

    // TODO: Simplify, by using record maybe
    deleteComment: (id: string) => {
      // Remove
      state.critiques.value[state.selectedCritiqueId.value].comments.filter((c) => c.id !== id)

      //Add to removed list
      const selectedCritique = state.critiques.value[state.selectedCritiqueId.value]
      const commentToPush = selectedCritique.comments.find((c) => c.id == id)
      if (commentToPush !== undefined) {
        state.deletedComments.value.push(commentToPush)
      }
    },
  }
}
