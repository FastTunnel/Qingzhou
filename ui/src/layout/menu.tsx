import { memo } from "react";
import { Separator } from "@/components/ui/separator"
import { SidebarNav, SidebarNavProps } from "@/components/sidebar/sidebar";
import { sideRoutes } from "@/routes/modules/side";
import { CircleUser } from "lucide-react";
import { User } from "./user";
import { generatePath, useParams } from "react-router-dom";
import { bottomRoutes } from "@/routes/modules/bottom";

const Menu = memo(() => {
    const params = useParams();
    if (!params.teamid) {
        return;
    }

    const sidebarNavItems: SidebarNavProps = {
        items: sideRoutes.map((router) => {
            return {
                title: router.meta?.title ?? "",
                href: router.path && generatePath(router.path, params),
                icon: router.meta?.Icon,
                blank: router.meta?.blank,
            }
        })
    }

    const fixedNavItems: SidebarNavProps = {
        items: bottomRoutes.map((router) => {
            return {
                title: router.meta?.title ?? "",
                href: router.path && generatePath(router.path, params),
                icon: router.meta?.Icon,
                blank: router.meta?.blank,
                sheet: router.element
            }
        })
    }

    // const fixedNavItems: SidebarNavProps = {
    //     items: [{
    //         title: "个人中心",
    //         icon: CircleUser,
    //         sheet: <User></User>
    //     }]
    // }

    return (
        <aside className="border-r flex border-[#e7e5e4] bg-white" style={{ zIndex: 1000, }} >
            <div className='h-full ' style={{ overflow: 'hidden auto' }}>
                <div className='flex flex-col h-full' style={{ overflow: 'hidden auto' }}>
                    <div className='flex-1 flex flex-col' style={{ overflow: 'hidden' }}>
                        <SidebarNav className='flex-1 layout-sider-menu' style={{ overflow: 'hidden auto' }} items={sidebarNavItems.items}></SidebarNav>
                        <Separator />
                    </div>
                    <div>
                        <SidebarNav onlyIcon={true} items={fixedNavItems.items}></SidebarNav>
                    </div>
                </div>
            </div>
        </aside >
    );
});


export default Menu;