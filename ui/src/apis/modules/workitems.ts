import { useQuery } from "@tanstack/react-query";
import config from "../config";
import { WorkitemsApi } from "@/apis-gen";

export function useMyIssues(organizationId: string) {
  return useQuery({
    queryKey: ["orgs"],
    queryFn: () =>
      new WorkitemsApi(config).myIssue({
        organizationId: organizationId,
      }),
  });
}
