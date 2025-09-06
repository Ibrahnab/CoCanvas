import type { Critique } from './critique'

export interface Post {
  postId: string
  postTitle: string
  description: string
  imageUrl: string
  Critiques: Critique[]
}

export interface DisplayPost {
  postId: string
  postTitle: string
  imageUrl: string
}
