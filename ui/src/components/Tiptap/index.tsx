import './styles.css'

import { Color } from '@tiptap/extension-color'
import ListItem from '@tiptap/extension-list-item'
import TextStyle from '@tiptap/extension-text-style'
import { BubbleMenu, EditorContent, EditorProvider, FloatingMenu } from '@tiptap/react'
import StarterKit from '@tiptap/starter-kit'
import Image from '@tiptap/extension-image'
import FileHandler from '@tiptap-pro/extension-file-handler'
import { useCurrentEditor } from '@tiptap/react'

import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList, CommandSeparator, CommandShortcut } from '../ui/command'
import { MyBubbleMenu } from './components/my-bubble-menu'
import { MyFloatingMenu } from './components/my-floating-menu'
import MyMenuBar from './components/my-menu-bar'

const extensions = [
  Color.configure({ types: [TextStyle.name, ListItem.name] }),
  TextStyle.configure({ types: [ListItem.name] }),
  StarterKit.configure({
    bulletList: {
      keepMarks: true,
      keepAttributes: false, // TODO : Making this as `false` becase marks are not preserved when I try to preserve attrs, awaiting a bit of help
    },
    orderedList: {
      keepMarks: true,
      keepAttributes: false, // TODO : Making this as `false` becase marks are not preserved when I try to preserve attrs, awaiting a bit of help
    },

  }),
  Image,

  FileHandler.configure({
    onPaste: (editor, files, htmlContent) => {
      alert(files[0].name);
      // do something with the files
      // and insert the file into the editor

      // in some cases (for example copy / pasted gifs from other apps) you should probably not use the file directly
      // as the file parser will only have a single gif frame as png
      // in this case, you can extract the url from the htmlContent and use it instead, let other inputRules handle insertion
      // or do anything else with the htmlContent pasted into here
    },
  })
]

const content = `
<h2>
  Hi there,
</h2>
<p>
  this is a <em>basic</em> example of <strong>tiptap</strong>. Sure, there are all kind of basic text styles you’d probably expect from a text editor. But wait until you see the lists:
</p>
<ul>
  <li>
    That’s a bullet list with one …
  </li>
  <li>
    … or two list items.
  </li>
</ul>
<p>
  Isn’t that great? And all of that is editable. But wait, there’s more. Let’s try a code block:
</p>
<pre><code class="language-css">body {
display: none;
}</code></pre>
<p>
  I know, I know, this is impressive. It’s only the tip of the iceberg though. Give it a try and click a little bit around. Don’t forget to check the other examples too.
</p>
<blockquote>
  Wow, that’s amazing. Good work, boy! 👏
  <br />
  — Mom
</blockquote>
`

export function Tiptap() {
  return (
    <EditorProvider
      slotBefore={<MyMenuBar />}
      extensions={extensions}
      content={content}>
      <MyFloatingMenu></MyFloatingMenu>
      <MyBubbleMenu></MyBubbleMenu>
    </EditorProvider>
  )
}