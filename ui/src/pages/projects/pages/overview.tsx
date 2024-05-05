import { ProjectsApi } from "@/apis-gen";
import config from "@/apis/config";
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { useQuery } from "@tanstack/react-query";
import { useParams } from "react-router-dom"

function useProject(id: string | undefined) {
    return useQuery({
        queryKey: ['project', id],
        queryFn: () => new ProjectsApi(config).listProjects({
            organizationId: id
        }),
    },)
}

export function Overview() {
    let params = useParams();
    const { status, data, error, isFetching } = useProject(params.pid);

    if (status === 'pending') {
        return "Loading...";
    } else if (error instanceof Error) {
        return <span>Error: {error.message}</span>;
    } else {
        return <div className=" p-4">
            <Card>
                <CardHeader>
                    <CardTitle>{data?.data?.productname}</CardTitle>
                    <CardDescription>{data?.data?.productinfo}</CardDescription>
                </CardHeader>
                <CardContent>
                    <div><span>项目编码:</span> <p>{data?.data?.productcode}</p></div><div><span>创建时间:</span> <p>{data?.data?.syscreatetime}</p></div>
                </CardContent>
            </Card>
        </div>
    }
}