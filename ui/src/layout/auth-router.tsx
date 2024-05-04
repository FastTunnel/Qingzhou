import { searchRouteV2 } from "@/routes/utils";
import { useLocation, Navigate, useMatches, useMatch } from "react-router-dom";
import { allRoutes } from '@/routes';
import { useAtom } from "jotai";
import { currentUserAtom } from "@/store";
import { ReactElement, memo } from "react";
import Header from "./header";

function Route(props: { children: ReactElement<any, any> }) {
	const { pathname } = useLocation();
	const matches = useMatches();
	const [currentUser] = useAtom(currentUserAtom);

	const route = searchRouteV2(matches, allRoutes);
	console.log("[Auth]", pathname, route, matches);

	if (route == undefined) {
		// 没有找到默认走权限
		if (pathname != '/') {
			console.error("[未匹配的路由]", pathname);
		}
	} else {
		// axiosCanceler.removeAllPending();
		if (!(route.meta?.requiresAuth ?? true)) {
			return props.children;
		}
	}

	if (currentUser) {
		// if (pathname == "/") {
		// 	if (currentUser.Teams && currentUser.Teams.length > 0) {
		// 		return <Navigate to={`/${currentUser.Teams[0].Id}/workbench`} replace />;
		// 	} else {
		// 		return <Navigate to="/create-team" replace />;
		// 	}
		// }
		if (pathname == "/") {
			return <Navigate to="/orgs" replace />;
		}

		if (route?.meta.showHeader ?? false) {
			return (<><Header title={route?.meta.title}></Header > {props.children}</>);
		} else {
			return props.children;
		}
	} else {
		return <Navigate to="/login" replace />;
	}
}

const PrivateRoute = memo(Route, () => { return true });

export default PrivateRoute;