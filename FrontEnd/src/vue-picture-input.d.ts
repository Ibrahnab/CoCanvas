// Since vue-picture-input isn't typed, typescript will complain when importing it, this fixes that.
declare module 'vue-picture-input' {
  import { DefineComponent } from 'vue'
  const component: DefineComponent<Record<string, unknown>, Record<string, unknown>, unknown>
  export default component
}
