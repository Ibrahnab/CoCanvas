<template>
  <div class="user-wrapper">
    <!-- TODO: Maybe make this into a component since it pretty similar in PostBox -->
    <div class="rating-wrapper">
      <font-awesome-icon icon="fa-chevron-up" class="arrow" />
      <h5 class="mb-0">{{ rating }}</h5>
      <font-awesome-icon icon="fa-chevron-up" class="arrow fa-rotate-180" />
    </div>
    <!-- TODO: Add skeleton loading for everything and this image -->
    <!-- TODO: Also dont build the url like this, send the actual url from the backend completely -->
    <avatar-circle :image="baseURL + 'api/Posts/images/' + userImageUrl" />
    <h5>{{ username }}</h5>
  </div>
</template>

<script lang="ts" setup>
import { baseURL } from '@/apiCaller'
import { AvatarCircle } from '@/components/common'

const props = defineProps({
  rateableItemId: {
    type: String,
    default: '',
  },
  userImageUrl: {
    type: String,
    default: '',
  },
  username: {
    type: String,
    default: '',
  },
  createdAt: {
    type: String,
    default: '',
  },
  rating: {
    type: Number,
    default: 0,
  },
  isPost: {
    type: Boolean,
    default: false,
  },
})
</script>

<style scoped lang="scss">
.user-wrapper {
  display: flex;
  align-items: center;
  gap: 20px;
}

.rating-wrapper {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 5px;
}

.arrow {
  padding: 2px;
  border-radius: $radius-md;

  &:hover {
    transition: all 0.25s;
    background-color: $color-gray-200;
  }
}
</style>
