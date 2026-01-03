<template>
  <div
    v-if="critique"
    class="critique-wrapper"
    :class="{ toggled: selectedCritiqueId === critique.id }"
  >
    <div class="user-wrapper">
      <div class="rating-wrapper">
        <font-awesome-icon icon="fa-chevron-up" class="arrow" />
        <h5 class="mb-0">{{ critique.rating }}</h5>
        <font-awesome-icon icon="fa-chevron-up" class="arrow fa-rotate-180" />
      </div>
      <!-- TODO: Add skeleton loading for everything and this image -->
      <avatar-circle :image="userImage" />
      <h5>{{ critique.username }}</h5>
    </div>

    <div>
      <div class="comment-wrapper" v-for="(comment, comIndex) in critique.comments" :key="comIndex">
        <div class="pb-2" @click="setSelected(critique.id)">
          {{ comment.text }}
        </div>
      </div>

      <div class="mt-3" v-if="selectedCritiqueId === critique.id">
        <div v-for="(reply, replyIndex) in critique.replies" :key="replyIndex">
          <UserReply :reply="reply" :image-url="'TODO: Add url to reply dto'" />
        </div>
        <div class="replytools-container">
          <TextBox :placeholder="'Add a reply'" />
          <SpinnerButton class="reply-button"> Reply </SpinnerButton>
        </div>
      </div>
      <div class="bottom" @click="setSelected(critique.id)">
        <font-awesome-icon
          :icon="selectedCritiqueId === critique.id ? 'fa-chevron-up' : 'fa-chevron-down'"
        />
      </div>
    </div>
  </div>
</template>
<script setup lang="ts">
import type { CritiqueDto } from '@/DTO/critique'
import type { PropType } from 'vue'
import { watch, onMounted, ref } from 'vue'
import { getAxiosInstance } from '@/apiCaller'
import UserReply from '@/components/post/UserReply.vue'
import { TextBox, AvatarCircle, SpinnerButton } from '@/components/common'

const axios = getAxiosInstance()
const userImage = ref<string>()

const emit = defineEmits(['selected'])

const props = defineProps({
  critique: {
    type: Object as PropType<CritiqueDto>,
  },
  selectedCritiqueId: {
    type: String,
    default: '',
  },
})

async function loadData() {
  try {
    // TODO: Load User Profile images, use a default one for now
    const result = await axios.get<Blob>('api/Posts/images/defaultProfilePicture.jpg', {
      responseType: 'blob',
    })
    console.log('loading data', result)
    userImage.value = URL.createObjectURL(result.data)
  } catch (error) {
    // TODO: Visualise
    console.error(error)
  }
}

onMounted(() => {
  loadData()
})

watch(
  () => props.critique,
  (newValue) => {
    if (newValue) {
      loadData()
    }
  },
)

// TODO: Create a pinia store since this is going 2 layers up now
// And use the store for other stuff in this Post view
function setSelected(id: string) {
  console.log('selected id: ', id)
  if (props.selectedCritiqueId === props.critique?.id) {
    emit('selected', '')
    return
  }
  emit('selected', id)
}
</script>

<style scoped lang="scss">
.critique-wrapper {
  padding: 10px;
  border-radius: $radius-md;
  box-shadow: 0 0 10px rgb(0, 0, 0, 0.3);

  &:hover {
    transition: all 0.5s ease;
    box-shadow: 0 0 10px rgba(94, 58, 255, 0.3);
  }
}

.toggled {
  box-shadow: 0 0 10px rgba(94, 58, 255, 0.3);
}

.replytools-container {
  display: flex;
  flex-direction: row;
  gap: 10px;
  align-items: center;
}

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

.comment-wrapper {
  display: flex;
  flex-direction: column;
  background-color: $color-gray-200;
  padding: 10px;
  margin-top: 10px;
  border-radius: 10px;
}

.reply-wrapper {
  display: flex;
  flex-direction: row;
  border-top: solid 1px rgb(201, 201, 201);

  gap: 10px;
}
.reply-content-wrapper {
  display: flex;
  flex-direction: column;
}

.reply-button {
  float: inline-end;
}

.reply-image {
  min-width: 45px;
}

.bottom {
  display: fleX;
  margin-top: 10px;
  justify-content: center;
  padding: 10px;
  gap: 10px;
  &:hover {
    background-color: $color-gray-100;
  }
}
</style>
