import { Command, CommandGroup, CommandItem, CommandList, CommandSeparator } from "@/components/ui/command"
import { FloatingMenu, useCurrentEditor } from "@tiptap/react"
import {
    Calculator,
    Calendar,
    Code2,
    CreditCard,
    Heading1,
    Heading2,
    Heading3,
    Heading4,
    List,
    ListOrdered,
    Minus,
    Settings,
    Smile,
    TextQuote,
    User,
} from "lucide-react"

export function MyFloatingMenu() {
    const { editor } = useCurrentEditor()

    if (!editor) {
        return null
    }

    return (
        <>
            {editor && <FloatingMenu editor={editor} tippyOptions={{
                placement: "auto-start",
                duration: 100,
            }}>
                <Command className="rounded-lg border shadow-md">
                    <CommandList>
                        <CommandGroup heading="基础">
                            <CommandItem onSelect={() => editor.chain().focus().toggleHeading({ level: 1 }).run()} >
                                <Heading1 className="mr-2 h-4 w-4" />
                                <span>标题1</span>
                            </CommandItem>
                            <CommandItem onSelect={() => editor.chain().focus().toggleHeading({ level: 2 }).run()} >
                                <Heading2 className="mr-2 h-4 w-4" />
                                <span>标题2</span>
                            </CommandItem>
                            <CommandItem onSelect={() => editor.chain().focus().toggleHeading({ level: 3 }).run()} >
                                <Heading3 className="mr-2 h-4 w-4" />
                                <span>标题3</span>
                            </CommandItem>
                            <CommandItem onSelect={() => editor.chain().focus().toggleHeading({ level: 4 }).run()} >
                                <Heading4 className="mr-2 h-4 w-4" />
                                <span>标题4</span>
                            </CommandItem>
                            <CommandItem onSelect={() => editor.chain().focus().toggleBulletList().run()} >
                                <List className="mr-2 h-4 w-4" />
                                <span>无序列表</span>
                            </CommandItem>
                            <CommandItem onSelect={() => editor.chain().focus().toggleOrderedList().run()} >
                                <ListOrdered className="mr-2 h-4 w-4" />
                                <span>有序列表</span>
                            </CommandItem>
                            <CommandItem onSelect={() => editor.chain().focus().toggleCodeBlock().run()} >
                                <Code2 className="mr-2 h-4 w-4" />
                                <span>代码块</span>
                            </CommandItem>
                            <CommandItem onSelect={() => editor.chain().focus().toggleBlockquote().run()} >
                                <TextQuote className="mr-2 h-4 w-4" />
                                <span>引用</span>
                            </CommandItem>
                            <CommandItem onSelect={() => editor.chain().focus().setHorizontalRule().run()} >
                                <Minus className="mr-2 h-4 w-4" />
                                <span>分割线</span>
                            </CommandItem>
                        </CommandGroup>
                        <CommandSeparator />
                    </CommandList>
                </Command>
            </FloatingMenu>}
        </>
    )
}

