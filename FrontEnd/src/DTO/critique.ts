export interface CritiqueDto {
  id: string
  userId: string
  username: string
  rating: number
  description: string
  published: boolean
  replies: ReplyDto[]
  comments: CommentDto[]
  createdAt: string
}

export interface CommentDto {
  id: string
  x: number
  y: number
  text: string
  createdAt: string
}

export interface ReplyDto {
  id: string
  userId: string
  username: string
  createdAt: string
  text: string
}
