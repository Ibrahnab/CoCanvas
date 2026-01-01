import type { Critique, Comment, Reply } from '@/models/critique'
import guid from '@/utils/guid'

const mockCritique: Critique = {
  id: guid.zero(),
  userId: guid.zero(),
  username: 'Exathy',
  rating: 30,
  description: 'Here are my thoughts on your stuff, overall really good',
  canvasJson: '',
  published: true,
  replies: [
    {
      id: guid.zero(),
      userId: guid.zero(),
      username: 'Adam',
      text: 'Agreed with most of your points, good feedback',
    },
  ],
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
  description: 'pretty good',
  published: true,
  replies: [],
  canvasJson: '',
  comments: [
    {
      id: guid.zero(),
      x: 30,
      y: 250,
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
    {
      id: guid.zero(),
      x: 200,
      y: 200,
      text: 'third comment',
      replies: [],
    },
  ],
}

export default [mockCritique, mockCritique2]
