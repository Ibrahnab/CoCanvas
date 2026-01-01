export interface Critique {
  id: string
  userId: string
  username: string
  rating: number
  description: string
  published: boolean
  replies: Reply[]
  comments: Comment[]
}

export interface Comment {
  id: string
  x: number
  y: number
  text: string
  replies: Reply[]
}

export interface Reply {
  id: string
  userId: string
  username: string
  text: string
}
