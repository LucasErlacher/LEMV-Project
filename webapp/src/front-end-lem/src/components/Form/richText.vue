<template>
  <span class="text-lg font-medium text-gray-600">{{ label }}</span>
  <editor-content :editor="editor" />
</template>

<script>
import { Editor, EditorContent } from '@tiptap/vue-3'
import StarterKit from '@tiptap/starter-kit'

export default {
  props: {
    label: {
      type: String,
      default: ''
    },
    modelValue: {
      default: ''
    }
  },
  components: {
    EditorContent
  },

  data () {
    return {
      editor: null
    }
  },

  mounted () {
    this.editor = new Editor({
      editorProps: {
        attributes: {
          class: 'field w-full bg-gray-100 bg-opacity-50 rounded border border-gray-300 focus:border-green-500 focus:bg-white focus:ring-2 focus:ring-green-200 text-base outline-none text-gray-700 py-1 px-3 leading-8 transition-colors duration-200 ease-in-out'
        }
      },
      content: '',
      extensions: [
        StarterKit
      ]
    })
  },

  beforeUnmount () {
    this.editor.destroy()
  }
}
</script>

prose prose-sm sm:prose lg:prose-lg xl:prose-2xl m-5 focus:outline-none
