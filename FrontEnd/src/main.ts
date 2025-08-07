import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import * as api from './apiCaller'

import App from './App.vue'
import router from './router'

import './styles/main.scss'

await api.initialize()

const app = createApp(App)

app.use(createPinia())
app.use(router)

app.mount('#app')
