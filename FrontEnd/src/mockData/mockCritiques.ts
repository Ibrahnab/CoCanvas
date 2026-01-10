import type { CritiqueDto, CommentDto, ReplyDto } from '@/DTO/critique'
import guid from '@/utils/guid'

const mockCritique: CritiqueDto = {
  id: '00000000-0000-0000-0000-000000000001',
  userId: '00000000-0000-0000-0000-000000000001',
  username: 'Exathy',
  rating: 30,
  description: 'Here are my thoughts on your stuff, overall really good',
  published: true,
  createdAt: '2030-01-01T23:15:33.008Z',
  replies: [
    {
      id: guid.zero(),
      userId: guid.zero(),
      username: 'Blake',
      text: 'no',
      createdAt: '2030-01-01T23:15:33.008Z',
    },
    {
      id: guid.zero(),
      userId: guid.zero(),
      username: 'Exathy',
      text: 'ok, got it',
      createdAt: '2030-01-01T23:15:33.008Z',
    },
    {
      id: guid.zero(),
      userId: guid.zero(),
      username: 'Exathy',
      text: 'ok, got it',
      createdAt: '2030-01-01T23:15:33.008Z',
    },
  ],
  comments: [
    {
      id: guid.zero(),
      x: 50,
      y: 120,
      text: 'Lorem ipsum erdum turpis. Pellentesque scelerisque eu erat eget lobortis. Vivamus eleifend',
      createdAt: '2030-01-01T23:15:33.008Z',
    },
    {
      id: guid.zero(),
      x: 230,
      y: 250,
      text: 'draw a better line',
      createdAt: '2030-01-01T23:15:33.008Z',
    },
  ],
}

const mockCritique2: CritiqueDto = {
  id: '00000000-0000-0000-0000-000000000002',
  userId: '00000000-0000-0000-0000-000000000002',
  username: 'Someone',
  rating: 10,
  description: 'pretty good',
  published: true,
  replies: [],
  createdAt: '2030-01-01T23:15:33.008Z',
  comments: [
    {
      id: guid.zero(),
      x: 30,
      y: 250,
      text: 'sample comment',
      createdAt: '2030-01-01T23:15:33.008Z',
    },
    {
      id: guid.zero(),
      x: 200,
      y: 14,
      text: 'Comment sample',
      createdAt: '2030-01-01T23:15:33.008Z',
    },
    {
      id: guid.zero(),
      x: 200,
      y: 200,
      text: 'third comment',
      createdAt: '2030-01-01T23:15:33.008Z',
    },
  ],
}

export default [mockCritique, mockCritique2]
