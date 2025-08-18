<template>
  <div class="panel-container">
    <!-- TODO: Make smaller components out of this structure -->
    <h3 class="">Critiques</h3>
    <div class="critiques-container">
      <div
        class="critique-wrapper"
        v-for="(critique, critIndex) in critiques"
        :key="critIndex"
        :class="{ toggled: selectedCritiqueId === critique.id }"
        @click="setSelected(critique.id)"
      >
        <div class="user-wrapper">
          <div class="rating-wrapper">
            <font-awesome-icon icon="fa-chevron-up" class="arrow" />
            <h5 class="mb-0">{{ critique.rating }}</h5>
            <font-awesome-icon icon="fa-chevron-up" class="arrow fa-rotate-180" />
          </div>
          <avatar-circle :image="tempImage" />
          <h5>{{ critique.username }}</h5>
        </div>

        <div>
          <div
            class="comment-wrapper"
            v-for="(comment, comIndex) in critique.comments"
            :key="comIndex"
          >
            <div class="pb-2">
              {{ comment.text }}
            </div>

            <div v-if="selectedCritiqueId === critique.id">
              <div
                class="reply-wrapper pt-3 pb-3"
                v-for="(reply, replyIndex) in comment.replies"
                :key="replyIndex"
              >
                <avatar-circle class="reply-image" :image="tempImage2" />
                <div class="reply-content-wrapper">
                  <h5>{{ reply.username }}</h5>
                  <div>{{ reply.text }}</div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import CritiqueItem from './CritiqueItem.vue'
import { ref, onMounted, onBeforeUnmount, watch, computed } from 'vue'
import type { Critique, Comment, Reply } from '@/models/critique'
import guid from '@/utils/guid'
import { TextBox, AvatarCircle } from '@/components/common'
import type { PropType } from 'vue'
import tempImage from '@/assets/tall1.png'
import tempImage2 from '@/assets/Comic1.png'

const emit = defineEmits(['selected'])

function setSelected(critiqueId: string) {
  emit('selected', critiqueId)
}

const props = defineProps({
  critiques: {
    type: Object as PropType<Critique[]>,
  },
  selectedCritiqueId: {
    type: String,
  },
})

async function upVote() {}
async function downVote() {}
</script>

<style scope lang="scss">
.panel-container {
  display: flex;
  flex-direction: column;
  border-left: solid 1px rgb(209, 209, 209);
  gap: 10px;
  padding: 20px;
  cursor: pointer;
}
.critiques-container {
  display: flex;
  flex-direction: column;
  gap: 15px;
  width: 500px;
  min-height: 300px;
  transition: all 0.25s;
}

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

.reply-image {
  min-width: 45px;
}
</style>
