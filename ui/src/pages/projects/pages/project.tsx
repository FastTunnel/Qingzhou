import { Outlet } from 'react-router';
import { ArchiveX, Inbox, Send, Trash2, File, Bug, ClipboardList, Codesandbox, Layers, LayoutDashboard, FlaskConical, FlaskRound } from "lucide-react";
import { Nav } from '@/components/nav/nav';

export function Project() {

    return (
        <div className="flex  flex-row  h-full overflow-y-auto">
            <aside className="h-full">
                <Nav isCollapsed={false}
                    links={[
                        {
                            title: "概览",
                            label: "",
                            icon: LayoutDashboard ,
                            to: ""
                        },
                        {
                            title: "需求",
                            label: "",
                            icon: Layers,
                            to: "demands"
                        },
                        {
                            title: "任务",
                            label: "",
                            icon: ClipboardList,
                            to: "task"
                        },
                        {
                            title: "缺陷",
                            label: "",
                            icon: Bug,
                            to: "bug"
                        },
                        {
                            title: "测试",
                            label: "",
                            icon: FlaskRound,
                            to: "test"
                        },
                        // {
                        //     title: "迭代",
                        //     label: "",
                        //     icon: Archive,
                        //     variant: "ghost",
                        //     to: "bug"
                        // },
                    ]} />
            </aside>
            <div className="flex-1 overflow-y-auto"> <Outlet></Outlet></div>
        </div>
    );

}