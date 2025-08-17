import 'bootstrap/dist/css/bootstrap.min.css'
import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import * as api from './apiCaller'
import MasonryWall from '@yeger/vue-masonry-wall'

import App from './App.vue'
import router from './router'

import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

// TODO: Do this somewhere else to keep this file short
import { faHeart as faHeartSolid } from '@fortawesome/free-solid-svg-icons'
import { faHeart as faHeartRegular } from '@fortawesome/free-regular-svg-icons'
import { faHouse as faHouseSolid } from '@fortawesome/free-solid-svg-icons'
import { faHouse as faHouseRegular } from '@fortawesome/free-regular-svg-icons'
import { faCompass as faCompassSolid } from '@fortawesome/free-solid-svg-icons'
import { faCompass as faCompassRegular } from '@fortawesome/free-regular-svg-icons'
import { faBell as faBellSolid } from '@fortawesome/free-solid-svg-icons'
import { faBell as faBellRegular } from '@fortawesome/free-regular-svg-icons'
import { faSquarePlus as faSquarePlusSolid } from '@fortawesome/free-solid-svg-icons'
import { faSquarePlus as faSquarePlusRegular } from '@fortawesome/free-regular-svg-icons'
import { faMagnifyingGlass as faMagnifyingGlassSolid } from '@fortawesome/free-solid-svg-icons'

import {
  faEraser,
  faBorderNone,
  faComment,
  faPen,
  faPaperPlane,
  faTrash,
} from '@fortawesome/free-solid-svg-icons'

library.add(
  faHeartSolid,
  faHeartRegular,
  faHouseSolid,
  faHouseRegular,
  faCompassSolid,
  faCompassRegular,
  faBellSolid,
  faBellRegular,
  faSquarePlusSolid,
  faSquarePlusRegular,
  faMagnifyingGlassSolid,
  faEraser,
  faBorderNone,
  faComment,
  faPen,
  faPaperPlane,
  faTrash,
)

import './styles/main.scss'

await api.initialize()

const app = createApp(App)

app.component('font-awesome-icon', FontAwesomeIcon)

app.use(createPinia())
app.use(router)
app.use(MasonryWall)
// app.use(PictureInput)

app.mount('#app')
