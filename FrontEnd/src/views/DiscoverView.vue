<template>
  <div>
    <masonry-wall :items="posts" :ssr-columns="1" :column-width="250" :gap="16">
      <template #default="{ item }">
        <div class="mansory-item">
          <div class="imageContainer">
            <div class="elementContainer">
              <!-- <div class="imageText">Critique</div> -->
              <router-link :to="{ name: 'posts', params: { id: item.postId } }" class="imageText"
                >Critique</router-link
              >
            </div>
            <img class="postimage" :src="baseURL + 'api/Posts/images/' + item.imageUrl" />
          </div>
          <h4 class="title">{{ item.postTitle }}</h4>
        </div>
      </template>
    </masonry-wall>
  </div>
</template>
<script setup lang="ts">
import UserPost from '@/views/UserPostView.vue'
import wide from '@/assets/wide1.png'
import tall from '@/assets/tall1.png'
import batman from '@/assets/batman.png'
import comic from '@/assets/comic1.png'
import long from '@/assets/long.png'
import rkgk1 from '@/assets/rkgk1.png'
import guid from '@/utils/guid'

const items = [
  {
    id: guid.zero(),
    title: 'First',
    image: tall,
  },
  {
    id: guid.zero(),
    title: 'Second',
    image: wide,
  },
  {
    id: guid.zero(),
    title: 'third',
    image: batman,
  },
  {
    id: guid.zero(),
    title: 'third',
    image: long,
  },
  {
    id: guid.zero(),
    title: 'rkgk1',
    image: rkgk1,
  },

  {
    id: guid.zero(),
    title: 'third',
    image: comic,
  },
]

import { ref, onMounted } from 'vue'
import type { DisplayPostDto } from '@/DTO/post'
import { getAxiosInstance, baseURL } from '@/apiCaller'

const posts = ref<DisplayPostDto[]>([])

const apiCaller = getAxiosInstance()

async function getPosts() {
  try {
    const result = await apiCaller.get<DisplayPostDto[]>('/api/Posts')
    // const url = result.data[0].imageUrl.split('\\')
    // console.log(result.data)

    posts.value = result.data
  } catch (error) {
    // TODO: Create user feedback?
    console.error(error)
  }
}

onMounted(async () => {
  await getPosts()
})
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
