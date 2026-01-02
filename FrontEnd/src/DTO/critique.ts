export interface CritiqueDto {
  id: string
  userId: string
  username: string
  rating: number
  description: string
  published: boolean
  replies: ReplyDto[]
  comments: CommentDto[]
}

export interface CommentDto {
  id: string
  x: number
  y: number
  text: string
}

export interface ReplyDto {
  id: string
  userId: string
  username: string
  text: string
}
