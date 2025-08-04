import { defineStore } from 'pinia'

import { useState } from './state'
import { useActions } from './actions'
import { useGetters } from './getters'

export const useUserStore = defineStore('userStore', () => {
  return {
    ...useState,
    ...useActions,
    ...useGetters,
  }
})
