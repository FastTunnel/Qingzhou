import { Org } from "@/apis-gen";
import { useOrgs } from "@/apis/modules/organization";
import { Navigate, useNavigate } from "react-router-dom";

export function Orgs() {
    const { status, data, error } = useOrgs();
    const navigate = useNavigate();

    function checkOrg(orgId: string) {
        console.log(orgId);
        navigate(`/${orgId}/workbench`, { replace: true })
    }

    function Content(list: Org[]) {
        return <div className="container content-center justify-center  pt-10 ">
            <h1 className="text-xl font-bold py-2">我的团队</h1>
            <div className="flex flex-row gap-4">
                {
                    list.map(x => {
                        return <div key={x.id} className="basis-1/4 hover:bg-gray-50 rounded-md border cursor-pointer" onClick={(e) => { checkOrg(x.id) }}>
                            <div className=" p-4">
                                <div className="text-md font-bold py-2">{x.name}</div>
                                <div>{x.describe}</div>
                            </div>
                        </div>
                    })
                }
            </div>
        </div>
    }

    if (status === 'pending') {
        return "Loading...";
    } else if (error instanceof Error) {
        return <span>Error: {error.message}</span>;
    } else {
        return data?.data?.orgs ? (data.data.orgs.length == 1 ? <Navigate to={`/${data?.data?.orgs[0].id}/workbench`} replace /> : Content(data.data.orgs))
            : <Navigate to="/create-team" replace />;
    }
}
