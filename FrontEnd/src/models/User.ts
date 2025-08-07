import type { AxiosResponse } from 'axios'

export interface UserResponse extends AxiosResponse {
  id: string
  email: string
  userName: string
}
