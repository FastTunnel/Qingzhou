import { lazy } from 'react';
import { SquareCode } from "lucide-react"
import { IRouter } from '..';

export const fullscreenRoutes: IRouter[] = [
  {
    id: 'login',
    path: '/login',
    async lazy() {
      const { Login } = await import("@/pages/login/index");
      return { Component: Login };
    },
    meta: {
      requiresAuth: false,
      hidden: true,
    },
  },
  {
    id: "orgs",
    path: "/orgs",
    meta: {
      title: '组织',
      hidden: true,
    },
    async lazy() {
      const { Orgs } = await import("@/pages/org/orgs");
      return { Component: Orgs };
    },
  },
  {
    id: 'team',
    path: '/team',
    meta: {
      title: '组织',
      Icon: SquareCode,
    },
    Component: lazy(() => import('@/pages/org/index')),
  },
  {
    id: 'create-team',
    path: "/create-team",
    async lazy() {
      const { CreatTeam } = await import("@/pages/org/create-org");
      return { Component: CreatTeam };
    },
    meta: {
      title: '创建组织',
      hidden: true,
    }
  }
];

