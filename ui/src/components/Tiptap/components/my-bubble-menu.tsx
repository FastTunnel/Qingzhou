import { ToggleGroup, ToggleGroupItem } from "@/components/ui/toggle-group"
import { BubbleMenu, useCurrentEditor } from "@tiptap/react"
import { Bold, Italic, Strikethrough } from "lucide-react"

export function MyBubbleMenu() {
    const { editor } = useCurrentEditor()

    if (!editor) {
        return null
    }

    return (
        <>{
            editor && <BubbleMenu className="rounded-md shadow-md" editor={editor} tippyOptions={{ duration: 0 }}>
                <ToggleGroup type="multiple">
                    <ToggleGroupItem value="bold" aria-label="Toggle bold" data-state={editor.isActive('bold')} onClick={() => editor.chain().focus().toggleBold().run()} className={editor.isActive('bold') ? 'is-active' : ''}>
                        <Bold className="h-3 w-3" />
                    </ToggleGroupItem>
                    <ToggleGroupItem value="italic" aria-label="Toggle italic" data-state={editor.isActive('italic')} onClick={() => editor.chain().focus().toggleItalic().run()} className={editor.isActive('italic') ? 'is-active' : ''}>
                        <Italic className="h-3 w-3" />
                    </ToggleGroupItem>
                    <ToggleGroupItem value="underline" aria-label="Toggle underline" data-state={editor.isActive('strike')} onClick={() => editor.chain().focus().toggleStrike().run()} className={editor.isActive('strike') ? 'is-active' : ''}>
                        <Strikethrough className="h-3 w-3" />
                    </ToggleGroupItem>
                </ToggleGroup>
            </BubbleMenu >
        }
        </>
    )
}