import { ProjectsApi } from "@/apis-gen";
import { useQuery } from "@tanstack/react-query";
import config from "../config";

export function useProjects(name: string | undefined, teamId: string) {
  return useQuery({
    queryKey: ["projectViews"],
    queryFn: () =>
      new ProjectsApi(config).projectsListProjects({
        organizationId: teamId,
      }),
  });
}
