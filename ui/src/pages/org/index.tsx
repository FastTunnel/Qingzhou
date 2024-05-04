import { LinkInfo, Nav } from "@/components/nav/nav";
import { ArchiveX, Inbox, Send, Trash2, Archive, File } from "lucide-react";
import PageWithNav from "@/layout/page-with-nav";
import { memo } from "react";

function Content() {
    return <div>事项</div>;
}

const Org = memo(() => {
    const links: LinkInfo[] =
        [
            {
                title: "组织基本信息",
                label: "128",
                icon: Inbox,
            },
            {
                title: "成员管理",
                label: "9",
                icon: File,
            },
            {
                title: "权限管理",
                label: "",
                icon: Send,
            }
        ];

    return <>
        <PageWithNav links={links} Content={<Content></Content>}></PageWithNav>
    </>
})

export default Org;