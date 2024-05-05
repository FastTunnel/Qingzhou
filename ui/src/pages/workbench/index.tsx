import { useMyIssues } from "@/apis/modules/workitems";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { currentUserAtom } from "@/store";
import { useAtom } from "jotai";
import { Link, useParams } from "react-router-dom";

function DataTable() {
    const params = useParams();
    console.log("params", params);

    const { status, data, error, isFetching } = useMyIssues(params.teamid!);

    if (status === 'pending') {
        return "Loading...";
    } else if (error instanceof Error) {
        return <span>Error: {error.message}</span>;
    } else {
        return <Table>
            {/* {data?.data?.length == 0 && <TableCaption>暂无项目</TableCaption>} */}
            <TableHeader>
                <TableRow>
                    <TableHead>ID</TableHead>
                    <TableHead>需求名称</TableHead>
                    {/* <TableHead>状态</TableHead> */}
                    {/* <TableHead>紧急程度</TableHead>
                    <TableHead>负责人</TableHead> */}
                    <TableHead>创建人</TableHead>
                    <TableHead>创建时间</TableHead>
                </TableRow>
            </TableHeader>

            <TableBody>
                {data?.issues?.map(x => {
                    return <TableRow key={x.id}>
                        <TableCell><Link to={`/projects/${x.orgId}/issue/${x.id}`}>#{x.id}</Link></TableCell>
                        <TableCell><Link to={`/projects/${x.orgId}/issue/${x.id}`}>{x.issueTitle}</Link></TableCell>
                        <TableCell>{x.createdBy}</TableCell>
                        <TableCell>{x.createdAt}</TableCell>
                    </TableRow>
                })}
            </TableBody>
        </Table>
    }
}

export function Workbench() {
    const [user] = useAtom(currentUserAtom);
    return <>
        <div className="p-4 space-y-8">
            <div>
                <h2 className="text-2xl font-bold tracking-tight">欢迎回来 {user?.UserName}!</h2>
                <p className="text-muted-foreground">
                    继续今天的工作吧 🤣
                </p>
            </div>
            <Card>
                <CardHeader>
                    <CardTitle>我的工作事项</CardTitle>
                    <CardDescription>以下是您未完成的工作.</CardDescription>
                </CardHeader>
                <CardContent className="grid gap-4">
                    <DataTable></DataTable>
                </CardContent>
            </Card>
        </div>
    </>
} 