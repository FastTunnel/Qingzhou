import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Separator } from "@/components/ui/separator";
import { useParams } from "react-router-dom"

import { Pencil } from 'lucide-react'
import { useIssueDetail } from "@/apis/modules/workitems";

export function Demand() {
    let params = useParams();
    const { status, data, error, isFetching } = useIssueDetail(params.id);

    if (status === 'pending') {
        return "Loading...";
    } else if (error instanceof Error) {
        return <span>Error: {error.message}</span>;
    } else {
        return <div className="p-4">
            <div className="flex flex-row">
                {/* 需求描述 */}
                <div className="flex-1">
                    <h2 className="text-2xl font-bold tracking-tight">{data?.data?.demand_title}!</h2>
                    <div className=" py-2 space-x-1">
                        <Button variant="outline"><Pencil className="h-4 w-4 mr-2 "></Pencil> 编辑描述</Button>
                    </div>
                    <Separator />
                    <div className=" pt-2">
                        {data?.data?.demand_content}
                    </div>

                    <div>
                        {data?.data?.content && <div dangerouslySetInnerHTML={{ __html: data?.data?.content }}></div>}
                    </div>
                </div>
                {/* 右侧 */}
                <div className="m-4  w-[400px] shadow-sm">
                    <div className="grid gap-2">
                        <Label htmlFor="email">状态</Label>
                        <Input id="email" type="email" value={data?.data?.demand_status_name} />
                    </div>
                    <div className="grid gap-2">
                        <Label htmlFor="email">负责人</Label>
                        <Input id="email" type="email" value={data?.data?.research_user_name} />
                    </div>
                </div>
            </div>

        </div>
    }
}