<template>
  <div>
    <div class="upper"></div>
    <div class="left"></div>
    <div class="content">
      <slot />
    </div>
  </div>
</template>

<script setup lang="ts"></script>

<style scoped lang="scss">
.upper {
  background-color: $color-gray-300;
  height: 65px;
  position: fixed;
  width: 100%;
}

.left {
  background-color: white;
  border-right: solid gray 1px;
  height: 100%;
  position: fixed;
  width: 65px;
}

.content {
  padding-top: 80px;
  padding-left: 80px;
}
</style>
