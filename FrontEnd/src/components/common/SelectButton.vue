<template>
  <div class="ctr" :class="{ 'select-color': toggled }">
    <font-awesome-icon
      class="icon"
      :icon="icon"
      :style="{ fontSize: size + 'px', color: iconColor }"
    />
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'

const props = defineProps({
  icon: {
    type: String,
    default: '',
  },
  selectColor: {
    type: String,
    default: 'white',
  },
  iconColor: {
    type: String,
    default: 'black',
  },
  size: {
    type: Number,
    default: 25,
  },
  toggled: {
    type: Boolean,
    default: false,
  },
})

onMounted(() => {
  console.log(props.toggled)
})
</script>

<style scoped lang="scss">
.ctr {
  padding: 10px;
  border-radius: 10px;
}

.select-color {
  background-color: $color-primary-light;
}

.ctr:hover {
  background-color: $color-gray-600;
  cursor: pointer;
  transition: all 0.25s ease;
}
</style>
