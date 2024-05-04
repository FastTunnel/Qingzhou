import { Nav } from "@/components/nav/nav";
import { currentUserAtom, tokenAtom } from "@/store";
import { useAtom } from "jotai";
import { Inbox, LogOut } from "lucide-react";
import { handleRequest } from "msw";

export function User() {
    let [token, setToken] = useAtom(tokenAtom);
    let [user, setUser] = useAtom(currentUserAtom);

    function handleClick() {
        setToken("");
    }

    return <>
        <div>{user?.UserName}</div>

        <Nav isCollapsed={false}
            links={[
                {
                    title: "退出登录",
                    icon: LogOut,
                    onClick: handleClick
                },
            ]} />
    </>
}