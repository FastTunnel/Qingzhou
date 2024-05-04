import { Airplay, FolderOpen, ClipboardCheck } from "lucide-react"
import { IRouter } from "..";

export const sideRoutes: IRouter[] = [
    {
        id: "workbench",
        path: "/:teamid/workbench",
        async lazy() {
            const { Workbench } = await import("@/pages/workbench/index");
            return { Component: Workbench };
        },
        meta: {
            title: '工作台',
            Icon: Airplay,
        },
    },
    // {
    //     path: "/issues",
    //     async lazy() {
    //         const { Issues } = await import("@/pages/issues/index");
    //         return { Component: Issues };
    //     },
    //     meta: {
    //         title: '事项',
    //         Icon: ClipboardCheck,
    //     },
    // },
   
    {
        id: "projects",
        path: "/:teamid/projects",
        async lazy() {
            const { Projects } = await import("@/pages/projects/index");
            return { Component: Projects };
        },
        meta: {
            title: '项目',
            Icon: FolderOpen,
            showHeader: true
        },
    },
];