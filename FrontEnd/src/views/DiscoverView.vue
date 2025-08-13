<template>
  <div>
    <masonry-wall :items="items" :ssr-columns="1" :column-width="250" :gap="16">
      <template #default="{ item, index }">
        <div class="mansory-item">
          <div class="imageContainer">
            <div class="elementContainer">
              <div class="imageText">Critique</div>
            </div>
            <img class="postimage" :src="item.image" />
          </div>
          <h4 class="title">Title {{ index }}</h4>
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
import guid from '@/utils/guid'

const items = [
  {
    id: guid.zero,
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
</script>

<style scoped lang="scss">
.imageContainer {
  position: relative;
}
.elementContainer {
  display: flex;
  align-items: center;
  position: absolute;
  justify-content: center;
  width: 100%;
  height: 100%;
  border-radius: 20px;
  opacity: 0%;
}

.elementContainer:hover {
  background-color: rgb(0, 0, 0, 0.6);
  opacity: 100%;
  transition: all 0.25s ease;
  cursor: pointer;
}

.imageText {
  color: white;
  font-weight: $font-weight-bold;
}

.postimage {
  border-radius: 20px;
  display: block;
  object-fit: cover;
  width: 100%;
  height: auto;
}

.title {
  margin-top: 10px;
  margin-bottom: 0px;
}
</style>
