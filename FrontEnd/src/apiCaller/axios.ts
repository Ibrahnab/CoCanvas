import axios from 'axios'
import type { AxiosInstance } from 'axios'

let axiosInstance: AxiosInstance | null = null

const getAxiosInstance = (): AxiosInstance => {
  if (!axiosInstance) {
    throw new Error('Axios instance not initialized')
  }
  return axiosInstance
}

const initialize = () => {
  axiosInstance = axios.create({
    // TODO: Dynamically set this based on env variable checking prod or dev
    baseURL: 'https://localhost:44300/',
  })

  axiosInstance.interceptors.request.use(
    (config) => {
      const token = localStorage.getItem('accessToken')

      if (token) {
        config.headers.Authorization = `Bearer ${token}`
      }

      return config
    },
    (error) => {
      return Promise.reject(error)
    },
  )
}

export { getAxiosInstance, initialize }
