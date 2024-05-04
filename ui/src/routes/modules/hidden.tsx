import { IRouter } from "..";
import { Bug, ClipboardList, FolderOpen } from "lucide-react";
import { Overview } from "@/pages/projects/pages/overview";
import { Task } from "@/pages/projects/pages/task";
import { Bugs } from "@/pages/projects/pages/bug";
import { Tests } from "@/pages/projects/pages/tests";
import { Demands } from "@/pages/projects/demands/demands";

const hidden: IRouter[] = [
    // {
    //     id: "demand",
    //     path: "/projects/demand/:id",
    //     meta: {
    //         Icon: FolderOpen,
    //         hidden: true,
    //     },
    //     async lazy() {
    //         const { Demand } = await import("@/pages/projects/demands/detail");
    //         return { Component: Demand };
    //     },
    // },
    {
        id: "project",
        path: "/:teamid/projects/:pid",
        meta: {
            title: '项目/xxx',
            Icon: FolderOpen,
            hidden: true,
            showHeader: true
        },
        async lazy() {
            const { Project } = await import("@/pages/projects/pages/project");
            return { Component: Project };
        },
        children: [
            {
                id: "project-info",
                path: "",
                meta: {
                    title: '概览',
                    Icon: FolderOpen,
                    showHeader: true
                },
                element: <Overview></Overview>
            },
            {
                id: "project-req",
                path: "demands",
                meta: {
                    title: '需求',
                    Icon: FolderOpen,
                },
                element: <Demands></Demands>
            },
            {
                id: "project-req-detail",
                path: "demands/:id",
                meta: {
                    Icon: FolderOpen,
                    hidden: true,
                },
                async lazy() {
                    const { Demand } = await import("@/pages/projects/demands/detail");
                    return { Component: Demand };
                },
            },
            {
                id: "project-task",
                path: "task",
                element: <Task />,
                meta: {
                    title: '任务',
                    Icon: ClipboardList,
                },
            },
            {
                id: "project-bug",
                path: "bug",
                element: <Bugs></Bugs>,
                meta: {
                    title: '缺陷',
                    Icon: Bug,
                },
            },
            {
                id: "project-test",
                path: "test",
                element: <Tests></Tests>,
                meta: {
                    title: '测试',
                    Icon: FolderOpen,
                },
            },
        ]
    },
]

export default hidden;