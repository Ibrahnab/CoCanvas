import { defineStore } from 'pinia'

import { useState } from './state'
import { useActions } from './actions'
import { useGetters } from './getters'

export const usePostStore = defineStore('usePostSTore', () => {
  return {
    ...useState(),
    ...useActions(),
    ...useGetters(),
  }
})
