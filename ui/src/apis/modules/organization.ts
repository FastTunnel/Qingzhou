import { OrganizationApi } from "@/apis-gen";
import { useQuery } from "@tanstack/react-query";
import config from "../config";
import { useAtom } from "jotai";
import { tokenAtom } from "@/store";

export function useOrgs() {
  let [token, setToken] = useAtom(tokenAtom);
  console.log("config", config);

  return useQuery({
    queryKey: ["orgs"],
    queryFn: () => new OrganizationApi(config).listOrganizations(),
  });
}
