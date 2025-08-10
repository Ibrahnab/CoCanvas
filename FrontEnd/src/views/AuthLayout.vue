<template>
  <div class="login-wrapper">
    <transition name="fade">
      <div v-if="visible" class="login-card">
        <div class="header">
          <h3>{{ $route.name }}</h3>
          <hr />
        </div>
        <router-view />
      </div>
    </transition>
  </div>
</template>

<script setup lang="ts">
// import { useRoute } from 'vue-router'
import { onMounted, ref } from 'vue'

const visible = ref(false)

onMounted(() => {
  visible.value = true
})

// const route = useRoute()
</script>

<style scoped lang="scss">
.login-wrapper {
  background: #8d71f5;
  background: linear-gradient(
    90deg,
    rgba(141, 113, 245, 1) 0%,
    rgba(24, 24, 158, 1) 43%,
    rgba(0, 212, 255, 1) 100%
  );
  display: flex;
  height: 100vh;
  justify-content: center;
}
.login-card {
  display: flex;
  justify-content: flex-start;
  flex-direction: column;
  width: 100%;
  max-width: 400px;
  height: 30em;
  padding: $spacing-xl;
  border-radius: $radius-md;
  box-shadow: $elevation-2;
  background-color: white;
  text-align: center;
  margin-top: 30px;
}

.fade-enter-active {
  transition:
    opacity 0.5s ease,
    transform 0.5s ease;
}
.fade-enter-from {
  opacity: 0;
  transform: translateY(10px);
}
.fade-enter-to {
  opacity: 1;
  transform: translateY(0);
}
</style>
