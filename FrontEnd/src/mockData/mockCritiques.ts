import type { CritiqueDto, CommentDto, ReplyDto } from '@/DTO/critique'
import guid from '@/utils/guid'

const mockCritique: CritiqueDto = {
  id: guid.zero(),
  userId: guid.zero(),
  username: 'Exathy',
  rating: 30,
  description: 'Here are my thoughts on your stuff, overall really good',
  published: true,
  replies: [
    {
      id: guid.zero(),
      userId: guid.zero(),
      username: 'Blake',
      text: 'no',
    },
    {
      id: guid.zero(),
      userId: guid.zero(),
      username: 'Exathy',
      text: 'ok, got it',
    },
  ],
  comments: [
    {
      id: guid.zero(),
      x: 50,
      y: 120,
      text: 'Lorem ipsum erdum turpis. Pellentesque scelerisque eu erat eget lobortis. Vivamus eleifend',
    },
    {
      id: guid.zero(),
      x: 230,
      y: 250,
      text: 'draw a better line',
    },
  ],
}

const mockCritique2: CritiqueDto = {
  id: '00000000-0000-0000-0000-000000000001',
  userId: '00000000-0000-0000-0000-000000000001',
  username: 'Someone',
  rating: 10,
  description: 'pretty good',
  published: true,
  replies: [],
  comments: [
    {
      id: guid.zero(),
      x: 30,
      y: 250,
      text: 'sample comment',
    },
    {
      id: guid.zero(),
      x: 200,
      y: 14,
      text: 'Comment sample',
    },
    {
      id: guid.zero(),
      x: 200,
      y: 200,
      text: 'third comment',
    },
  ],
}

export default [mockCritique, mockCritique2]
