import type { CritiqueDto } from '@/DTO/critique'

export interface PostDto {
  id: string
  userId: string
  title: string
  rating: number
  description: string
  imageUrl: string
  critiques: CritiqueDto[]
  createdAt: string
  tags: string[]
}

export interface CreatePostDto {
  title: string
  description: string
  userId: string
  tags: string[]
}

export interface DisplayPostDto {
  postId: string
  postTitle: string
  imageUrl: string
}
