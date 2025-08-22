import type { Critique } from '@/models/critique'

export interface PostDto {
  id: string
  userId: string
  title: string
  description: string
  imageUrl: string
}
