"use client"

import { cn } from "@/lib/utils"
import { LucideIcon } from "lucide-react"

import { Link, useLocation } from "react-router-dom"
import { Tooltip, TooltipContent, TooltipTrigger } from "../ui/tooltip"
import { Sheet, SheetContent, SheetDescription, SheetHeader, SheetTitle, SheetTrigger } from "../ui/sheet.mine"
import { ReactNode } from "react"

export interface SidebarNavProps extends React.HTMLAttributes<HTMLElement> {
  items: {
    href?: string
    title: string,
    blank?: boolean,
    icon?: LucideIcon,
    sheet?: ReactNode
  }[],
  onlyIcon?: boolean
}

export function SidebarNav({ className, items, onlyIcon, ...props }: SidebarNavProps) {
  const { pathname } = useLocation()
  console.log(pathname, "pathname");

  return (
    <nav
      className={cn(
        "flex space-x-2 flex-col space-x-0 space-y-1 p-2",
        className
      )}
      {...props}
    >
      {items.map((item) => (
        (item.sheet) ?
          <Sheet key={item.title}>
            <SheetTrigger  >
              <div className={cn(
                'flex w-12 mb-2 rounded-sm',
                onlyIcon ? 'h-9' : 'h-14',
              )}>
                <div className=" flex items-center flex-col w-full pt-2"  >
                  <span>
                    {item.icon && <item.icon className="w-5 h-5"></item.icon>}
                  </span>
                </div>
              </div>
            </SheetTrigger>
            <SheetContent style={{ left: "65px" }} side={"left"} className="w-[250px]"  >
              {item.sheet}
            </SheetContent>
          </Sheet> :
          <Link
            key={item.href}
            to={item.href ?? ""}
            target={item.blank ? '_blank' : '_self'}
            className={cn(
              'flex w-12 mb-2 rounded-sm',
              onlyIcon ? 'h-9' : 'h-14',
              (pathname.indexOf(item?.href ?? "") >= 0)
                ? 'bg-secondary text-secondary-foreground hover:bg-secondary/80'
                : "hover:bg-accent hover:text-accent-foreground"
            )}
          >
            <div className=" flex items-center flex-col w-full pt-2"  >
              {onlyIcon ?
                <Tooltip>
                  <TooltipTrigger>
                    {
                      item.icon == null ? <></> : <span>
                        {<item.icon className="w-5 h-5"></item.icon>}
                      </span>
                    }

                    <TooltipContent side="right">
                      <p>{item.title} </p>
                    </TooltipContent>
                  </TooltipTrigger>
                </Tooltip>
                :
                <>
                  {
                    item.icon == null ? <></> : <span>
                      {<item.icon className="w-5 h-5"></item.icon>}
                    </span>
                  }

                  <span className={cn("text-xs pt-1 text-primary")} >{item.title}</span>
                </>
              }
            </div>
          </Link>
      ))
      }
    </nav >
  )
}
