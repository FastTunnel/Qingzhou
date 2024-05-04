import { OrganizationApi } from "@/apis-gen";
import { Logo } from "@/components/logo";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";

export function CreatTeam() {
    const navigate = useNavigate();
    const mutation = useMutation({
        mutationFn: (formData: FormData) => {
            const name = formData.get("name") as string;
            const description = formData.get("description") as string;
            console.log(name, formData);

            return new OrganizationApi().organizationCreateOrganization({
                addTeamCommand: {
                    name: name,
                    description: description
                }
            });
        },
        onSuccess: (data) => {
            console.log(data);
            toast.success("创建成功")
            navigate(`/`, { replace: true })
        },
        onError: (error) => {
            toast.error(error.message)
        }
    })

    const onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const formData = new FormData(event.currentTarget);
        mutation.mutate(formData);
    };

    return (
        <div>
            <div className="p-10">
                <Logo></Logo>
            </div>
            <Card className="m-auto w-[500px] relative top-[20%]">
                <form onSubmit={onSubmit}>
                    <CardHeader>
                        <CardTitle>创建团队</CardTitle>
                    </CardHeader>
                    <CardContent>
                        <div className="grid w-full items-center gap-4">
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="name">名称</Label>
                                <Input name="name" placeholder="团队名称" />
                            </div>
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="description">描述</Label>
                                <Input name="description" placeholder="团队描述" />
                            </div>
                        </div>

                    </CardContent>
                    <CardFooter className="flex justify-between">
                        <Button>创建</Button>
                    </CardFooter>
                </form>
            </Card>
        </div>
    )
}