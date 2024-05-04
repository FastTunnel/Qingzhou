import { CircleUser, Github, Gitlab, Settings } from "lucide-react"

import { IRouter } from "..";
import { User } from "@/layout/user";

export const bottomRoutes: IRouter[] = [
    {
        id: 'repo',
        path: "http://gitlab.bx.com.cn/bx/Collab",
        meta: {
            title: '源码仓库',
            Icon: Gitlab,
            blank: true,
        },
    },
    {
        id: 'setting',
        path: "/:teamid/setting",
        async lazy() {
            const { Setting } = await import("@/pages/setting/index");
            return { Component: Setting };
        },
        meta: {
            title: '设置中心',
            Icon: Settings,
        },
    },
    {
        id: 'user',
        path: "/:teamid/user",
        meta: {
            title: '个人',
            Icon: CircleUser,
        },
        element:<User></User>
    },
];

