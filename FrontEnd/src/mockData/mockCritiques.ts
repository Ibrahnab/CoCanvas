import type { Critique, Comment, Reply } from '@/models/critique'
import guid from '@/utils/guid'

const mockCritique: Critique = {
  id: guid.zero(),
  userId: guid.zero(),
  username: 'Exathy',
  rating: 30,
  comments: [
    {
      id: guid.zero(),
      x: 50,
      y: 120,
      text: 'Lorem ipsum erdum turpis. Pellentesque scelerisque eu erat eget lobortis. Vivamus eleifend',
      replies: [
        {
          id: guid.zero(),
          userId: guid.zero(),
          username: 'someoneElse',
          text: 'Lorem ipsum erdum turpis. Pellentesque scelerisque eu erat eget lobortis. Vivamus eleifend velit at eros laoreet, non viverra nulla sollicitudin. Sed tincidunt non nunc ut finibus. Nulla consequat id nunc eu ultrices. Donec at velit quam. Phasellus libero lorem, pharetra sit amet leo nec, auctor auctor quam. Vivamus lore',
        },
      ],
    },
    {
      id: guid.zero(),
      x: 230,
      y: 250,
      text: 'draw a better line',
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
    },
  ],
}

const mockCritique2: Critique = {
  id: '00000000-0000-0000-0000-000000000001',
  userId: '00000000-0000-0000-0000-000000000001',
  username: 'Someone',
  rating: 10,
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
    {
      id: guid.zero(),
      x: 200,
      y: 14,
      text: 'Comment with no replies',
      replies: [],
    },
  ],
}

export default [mockCritique, mockCritique2]
