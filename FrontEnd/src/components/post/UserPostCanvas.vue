<template>
  <div class="image-annotator">
    <canvas ref="canvasEl"></canvas>
    <div class="tools">
      <button @click="enableDrawingMode">Draw Mode</button>
      <button @click="disableDrawingMode">Select Mode</button>
      <button @click="saveAnnotations">Save</button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, onBeforeUnmount } from 'vue'
import * as fabric from 'fabric'
import { FabricImage, Canvas } from 'fabric'

const props = defineProps<{
  imageUrl: string
}>()

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

  canvas.on('mouse:down', (opt) => {
    const pointer = canvas.getViewportPoint(opt.e)
    addCommentMarker(pointer.x, pointer.y)
  })
})

onBeforeUnmount(() => {
  canvas?.dispose()
})

function enableDrawingMode() {
  canvas.isDrawingMode = true
  canvas.freeDrawingBrush = new fabric.PencilBrush(canvas)
  canvas.freeDrawingBrush.width = 3
  canvas.freeDrawingBrush.color = '#ff0000'
}

function disableDrawingMode() {
  canvas.isDrawingMode = false
}

function addCommentMarker(x: number, y: number) {
  const circle = new fabric.Circle({
    radius: 6,
    fill: 'yellow',
    stroke: 'black',
    strokeWidth: 1,
    left: x - 6,
    top: y - 6,
    selectable: false,
  })
  canvas.add(circle)

  // TODO: open a modal or popup for user to type a comment
  // Then save { x, y, text } to your backend
}

function saveAnnotations() {
  const data = canvas.toJSON()
  console.log('Annotations:', data)
  // TODO: Send to backend
}
</script>

<style>
.image-annotator {
  display: inline-block;
}

.tools {
  margin-top: 10px;
}
</style>
