import { Badge } from "@/components/ui/badge";
import { Table, TableBody, TableCaption, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { Link, useParams } from "react-router-dom";
import { Input } from "@/components/ui/input";
import { Pagination, PaginationContent, PaginationEllipsis, PaginationItem, PaginationLink, PaginationNext, PaginationPrevious } from "@/components/ui/pagination";
import { Button } from "@/components/ui/button";
import { PlusCircledIcon } from "@radix-ui/react-icons";
import { useMyIssues } from "@/apis/modules/workitems";

export function Demands() {
    let params = useParams();
    const { status, data, error, isFetching } = useMyIssues();

    if (status === 'pending') {
        return "Loading...";
    } else if (error instanceof Error) {
        return <span>Error: {error.message}</span>;
    } else {
        return <div className="p-4">
            <div className="space-y-4">
                <div className="flex items-center justify-between">
                    <div className="flex flex-1 items-center space-x-2">
                        <Input
                            placeholder="需求名称"
                            className="w-[150px] lg:w-[250px]"
                        />
                    </div>
                    <div className="ml-auto mr-4">
                        <Button>
                            <PlusCircledIcon className="mr-2 h-4 w-4" />
                            新增
                        </Button>
                    </div>
                </div>

                <Table>{data?.data?.rows.length == 0 && <TableCaption>暂无项目</TableCaption>}
                    <TableHeader>
                        <TableRow>
                            <TableHead>ID</TableHead>
                            <TableHead>需求名称</TableHead>
                            <TableHead>状态</TableHead>
                            <TableHead>紧急程度</TableHead>
                            <TableHead>负责人</TableHead>
                            {/* <TableHead>测试</TableHead>
                                <TableHead>UI</TableHead> */}
                            <TableHead>创建人</TableHead>
                            <TableHead>创建时间</TableHead>
                        </TableRow>
                    </TableHeader>

                    <TableBody>
                        {data?.data?.rows.map(x => {
                            return <TableRow key={x.demand_id}>
                                <TableCell><Link to={`/${x.teamId}/projects/${x.projectId}/demands/${x.demand_id}`}>#{x.demand_id}</Link></TableCell>
                                <TableCell><Link to={`/${x.teamId}/projects/${x.projectId}/demands/${x.demand_id}`}>{x.demand_title}</Link></TableCell>
                                <TableCell><Badge variant="secondary">{x.demand_status_name}</Badge></TableCell>
                                <TableCell><Badge variant={"destructive"}>{x.urgency_level_name}</Badge></TableCell>
                                <TableCell>{x.research_user_name}</TableCell>
                                {/* <TableCell>{x.test_user_id}</TableCell>
                                    <TableCell>{x.design_user_id}</TableCell> */}
                                <TableCell>{x.create_name}</TableCell>
                                <TableCell>{x.create_time_str}</TableCell>
                            </TableRow>
                        })}
                    </TableBody>
                </Table>

                <Pagination>
                    <PaginationContent>
                        <PaginationItem>
                            <PaginationPrevious />
                        </PaginationItem>
                        <PaginationItem>
                            <PaginationLink href="#">1</PaginationLink>
                        </PaginationItem>
                        <PaginationItem>
                            <PaginationLink href="#" isActive>
                                2
                            </PaginationLink>
                        </PaginationItem>
                        <PaginationItem>
                            <PaginationLink href="#">3</PaginationLink>
                        </PaginationItem>
                        <PaginationItem>
                            <PaginationEllipsis />
                        </PaginationItem>
                        <PaginationItem>
                            <PaginationNext href="#" />
                        </PaginationItem>
                    </PaginationContent>
                </Pagination>
            </div>
        </div>
    }
}