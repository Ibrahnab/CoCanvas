<template>
  <!-- TODO: Add skeletonloading -->
  <div
    v-if="critique"
    class="critique-wrapper"
    :class="{ toggled: selectedCritiqueId === critiqueId }"
  >
    <!-- TODO: Add slots to the below with options -->
    <RateableUserHeader
      :rateable-item-id="critiqueId"
      :user-image-url="'defaultProfilePicture.jpg'"
      :username="critique.username"
      :created-at="critique.createdAt"
      :rating="critique.rating"
    ></RateableUserHeader>

    <div class="p-3">
      {{ critique.description }}
    </div>

    <div>
      <div class="comment-wrapper" v-for="(comment, comIndex) in comments" :key="comIndex">
        <div class="pb-2" @click="setSelected(critiqueId)">
          {{ comment.text }}
        </div>
      </div>

      <div class="mt-3">
        <div class="replytools-container mb-3">
          <TextBox :placeholder="'Add a reply'" />
          <SpinnerButton class="reply-button"> Reply </SpinnerButton>
        </div>
        <div v-for="(reply, replyIndex) in visibleReplies" :key="replyIndex">
          <UserReply :reply="reply" :image-url="'TODO: Add url to reply dto'" />
        </div>
      </div>
      <div class="bottom" @click="toggleCritique()">
        <font-awesome-icon :icon="isExpanded ? 'fa-chevron-up' : 'fa-chevron-down'" />
      </div>
    </div>
  </div>
</template>
<script setup lang="ts">
import type { CritiqueDto } from '@/DTO/critique'
import type { PropType } from 'vue'
import { watch, onMounted, ref, computed } from 'vue'
import { getAxiosInstance } from '@/apiCaller'
import UserReply from '@/components/post/UserReply.vue'
import RateableUserHeader from '@/components/post/RateableUserHeader.vue'
import { TextBox, AvatarCircle, SpinnerButton } from '@/components/common'
import { usePostStore } from '@/stores'
import { storeToRefs } from 'pinia'

const axios = getAxiosInstance()
const postStore = usePostStore()
const userImage = ref<string>()

const emit = defineEmits(['selected'])

const props = defineProps({
  // critique: {
  //   type: Object as PropType<CritiqueDto>,
  //   required: true,
  // },
  // selectedCritiqueId: {
  //   type: String,
  //   default: '',
  // },
  critiqueId: {
    type: String,
    required: true,
  },
})

const comments = postStore.getAllComments(props.critiqueId)
const critique = postStore.getCritique(props.critiqueId)

const isExpanded = ref(false)

// TODO: Instead of binary, expand more until reached the end?
const visibleReplies = computed(() => {
  return isExpanded.value ? critique.value.replies : critique.value.replies.slice(0, 2)
})

const { selectedCritiqueId } = storeToRefs(postStore)
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

function toggleCritique() {
  isExpanded.value = !isExpanded.value
}

onMounted(() => {
  // loadData()
})

// watch(
//   () => critique,
//   (newValue) => {
//     if (newValue) {
//       // loadData()
//       console.log(newValue)
//     }
//   },
// )

// watch(comments, (newValue) => {
//   console.log('new state value: ', newValue)
// })

// TODO: Create a pinia store since this is going 2 layers up now
// And use the store for other stuff in this Post view
function setSelected(id: string) {
  console.log('selected id: ', id)
  if (selectedCritiqueId.value === props.critiqueId) {
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
  border-bottom: solid 1px rgb(201, 201, 201);

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
