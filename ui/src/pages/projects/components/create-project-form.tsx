import { Icons } from "@/components/icons";
import { SubpageBack } from "@/components/pages/subpage-back";
import { Button } from "@/components/ui/button"
import { Card } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import { useMutation } from "@tanstack/react-query";
import { MouseEventHandler, useState } from "react";
import { useParams } from "react-router-dom";
import { toast } from "sonner";
import { useForm } from 'react-hook-form';
import * as z from "zod"
import { zodResolver } from "@hookform/resolvers/zod"
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form";
import { Action } from "@/common/types";
import { ProjectsApi } from "@/apis-gen";

const formSchema = z.object({
    projectName: z.string().min(2, {
        message: "至少2个字符",
    }).max(20, {
        message: "最多20个字符",
    }),
    projectNo: z.string().min(2, {
        message: "至少2个字符",
    }).max(20, {
        message: "最多20个字符",
    }),
    desc: z.string().optional()
})

export function CreateProjectForm({ onBack, onSuccess }: { onBack?: MouseEventHandler | undefined, onSuccess: Action<string> }) {
    const params = useParams();
    if (!params.teamid) {
        throw Error("参数异常");
    }

    const [template, setTemplate] = useState("");
    // const { status, data, error, isFetching } = useProjectTemplates(params.teamid);

    const [isLoading, setIsLoading] = useState<boolean>(false)
    const mutation = useMutation({
        mutationFn: (formData: z.infer<typeof formSchema>) => {
            setIsLoading(true);
            return new ProjectsApi().createProject({ organizationId: params.teamid!, createProjectRequest: { ...formData } })
        },
        onSuccess: (data) => {
            console.log(data);
            setIsLoading(false);
            onSuccess(data.data!.projectId);
        },
        onError: (error) => {
            toast.error(error.message)
            setIsLoading(false);
        }
    })

    // 1. Define your form.
    const form = useForm<z.infer<typeof formSchema>>({
        resolver: zodResolver(formSchema),
        defaultValues: {
            projectName: "",
            projectNo: "",
            desc: ""
        },
    })

    // 2. Define a submit handler.
    function onSubmit(values: z.infer<typeof formSchema>) {
        console.log(values)
        mutation.mutate(values);
    }

    if (template == "") {
        if (status === 'pending') {
            return "Loading...";
        } else if (error instanceof Error) {
            return <span>Error: {error.message}</span>;
        } else {
            return <SubpageBack title="选择项目模板" onBack={onBack}>
                <div className=" pt-24 grid gap-4 grid-cols-3 mx-auto w-[900px]">
                    {
                        data && data.data?.templates.map(x => {
                            return <Card key={x.templateId}>
                                <div className=" p-8">
                                    <h2 className="p-2 text-center font-bold">{x.templateName}</h2>
                                    <p>{x.desc}</p>
                                    <div className="p-2 text-center" onClick={() => { setTemplate(x.templateId) }}>
                                        <Button>使用此模板</Button>
                                    </div>
                                </div>
                            </Card>
                        })
                    }
                </div>
            </SubpageBack>
        }
    } else {
        return <SubpageBack showClose={true} title="填写项目信息" onBack={() => { setTemplate("") }} onClose={onBack}>
            <Form {...form}>
                <form onSubmit={form.handleSubmit(onSubmit)} className=" pt-4 w-[500px]">
                    <div className="grid gap-4">
                        <FormField
                            control={form.control}
                            name="projectName"
                            render={({ field }) => (
                                <FormItem>
                                    <FormLabel>项目名称</FormLabel>
                                    <FormControl>
                                        <Input placeholder="项目名称" {...field} />
                                    </FormControl>
                                    <FormMessage />
                                </FormItem>
                            )}
                        />
                        <FormField
                            control={form.control}
                            name="projectNo"
                            render={({ field }) => (
                                <FormItem>
                                    <FormLabel>项目编号</FormLabel>
                                    <FormControl>
                                        <Input placeholder="项目编号" {...field} />
                                    </FormControl>
                                    <FormMessage />
                                </FormItem>
                            )}
                        />
                        <FormField
                            control={form.control}
                            name="desc"
                            render={({ field }) => (
                                <FormItem>
                                    <FormLabel>项目描述</FormLabel>
                                    <FormControl>
                                        <Textarea placeholder="项目描述" {...field} />
                                    </FormControl>
                                    <FormMessage />
                                </FormItem>
                            )}
                        />

                        <div>
                            <Button disabled={isLoading}>
                                {isLoading && (
                                    <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
                                )}
                                创 建
                            </Button>
                        </div>
                    </div>
                </form >
            </Form>
        </SubpageBack>
    }
}