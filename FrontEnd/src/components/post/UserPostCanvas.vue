<template>
  <canvas ref="canvasEl"></canvas>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { Canvas, PencilBrush, FabricImage } from 'fabric'

const canvasEl = ref<HTMLCanvasElement | null>(null)

onMounted(async () => {
  if (!canvasEl.value) return

  // Create Fabric canvas
  const canvas = new Canvas(canvasEl.value, {
    isDrawingMode: true, // enable freehand drawing
    width: 800,
    height: 600,
  })

  // Set up free drawing brush
  const brush = new PencilBrush(canvas)
  brush.width = 2
  brush.color = 'red'
  canvas.freeDrawingBrush = brush

  // // Load background image
  // const img = await FabricImage.fromURL('/uploads/sample-image.jpg', {
  //   crossOrigin: 'anonymous', // if needed for CORS
  // })
  // img.selectable = false

  // // Scale image to canvas
  // img.scaleToWidth(canvas.getWidth()!)
  // img.scaleToHeight(canvas.getHeight()!)
  // canvas.setBackgroundImage(img, canvas.renderAll.bind(canvas))
})
</script>

<style>
canvas {
  border: 1px solid #ccc;
}
</style>
