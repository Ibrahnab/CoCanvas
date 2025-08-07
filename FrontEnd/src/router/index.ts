import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import LoginView from '../views/LoginView.vue'
import SignUp from '../components/auth/SignUp.vue'
import LogIn from '../components/auth/LogIn.vue'
import ForgotPassword from '../components/auth/ForgotPassword.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/home',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue'),
    },
    {
      path: '/',
      name: 'Auth',
      component: LoginView,
      children: [
        { path: '', name: 'Log In', component: LogIn },
        { path: '/signup', name: 'Sign Up', component: SignUp },
        { path: '/forgot-password', name: 'Forgot Password', component: ForgotPassword },
      ],
    },
  ],
})

export default router
