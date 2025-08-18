<template>
  <div class="panel-container">
    <h3 class="">Critiques</h3>
    <div class="critiques-container">
      <div class="critique-wrapper" v-for="(critique, critIndex) in critiques" :key="critIndex">
        <div class="user-wrapper">
          <div class="rating-wrapper">
            <font-awesome-icon icon="fa-chevron-up" class="arrow" />
            <span :style="{ padding: '2px' }"> {{ critique.rating }}</span>
            <font-awesome-icon icon="fa-chevron-up" class="arrow fa-rotate-180" />
          </div>
          <avatar-circle :image="tempImage" />
          <h5>{{ critique.username }}</h5>
        </div>

        <div
          class="comment-wrapper"
          v-for="(comment, comIndex) in critique.comments"
          :key="comIndex"
        >
          {{ comment.text }}
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import CritiqueItem from './CritiqueItem.vue'
import { ref, onMounted, onBeforeUnmount, watch } from 'vue'
import type { Critique, Comment, Reply } from '@/models/critique'
import guid from '@/utils/guid'
import { TextBox, AvatarCircle } from '@/components/common'
import type { PropType } from 'vue'
import tempImage from '@/assets/tall1.png'

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
  border-left: solid 2px rgb(173, 173, 173);
  gap: 10px;
  padding: 15px;
  cursor: pointer;
}
.critiques-container {
  display: flex;
  flex-direction: column;
  gap: 15px;
  width: 500px;
  min-height: 300px;
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

.user-wrapper {
  display: flex;
  align-items: center;
  gap: 20px;
}

.rating-wrapper {
  display: flex;
  flex-direction: column;
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
  flex-direction: row;
  background-color: $color-gray-200;
  padding: 10px;
  margin-top: 10px;
  border-radius: 10px;
}
</style>
