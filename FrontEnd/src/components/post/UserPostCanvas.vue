<template>
  <div class="ctr">
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
    <div class="image-annotator">
      <canvas ref="canvasEl"></canvas>
    </div>
  </div>
</template>

<script setup lang="ts">
import { SelectButton } from '@/components/common'
import { ref, onMounted, onBeforeUnmount, watch } from 'vue'
import * as fabric from 'fabric'
import { FabricImage, Canvas } from 'fabric'

const props = defineProps({
  imageUrl: {
    type: String,
    default: '',
  },
})

enum tools {
  PEN,
  ERASE,
  SELECT,
  COMMENT,
}
const selected = ref(tools.PEN)
const iconColor = ref('white')

const canvasEl = ref<HTMLCanvasElement | null>(null)
let canvas: Canvas

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
})

function enableDrawingMode() {
  selected.value = tools.PEN
  canvas.isDrawingMode = true
  canvas.freeDrawingBrush = new fabric.PencilBrush(canvas)
  canvas.freeDrawingBrush.width = 2
  canvas.freeDrawingBrush.color = '#ff0000'
}

function selectMode() {
  selected.value = tools.SELECT
  disableDrawingMode()
}

function disableDrawingMode() {
  canvas.isDrawingMode = false
}

function addCommentMarker(x: number, y: number) {
  const radius = 12
  const circle = new fabric.Circle({
    radius: radius,
    fill: 'yellow',
    strokeWidth: 1,
    left: x - radius,
    top: y - radius,
    selectable: false,
  })
  canvas.add(circle)

  // TODO: open a modal or popup for user to type a comment
  // Then save { x, y, text } to backend
}

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
.image-annotator {
  display: inline-block;
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
  box-shadow: 0 2px 10px rgb(160, 160, 160);
}
</style>
