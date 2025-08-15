import type { Critique, Comment, Reply } from '@/models/critique'
import guid from '@/utils/guid'

const mockCritique: Critique = {
  id: guid.zero(),
  userId: guid.zero(),
  username: 'username',
  rating: 30,
  comments: [
    {
      id: guid.zero(),
      x: 50,
      y: 50,
      text: 'sample comment',
      replies: [
        {
          id: guid.zero(),
          userId: guid.zero(),
          username: 'someoneElse',
          text: 'sample reply',
        },
      ],
    },
    {
      id: guid.zero(),
      x: 40,
      y: 20,
      text: 'draw a better line',
      replies: [
        {
          id: guid.zero(),
          userId: guid.zero(),
          username: 'someoneElse',
          text: 'no',
        },
      ],
    },
  ],
}

const mockCritique2: Critique = {
  id: guid.zero(),
  userId: guid.zero(),
  username: 'username',
  rating: 30,
  comments: [
    {
      id: guid.zero(),
      x: 30,
      y: 15,
      text: 'sample comment',
      replies: [
        {
          id: guid.zero(),
          userId: guid.zero(),
          username: 'someoneElse',
          text: 'sample repy',
        },
      ],
    },
  ],
}

export default [mockCritique, mockCritique2]
