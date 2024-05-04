import { Nav } from "@/components/nav/nav";
import { ArchiveX, Inbox, Send, Trash2, Archive, File } from "lucide-react";

export function Issues() {
    return <>
        <div className="flex   flex-row  h-full">
            <aside className="lg:w-52 h-full">
                <Nav isCollapsed={false}
                    links={[
                        {
                            title: "Inbox",
                            label: "128",
                            icon: Inbox,
                        },
                        {
                            title: "Drafts",
                            label: "9",
                            icon: File,
                        },
                        {
                            title: "Sent",
                            label: "",
                            icon: Send,
                        },
                        {
                            title: "Junk",
                            label: "23",
                            icon: ArchiveX,
                        },
                        {
                            title: "Trash",
                            label: "",
                            icon: Trash2,
                        },
                        {
                            title: "Archive",
                            label: "",
                            icon: Archive,
                        },
                    ]} />
            </aside>
            <div className="flex-1"> <div>事项</div></div>
        </div>
    </>
} 
