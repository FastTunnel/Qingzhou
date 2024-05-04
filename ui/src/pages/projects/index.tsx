import { Table, TableBody, TableCaption, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { Link, useParams } from "react-router-dom";
import { useState } from "react";
import { Badge } from "@/components/ui/badge";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { PlusCircledIcon } from "@radix-ui/react-icons";
import { CreateProjectForm } from "./components/create-project-form";
import { useProjects } from "@/apis/modules/project";

function TableView({ name }: { name: string | undefined }) {
    const params = useParams();
    const { status, data, error, refetch } = useProjects(name, params.teamid!);
    let [step, setStep] = useState(0);
    function initData() {
        setStep(0);
        refetch();
    }

    if (status === 'pending') {
        return "Loading...";
    } else if (error instanceof Error) {
        return <span>Error: {error.message}</span>;
    } else {
        if (step == 0) {
            return <>
                <div className=" space-y-8">
                    <div className="flex items-center justify-between">
                        <div className="flex flex-1 items-center space-x-2">
                            <Input
                                placeholder="项目名称"
                                className="w-[150px] lg:w-[250px]"
                            />
                        </div>
                        <div className="ml-auto mr-4">
                            <Button onClick={() => { setStep(1) }}>
                                <PlusCircledIcon className="mr-2 h-4 w-4" />
                                新增项目
                            </Button>
                        </div>
                    </div>
                    <Table>{data?.data?.rows.length == 0 && <TableCaption>暂无项目</TableCaption>}
                        <TableHeader>
                            <TableRow>
                                <TableHead>项目名称</TableHead>
                                <TableHead>状态</TableHead>
                                <TableHead>项目编码</TableHead>
                                <TableHead>创建时间</TableHead>
                            </TableRow>
                        </TableHeader>

                        <TableBody>
                            {data?.data?.rows.map(x => {
                                return <TableRow key={x.productid}>
                                    <TableCell><Link to={`/${x.teamId}/projects/${x.productid}`}>{x.productname}</Link></TableCell>
                                    <TableCell>{x.status == 0 ? <Badge variant="secondary">进行中</Badge> : <Badge variant="secondary">其他</Badge>}</TableCell>
                                    <TableCell>{x.productcode}</TableCell>
                                    <TableCell>{x.syscreatetime}</TableCell>
                                </TableRow>
                            })}
                        </TableBody>
                    </Table>
                </div>
            </>
        } else if (step == 1) {
            return <CreateProjectForm onBack={() => { setStep(--step) }} onSuccess={(id) => { initData() }}></CreateProjectForm>
        }
    }
}

export function Projects() {
    let [name] = useState("");

    return (
        <div className=" p-4">
            <TableView name="" ></TableView>
        </div>
    );
}
