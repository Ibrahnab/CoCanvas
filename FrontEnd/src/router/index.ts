import { createRouter, createWebHistory } from 'vue-router'
import MainLayout from '../views/MainLayout.vue'
import AuthLayout from '../views/AuthLayout.vue'
import DiscoverView from '../views/DiscoverView.vue'
import UserPostView from '../views/UserPostView.vue'
import HomeView from '../views/HomeView.vue'
import CreatePostView from '../views/CreatePostView.vue'
import SignUp from '../components/auth/SignUp.vue'
import LogIn from '../components/auth/LogIn.vue'
import ForgotPassword from '../components/auth/ForgotPassword.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'mainApplication',
      component: MainLayout,
      children: [
        {
          path: '/',
          name: 'discover',
          component: DiscoverView,
        },
        {
          path: '/home',
          name: 'home',
          component: HomeView,
        },
        {
          path: '/create-post',
          name: 'create-post',
          component: CreatePostView,
        },
        {
          path: '/posts/:id',
          name: 'posts',
          component: UserPostView,
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
