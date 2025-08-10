import { createRouter, createWebHistory } from 'vue-router'
import MainLayout from '../views/MainLayout.vue'
import AuthLayout from '../views/AuthLayout.vue'
import DiscoverView from '../views/DiscoverView.vue'
import SignUp from '../components/auth/SignUp.vue'
import LogIn from '../components/auth/LogIn.vue'
import ForgotPassword from '../components/auth/ForgotPassword.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: MainLayout,
      children: [
        {
          path: '/',
          name: 'discover',
          component: DiscoverView,
        },
        {
          path: '/about',
          name: 'about',
          // route level code-splitting
          // this generates a separate chunk (About.[hash].js) for this route
          // which is lazy-loaded when the route is visited.
          component: () => import('../views/AboutView.vue'),
        },
      ],
    },

    {
      path: '/auth',
      name: 'Auth',
      component: AuthLayout,
      children: [
        { path: '', name: 'Log In', component: LogIn },
        { path: '/signup', name: 'Sign Up', component: SignUp },
        { path: '/forgot-password', name: 'Forgot Password', component: ForgotPassword },
      ],
    },
  ],
})

export default router
