<script setup lang="ts">
import { ref, onMounted } from 'vue'
import type { WeatherForecast } from '../models/weatherForecast'

defineProps<{
  msg: string
}>()

const data = ref<WeatherForecast[]>([])

const getData = async () => {
  try {
    const response = await fetch('https://localhost:32770/WeatherForecast')

    response.json().then((result) => {
      console.log('data: ', result)
      result.forEach((d: WeatherForecast) => {
        data.value.push(d)
        console.log(d)
      })
    })
  } catch (error) {
    console.error(error)
  }
}

onMounted(async () => {
  await getData()
})
</script>

<template>
  <div class="greetings">
    <h1 class="green">{{ msg }}</h1>
    <h3>
      You’ve successfully created a project with
      <a href="https://vite.dev/" target="_blank" rel="noopener">Vite</a> +
      <a href="https://vuejs.org/" target="_blank" rel="noopener">Vue 3</a>. What's next?
    </h3>
  </div>

  <div v-for="d in data" :key="d.date">
    <div class="row">
      <div class="col">{{ d.date }}</div>
      <div class="col">{{ d.summary }}</div>
      <div class="col">{{ d.temperatureC }}</div>
      <div class="col">{{ d.temperatureF }}</div>
    </div>
  </div>
</template>

<style scoped>
h1 {
  font-weight: 500;
  font-size: 2.6rem;
  position: relative;
  top: -10px;
}

h3 {
  font-size: 1.2rem;
}

.greetings h1,
.greetings h3 {
  text-align: center;
}

@media (min-width: 1024px) {
  .greetings h1,
  .greetings h3 {
    text-align: left;
  }
}
</style>
