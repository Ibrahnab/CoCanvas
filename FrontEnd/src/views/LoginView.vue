<template>
  <div class="login-wrapper">
    <div class="login-card">
      <div class="header">
        <h3>{{ $route.name }}</h3>
        <hr />
      </div>
      <router-view />
    </div>
  </div>
</template>

<script setup lang="ts">
// import { useRoute } from 'vue-router'

// const route = useRoute()
</script>

<style scoped lang="scss">
.login-wrapper {
  display: flex;
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
}
</style>
