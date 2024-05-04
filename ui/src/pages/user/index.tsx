import { LinkInfo } from "@/components/nav/nav";
import PageWithNav from "@/layout/page-with-nav";
import { Inbox, Send, File } from "lucide-react";

function Content() {
    return <div>事项</div>;
}

export function User() {
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
} 
