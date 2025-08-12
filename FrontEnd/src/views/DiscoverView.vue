<template>
  <div>
    <masonry-wall :items="items" :ssr-columns="1" :column-width="250" :gap="16">
      <template #default="{ item, index }">
        <div class="mansory-item">
          <img class="postimage" :src="item.image" />
          <h4>Title {{ index }}</h4>
        </div>
      </template>
    </masonry-wall>
  </div>
</template>
<script setup lang="ts">
import UserPost from '@/components/post/UserPost.vue'
import wide from '@/assets/wide1.png'
import tall from '@/assets/tall1.png'
import batman from '@/assets/batman.png'
import comic from '@/assets/comic1.png'
import long from '@/assets/long.png'

const items = [
  {
    title: 'First',
    image: tall,
  },
  {
    title: 'Second',
    image: wide,
  },
  {
    title: 'third',
    image: batman,
  },
  {
    title: 'third',
    image: long,
  },

  {
    title: 'third',
    image: comic,
  },
  {
    title: 'First',
    image: tall,
  },
]

console.log(comic)
</script>

<style scoped lang="scss">
.mansory-image {
  height: 200px;
}

.mansory-item {
}
.postimage {
  border-radius: 20px;
  display: block;
  object-fit: cover;
  width: 100%;
  height: auto;
}
</style>
