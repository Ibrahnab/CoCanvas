<template>
  <div class="canvas-container">
    <!-- TODO: Make a component around this -->
    <div class="tools">
      <!-- TODO: Add selectable colors and width for the pen -->
      <SelectButton
        icon="pen"
        :iconColor="iconColor"
        :toggled="selected === tools.PEN"
        @click="enableDrawingMode"
      />
      <SelectButton
        icon="eraser"
        :iconColor="iconColor"
        :toggled="selected === tools.ERASE"
        @click="eraseMode"
      />
      <SelectButton
        icon="border-none"
        :iconColor="iconColor"
        :toggled="selected === tools.SELECT"
        @click="selectMode"
      />

      <SelectButton
        icon="comment"
        :iconColor="iconColor"
        :toggled="selected === tools.COMMENT"
        @click="commentMode"
      />
    </div>
    <div class="imageContainer">
      <canvas ref="canvasEl"></canvas>

      <CanvasComment
        v-for="(comment, index) in critiques?.find((c) => c.id === selectedCritiqueId)?.comments"
        :key="index"
        :posX="comment.x"
        :posY="comment.y"
        :modelValue="comment.text"
        :ref="comment.id"
        @send="updateComment"
        @delete="deleteComment"
      >
      </CanvasComment>

      <CanvasComment
        v-if="unsavedComment?.id === guid.zero()"
        :posX="unsavedComment.x"
        :posY="unsavedComment.y"
        :modelValue="unsavedComment.text"
        @send="saveComment(unsavedComment)"
        @delete="deleteComment"
      ></CanvasComment>
    </div>
  </div>
</template>

<script setup lang="ts">
import { SelectButton, TextBox } from '@/components/common'
import { ref, onMounted, onBeforeUnmount, watch } from 'vue'
import type { PropType } from 'vue'
import * as fabric from 'fabric'
import { FabricImage, Canvas } from 'fabric'
import type { Critique, Comment, Reply } from '@/models/critique'
import guid from '@/utils/guid'
import CanvasComment from './CanvasComment.vue'
// import mockCritiques from '@/mockData/mockCritiques'

enum tools {
  PEN,
  ERASE,
  SELECT,
  COMMENT,
}

const selected = ref(tools.PEN)
const iconColor = ref('white')
// const critiques = ref<Critique[]>([]) // TODO: Get from backend
// const selectedCritiqueId = ref<string>(guid.zero())
// const selectedCritique = ref<Critique>()
// const myCritique = ref<Critique>()
const expandedCommentId = ref<string>()
const unsavedComment = ref<Comment | null>(null)

const canvasEl = ref<HTMLCanvasElement | null>(null)
let canvas: Canvas

const props = defineProps({
  imageUrl: {
    type: String,
    default: '',
  },
  critiques: {
    type: Object as PropType<Critique[]>,
  },
  myCritique: {
    type: Object as PropType<Critique>,
  },
  selectedCritique: {
    type: Object as PropType<Critique>,
  },
  selectedCritiqueId: {
    type: String,
  },
})

function commentExpand() {}

onMounted(async () => {
  if (!canvasEl.value) return

  // Initialize fabric canvas
  canvas = new Canvas(canvasEl.value, {
    isDrawingMode: false,
    selection: true,
  })

  // Load the image as background
  const img = await FabricImage.fromURL(props.imageUrl, {
    crossOrigin: 'anonymous',
  })

  const scaleFactor = 600 / img.width!
  img.scale(scaleFactor)

  canvas.setDimensions({ width: img.width! * scaleFactor, height: img.height! * scaleFactor })
  canvas.backgroundImage = img
  canvas.requestRenderAll()
  enableDrawingMode()
})

function toolSelect(selectedTool: number) {
  // TODO: Consider this?
  switch (selectedTool) {
    case tools.PEN:
    case tools.COMMENT:
    case tools.ERASE:
    case tools.SELECT:
    default:
  }
}

function enableDrawingMode() {
  selected.value = tools.PEN
  canvas.isDrawingMode = true
  canvas.freeDrawingBrush = new fabric.PencilBrush(canvas)
  canvas.freeDrawingBrush.width = 2
  canvas.freeDrawingBrush.color = '#ff0000'
  console.log(canvas.toJSON())
}

function selectMode() {
  selected.value = tools.SELECT
  disableDrawingMode()
}

function disableDrawingMode() {
  canvas.isDrawingMode = false
}

async function updateComment(comment: Comment) {}

async function saveComment(comment: Comment) {
  //TODO: Emit to parent
  // try {
  //   // const result = await backend.save(comment)
  //   myCritique.value?.comments.push(comment)
  //   console.log(myCritique.value?.comments)
  // } catch (error) {
  //   console.error(error)
  //   // TODO: implement globalmessagebox
  // }
}

function deleteComment() {}

function addCommentMarker(posx: number, posy: number) {
  // if (!unsavedComment.value) {
  //   unsavedComment.value = {
  //     id: guid.zero(),
  //     x: posx,
  //     y: posy,
  //     text: '',
  //     replies: [],
  //   }
  // } else {
  //   unsavedComment.value = null
  // }
}

// TODO: Consider canvas.freeDrawingBrush.decimate = 8; // try 4–10
// For optimization
function saveAnnotations() {
  const data = canvas.toJSON()
  console.log('Annotations:', data)
  // TODO: Send to backend
}

function eraseMode() {
  // TODO: Implement
  selected.value = tools.ERASE
}

// TODO: Do this with html elements instead
function commentMode() {
  selected.value = tools.COMMENT
  disableDrawingMode()
  canvas.selection = false

  canvas.on('mouse:down', (opt) => {
    if (selected.value === tools.COMMENT) {
      const pointer = canvas.getViewportPoint(opt.e)
      addCommentMarker(pointer.x, pointer.y)
    }
  })
}

onBeforeUnmount(() => {
  canvas?.dispose()
})
</script>

<style lang="scss" scoped>
.imageContainer {
  display: inline-block;
  position: relative;
}

.canvas-container {
  width: 100%;
  display: flex;
  justify-content: center;
}

.tools {
  position: fixed;
  bottom: 10px;
  z-index: 1;

  display: flex;
  align-items: end;
  justify-content: center;
  gap: 10px;

  padding: 10px;

  background-color: rgb(73, 73, 73);
  border-radius: $radius-lg;
  box-shadow: 0 2px 20px rgb(0, 0, 0, 0.4);
}
</style>
